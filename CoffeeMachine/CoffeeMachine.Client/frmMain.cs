using System;
using System.Collections.Generic;
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
        }

		private void btnAddPayment_Click(object sender, EventArgs e)
		{
            Current = Current ?? new CoffeeOrder();
		}

		private void btnVend_Click(object sender, EventArgs e)
		{
            Current = Current ?? new CoffeeOrder();
		}
	}

    public static class AddinNames
    {
        public const string Cream = "Cream";
        public const string Sugar = "Sugar";
    }

    public static class CoffeeExtensions
    {
        public static ListViewItem ToListViewItem(this Coffee cup, CoffeeOrder current)
        {
            var subItems = new List<string>
            {
                cup.Name,
                cup.Extras.Count(s => s.Equals(AddinNames.Cream)).ToString(),
                cup.Extras.Count(s => s.Equals(AddinNames.Sugar)).ToString()
            };
            if (current.Data.IsValid(cup))
            {
                var cost = cup.Price(current);
                var total = cost.Cup.Price.GetValueOrDefault() + cost.Extras.Price.GetValueOrDefault();
                subItems.Add(total.ToString());
            }
            var item = new ListViewItem(subItems.ToArray())
            {
                Tag = cup
            };
            return item;
        }
    }
}
