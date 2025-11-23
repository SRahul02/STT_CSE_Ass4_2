namespace OrderPipeline
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtName = new TextBox();
            cmbProduct = new ComboBox();
            numQuantity = new NumericUpDown();
            btnProcessOrder = new Button();
            lblStatus = new Label();
            chkExpress = new CheckBox();
            btnShipOrder = new Button();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(448, 105);
            txtName.Name = "txtName";
            txtName.Size = new Size(150, 31);
            txtName.TabIndex = 0;
            // 
            // cmbProduct
            // 
            cmbProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProduct.FormattingEnabled = true;
            cmbProduct.Items.AddRange(new object[] { "Laptop", "Mouse", "Keyboard" });
            cmbProduct.Location = new Point(448, 191);
            cmbProduct.Name = "cmbProduct";
            cmbProduct.Size = new Size(182, 33);
            cmbProduct.TabIndex = 1;
            // 
            // numQuantity
            // 
            numQuantity.Location = new Point(481, 237);
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(180, 31);
            numQuantity.TabIndex = 2;
            // 
            // btnProcessOrder
            // 
            btnProcessOrder.Location = new Point(476, 282);
            btnProcessOrder.Name = "btnProcessOrder";
            btnProcessOrder.Size = new Size(112, 34);
            btnProcessOrder.TabIndex = 3;
            btnProcessOrder.Text = "Process Order";
            btnProcessOrder.UseVisualStyleBackColor = true;
            btnProcessOrder.Click += btnProcessOrder_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(460, 319);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 25);
            lblStatus.TabIndex = 4;
            // 
            // chkExpress
            // 
            chkExpress.AutoSize = true;
            chkExpress.Location = new Point(140, 57);
            chkExpress.Name = "chkExpress";
            chkExpress.Size = new Size(173, 29);
            chkExpress.TabIndex = 5;
            chkExpress.Text = "Express Shipping";
            chkExpress.UseVisualStyleBackColor = true;
            chkExpress.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // btnShipOrder
            // 
            btnShipOrder.Enabled = false;
            btnShipOrder.Location = new Point(120, 142);
            btnShipOrder.Name = "btnShipOrder";
            btnShipOrder.Size = new Size(112, 34);
            btnShipOrder.TabIndex = 6;
            btnShipOrder.Text = "Ship Order";
            btnShipOrder.UseVisualStyleBackColor = true;
            btnShipOrder.Click += btnShipOrder_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnShipOrder);
            Controls.Add(chkExpress);
            Controls.Add(lblStatus);
            Controls.Add(btnProcessOrder);
            Controls.Add(numQuantity);
            Controls.Add(cmbProduct);
            Controls.Add(txtName);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtName;
        private ComboBox cmbProduct;
        private NumericUpDown numQuantity;
        private Button btnProcessOrder;
        private Label lblStatus;
        private CheckBox chkExpress;
        private Button btnShipOrder;
    }
}
