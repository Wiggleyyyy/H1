namespace Connection
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
            btnStart = new Button();
            lblConnection = new Label();
            lblOrder = new Label();
            btnViewOrder = new Button();
            btnCreateOrder = new Button();
            btnDeleteOrder = new Button();
            btnDeleteCustomer = new Button();
            btnCreateCustomer = new Button();
            btnViewCustomer = new Button();
            lblCustomer = new Label();
            panelConnection = new Panel();
            listOrder = new ListView();
            panelConnection.SuspendLayout();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.LimeGreen;
            btnStart.Font = new Font("Segoe UI", 25F, FontStyle.Bold, GraphicsUnit.Point);
            btnStart.Location = new Point(12, 63);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(191, 58);
            btnStart.TabIndex = 0;
            btnStart.Text = "START";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // lblConnection
            // 
            lblConnection.AutoSize = true;
            lblConnection.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            lblConnection.Location = new Point(12, 19);
            lblConnection.Name = "lblConnection";
            lblConnection.Size = new Size(192, 28);
            lblConnection.TabIndex = 1;
            lblConnection.Text = "Connection: Closed";
            // 
            // lblOrder
            // 
            lblOrder.AutoSize = true;
            lblOrder.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            lblOrder.Location = new Point(362, 11);
            lblOrder.Name = "lblOrder";
            lblOrder.Size = new Size(66, 28);
            lblOrder.TabIndex = 2;
            lblOrder.Text = "Order";
            lblOrder.Visible = false;
            // 
            // btnViewOrder
            // 
            btnViewOrder.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            btnViewOrder.Location = new Point(299, 51);
            btnViewOrder.Name = "btnViewOrder";
            btnViewOrder.Size = new Size(191, 37);
            btnViewOrder.TabIndex = 3;
            btnViewOrder.Text = "VIEW";
            btnViewOrder.UseVisualStyleBackColor = true;
            btnViewOrder.Visible = false;
            btnViewOrder.Click += btnViewOrder_Click;
            // 
            // btnCreateOrder
            // 
            btnCreateOrder.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            btnCreateOrder.Location = new Point(299, 94);
            btnCreateOrder.Name = "btnCreateOrder";
            btnCreateOrder.Size = new Size(191, 37);
            btnCreateOrder.TabIndex = 4;
            btnCreateOrder.Text = "CREATE";
            btnCreateOrder.UseVisualStyleBackColor = true;
            btnCreateOrder.Visible = false;
            // 
            // btnDeleteOrder
            // 
            btnDeleteOrder.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            btnDeleteOrder.ForeColor = Color.Red;
            btnDeleteOrder.Location = new Point(299, 137);
            btnDeleteOrder.Name = "btnDeleteOrder";
            btnDeleteOrder.Size = new Size(191, 37);
            btnDeleteOrder.TabIndex = 5;
            btnDeleteOrder.Text = "DELETE";
            btnDeleteOrder.UseVisualStyleBackColor = true;
            btnDeleteOrder.Visible = false;
            // 
            // btnDeleteCustomer
            // 
            btnDeleteCustomer.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            btnDeleteCustomer.ForeColor = Color.Red;
            btnDeleteCustomer.Location = new Point(541, 137);
            btnDeleteCustomer.Name = "btnDeleteCustomer";
            btnDeleteCustomer.Size = new Size(191, 37);
            btnDeleteCustomer.TabIndex = 9;
            btnDeleteCustomer.Text = "DELETE";
            btnDeleteCustomer.UseVisualStyleBackColor = true;
            btnDeleteCustomer.Visible = false;
            // 
            // btnCreateCustomer
            // 
            btnCreateCustomer.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            btnCreateCustomer.Location = new Point(541, 94);
            btnCreateCustomer.Name = "btnCreateCustomer";
            btnCreateCustomer.Size = new Size(191, 37);
            btnCreateCustomer.TabIndex = 8;
            btnCreateCustomer.Text = "CREATE";
            btnCreateCustomer.UseVisualStyleBackColor = true;
            btnCreateCustomer.Visible = false;
            // 
            // btnViewCustomer
            // 
            btnViewCustomer.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            btnViewCustomer.Location = new Point(541, 51);
            btnViewCustomer.Name = "btnViewCustomer";
            btnViewCustomer.Size = new Size(191, 37);
            btnViewCustomer.TabIndex = 7;
            btnViewCustomer.Text = "VIEW";
            btnViewCustomer.UseVisualStyleBackColor = true;
            btnViewCustomer.Visible = false;
            // 
            // lblCustomer
            // 
            lblCustomer.AutoSize = true;
            lblCustomer.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            lblCustomer.Location = new Point(588, 11);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(102, 28);
            lblCustomer.TabIndex = 6;
            lblCustomer.Text = "Customer";
            lblCustomer.Visible = false;
            // 
            // panelConnection
            // 
            panelConnection.Controls.Add(btnStart);
            panelConnection.Controls.Add(lblConnection);
            panelConnection.Location = new Point(2, 1);
            panelConnection.Name = "panelConnection";
            panelConnection.Size = new Size(227, 151);
            panelConnection.TabIndex = 10;
            // 
            // listOrder
            // 
            listOrder.Location = new Point(88, 202);
            listOrder.Name = "listOrder";
            listOrder.Size = new Size(602, 185);
            listOrder.TabIndex = 11;
            listOrder.UseCompatibleStateImageBehavior = false;
            listOrder.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listOrder);
            Controls.Add(panelConnection);
            Controls.Add(btnDeleteCustomer);
            Controls.Add(btnCreateCustomer);
            Controls.Add(btnViewCustomer);
            Controls.Add(lblCustomer);
            Controls.Add(btnDeleteOrder);
            Controls.Add(btnCreateOrder);
            Controls.Add(btnViewOrder);
            Controls.Add(lblOrder);
            Name = "Form1";
            Text = "s";
            panelConnection.ResumeLayout(false);
            panelConnection.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStart;
        private Label lblConnection;
        private Label lblOrder;
        private Button btnViewOrder;
        private Button btnCreateOrder;
        private Button btnDeleteOrder;
        private Button btnDeleteCustomer;
        private Button btnCreateCustomer;
        private Button btnViewCustomer;
        private Label lblCustomer;
        private Panel panelConnection;
        private ListView listOrder;
    }
}