namespace CoffeeMachine.Client
{
	partial class frmMain
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nudSugar = new System.Windows.Forms.NumericUpDown();
            this.nudCream = new System.Windows.Forms.NumericUpDown();
            this.cboSize = new System.Windows.Forms.ComboBox();
            this.btnAddCoffee = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nudPayment = new System.Windows.Forms.NumericUpDown();
            this.btnAddPayment = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCurrentPayment = new System.Windows.Forms.Label();
            this.lblOrderTotal = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnVend = new System.Windows.Forms.Button();
            this.lstOrderDetails = new System.Windows.Forms.ListView();
            this.Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Cream = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Sugar = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSugar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCream)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPayment)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nudSugar);
            this.groupBox1.Controls.Add(this.nudCream);
            this.groupBox1.Controls.Add(this.cboSize);
            this.groupBox1.Controls.Add(this.btnAddCoffee);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(11, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(1);
            this.groupBox1.Size = new System.Drawing.Size(163, 139);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add a coffee";
            // 
            // nudSugar
            // 
            this.nudSugar.Location = new System.Drawing.Point(72, 70);
            this.nudSugar.Name = "nudSugar";
            this.nudSugar.Size = new System.Drawing.Size(79, 20);
            this.nudSugar.TabIndex = 6;
            this.nudSugar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nudCream
            // 
            this.nudCream.Location = new System.Drawing.Point(72, 46);
            this.nudCream.Name = "nudCream";
            this.nudCream.Size = new System.Drawing.Size(79, 20);
            this.nudCream.TabIndex = 5;
            this.nudCream.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cboSize
            // 
            this.cboSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSize.FormattingEnabled = true;
            this.cboSize.Location = new System.Drawing.Point(72, 20);
            this.cboSize.Name = "cboSize";
            this.cboSize.Size = new System.Drawing.Size(79, 21);
            this.cboSize.TabIndex = 4;
            // 
            // btnAddCoffee
            // 
            this.btnAddCoffee.Location = new System.Drawing.Point(72, 104);
            this.btnAddCoffee.Margin = new System.Windows.Forms.Padding(1);
            this.btnAddCoffee.Name = "btnAddCoffee";
            this.btnAddCoffee.Size = new System.Drawing.Size(76, 22);
            this.btnAddCoffee.TabIndex = 7;
            this.btnAddCoffee.Text = "Add to Order";
            this.btnAddCoffee.UseVisualStyleBackColor = true;
            this.btnAddCoffee.Click += new System.EventHandler(this.btnAddCoffee_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 72);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Sugar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 48);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cream";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Size";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(194, 10);
            this.label4.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Current order:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nudPayment);
            this.groupBox2.Controls.Add(this.btnAddPayment);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(11, 166);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(1);
            this.groupBox2.Size = new System.Drawing.Size(163, 83);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Payment";
            // 
            // nudPayment
            // 
            this.nudPayment.DecimalPlaces = 2;
            this.nudPayment.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudPayment.Location = new System.Drawing.Point(72, 23);
            this.nudPayment.Name = "nudPayment";
            this.nudPayment.Size = new System.Drawing.Size(79, 20);
            this.nudPayment.TabIndex = 10;
            this.nudPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudPayment.Leave += new System.EventHandler(this.nudPayment_Leave);
            // 
            // btnAddPayment
            // 
            this.btnAddPayment.Location = new System.Drawing.Point(72, 49);
            this.btnAddPayment.Margin = new System.Windows.Forms.Padding(1);
            this.btnAddPayment.Name = "btnAddPayment";
            this.btnAddPayment.Size = new System.Drawing.Size(76, 22);
            this.btnAddPayment.TabIndex = 11;
            this.btnAddPayment.Text = "Add to Order";
            this.btnAddPayment.UseVisualStyleBackColor = true;
            this.btnAddPayment.Click += new System.EventHandler(this.btnAddPayment_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 25);
            this.label5.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Amount";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(200, 186);
            this.label6.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Current payment:";
            // 
            // lblCurrentPayment
            // 
            this.lblCurrentPayment.AutoSize = true;
            this.lblCurrentPayment.Location = new System.Drawing.Point(302, 186);
            this.lblCurrentPayment.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblCurrentPayment.Name = "lblCurrentPayment";
            this.lblCurrentPayment.Size = new System.Drawing.Size(13, 13);
            this.lblCurrentPayment.TabIndex = 10;
            this.lblCurrentPayment.Text = "--";
            // 
            // lblOrderTotal
            // 
            this.lblOrderTotal.AutoSize = true;
            this.lblOrderTotal.Location = new System.Drawing.Point(302, 164);
            this.lblOrderTotal.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblOrderTotal.Name = "lblOrderTotal";
            this.lblOrderTotal.Size = new System.Drawing.Size(13, 13);
            this.lblOrderTotal.TabIndex = 12;
            this.lblOrderTotal.Text = "--";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(200, 164);
            this.label8.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Order total:";
            // 
            // btnVend
            // 
            this.btnVend.Location = new System.Drawing.Point(202, 214);
            this.btnVend.Margin = new System.Windows.Forms.Padding(1);
            this.btnVend.Name = "btnVend";
            this.btnVend.Size = new System.Drawing.Size(76, 22);
            this.btnVend.TabIndex = 13;
            this.btnVend.Text = "Vend!";
            this.btnVend.UseVisualStyleBackColor = true;
            this.btnVend.Click += new System.EventHandler(this.btnVend_Click);
            // 
            // lstOrderDetails
            // 
            this.lstOrderDetails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Type,
            this.Cream,
            this.Sugar,
            this.Price});
            this.lstOrderDetails.FullRowSelect = true;
            this.lstOrderDetails.GridLines = true;
            this.lstOrderDetails.Location = new System.Drawing.Point(194, 26);
            this.lstOrderDetails.MultiSelect = false;
            this.lstOrderDetails.Name = "lstOrderDetails";
            this.lstOrderDetails.Size = new System.Drawing.Size(285, 123);
            this.lstOrderDetails.TabIndex = 12;
            this.lstOrderDetails.UseCompatibleStateImageBehavior = false;
            this.lstOrderDetails.View = System.Windows.Forms.View.Details;
            // 
            // Type
            // 
            this.Type.Text = "Size";
            this.Type.Width = 85;
            // 
            // Cream
            // 
            this.Cream.Text = "Cream";
            // 
            // Sugar
            // 
            this.Sugar.Text = "Sugar";
            this.Sugar.Width = 68;
            // 
            // Price
            // 
            this.Price.Text = "Price";
            this.Price.Width = 68;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 263);
            this.Controls.Add(this.lstOrderDetails);
            this.Controls.Add(this.btnVend);
            this.Controls.Add(this.lblOrderTotal);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblCurrentPayment);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "frmMain";
            this.Text = "Vending Machine";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSugar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCream)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPayment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnAddCoffee;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button btnAddPayment;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label lblCurrentPayment;
		private System.Windows.Forms.Label lblOrderTotal;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button btnVend;
        private System.Windows.Forms.ComboBox cboSize;
        private System.Windows.Forms.ListView lstOrderDetails;
        private System.Windows.Forms.ColumnHeader Type;
        private System.Windows.Forms.ColumnHeader Cream;
        private System.Windows.Forms.ColumnHeader Sugar;
        private System.Windows.Forms.ColumnHeader Price;
        private System.Windows.Forms.NumericUpDown nudSugar;
        private System.Windows.Forms.NumericUpDown nudCream;
        private System.Windows.Forms.NumericUpDown nudPayment;
    }
}

