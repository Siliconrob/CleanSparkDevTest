using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using CoffeeMachine.Model;
using CoffeeMachine.Operations;

namespace CoffeeMachine.Client
{
	public partial class frmMain : Form
	{
		public frmMain()
        {
            InitializeComponent();
            InitializeOptions();
        }

        private void InitializeUpDown(string keyName, NumericUpDown ctrl, CoffeeOrder order)
        {
            ctrl.Tag = keyName;
            ctrl.Enabled = false;
            if (!order.AvailableAddIns().Contains(keyName))
            {
                return;
            }
            var rule = order.Data.Addins().FirstOrDefault(z => z.Name.Equals(keyName));
            if (rule == null)
            {
                return;
            }
            ctrl.Minimum = rule.Minimum;
            if (rule.Maximum.HasValue)
            {
                ctrl.Maximum = rule.Maximum.Value;
            }
            ctrl.Text = ctrl.Minimum.ToString(CultureInfo.InvariantCulture);
            ctrl.Enabled = true;
        }

        private void InitializeOptions(CoffeeOrder order = null)
        {
            order = order ?? new CoffeeOrder();
            var items = order.AvailableSizes();
            cboSize.Items.Clear();
            if (items.Any())
            {
                cboSize.Items.AddRange(items.ToArray());
                cboSize.SelectedIndex = 0;
            }
            ResetExtras(order);
            ResetPayment(order);
            lstOrderDetails.Items.Clear();
            lblOrderTotal.Text = "-";
            lblCurrentPayment.Text = "-";
        }

        private void ResetPayment(CoffeeOrder order)
        {
            nudPayment.Enabled = false;
            nudPayment.Tag = "Payment";
            nudPayment.Text = "";
            var availableOptions = order.Data.ChangeOptions().Where(z => z.CanDispense).OrderBy(a => a.Value);
            var limits = new
            {
                Min = availableOptions.FirstOrDefault(),
                Max = availableOptions.LastOrDefault()
            };
            if (limits.Min == null)
            {
                nudPayment.Enabled = true;
                return;
            }
            nudPayment.Text = limits.Min.Value.ToString(CultureInfo.InvariantCulture);
            nudPayment.Increment = limits.Min.Value;
            if (limits.Max != null)
            {
                nudPayment.Maximum = limits.Max.Value;
            }
            nudPayment.Enabled = true;
        }

        private void ResetExtras(CoffeeOrder order)
        {
            cboSize.SelectedIndex = 0;
            InitializeUpDown(AddinNames.Cream, nudCream, order);
            InitializeUpDown(AddinNames.Sugar, nudSugar, order);
        }

        private CoffeeOrder Current { get; set; }

        private List<string> ReadExtraInput(NumericUpDown ctrl)
        {
            if (!ctrl.Enabled)
            {
                return new List<string>();
            }
            var ctrlTag = ctrl.Tag as string;
            if (string.IsNullOrEmpty(ctrlTag))
            {
                return new List<string>();
            }
            if (!int.TryParse((ctrl.Text ?? "").Trim(), out var result))
            {
                return new List<string>();
            }
            return result > 0 ? Enumerable.Repeat(ctrlTag, result).ToList() : new List<string>();
        }

        private void btnAddCoffee_Click(object sender, EventArgs e)
        {
            Current = Current ?? new CoffeeOrder();
            var extras = new List<string>();
            extras.AddRange(ReadExtraInput(nudCream));
            extras.AddRange(ReadExtraInput(nudSugar));
            var newCoffee = new Coffee
            {
                Id = Guid.NewGuid(),
                Name = cboSize.Text,
                Extras = extras
            };
            Current.Cups.Add(newCoffee);
            var item = newCoffee.ToListViewItem(Current);
            lstOrderDetails.Items.Add(item);
            ResetExtras(Current);
            lblOrderTotal.Text = Current.Price().Price.GetValueOrDefault().ToString(CultureInfo.InvariantCulture);
            HighlightTransactionState();
        }

		private void btnAddPayment_Click(object sender, EventArgs e)
		{
            Current = Current ?? new CoffeeOrder();
            if (decimal.TryParse((nudPayment.Text ?? "").Trim(), out var result))
            {
                Current.Payments.Add(result);
            }
            lblCurrentPayment.Text = Current.Payments.Sum().ToString(CultureInfo.InvariantCulture);
            ResetPayment(Current);
            HighlightTransactionState();
		}

        private void HighlightTransactionState()
        {
            if (Current.Price().Price.GetValueOrDefault() > 0)
            {
                lblCurrentPayment.ForeColor = !Current.CanDispense() ? Color.Red : Color.Black;
            }
        }

        private void btnVend_Click(object sender, EventArgs e)
		{
            Current = Current ?? new CoffeeOrder();
            if (!Current.Cups.Any() && !Current.Payments.Any())
            {
                return;
            }
            if (!Current.CanDispense())
            {
                var result = MessageBox.Show("Do you wish to cancel this order?", "Insufficient funds",
                    MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    return;
                }
            }
            if (!Current.Cups.Any())
            {
                var result = MessageBox.Show("Do you wish to cancel this order?", "No coffees added",
                    MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    return;
                }
            }
            MessageBox.Show(Current.ReceiptText(), "Receipt");
            Current = null;
            Current = new CoffeeOrder();
            InitializeOptions(Current);
            HighlightTransactionState();
        }

        private void nudPayment_Leave(object sender, EventArgs e)
        {
            if (decimal.TryParse((nudPayment.Text ?? "").Trim(), out var result))
            {
                nudPayment.Text = (Math.Round(result * 20, MidpointRounding.AwayFromZero) / 20).ToString(CultureInfo.InvariantCulture);
            }            
        }
    }
}
