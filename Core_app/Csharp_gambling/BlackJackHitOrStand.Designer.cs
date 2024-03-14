namespace csharp_gambling
{
    partial class BlackJackHitOrStand
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
            lblTitle = new Label();
            btnHit = new Button();
            btnStand = new Button();
            btnDoubleDown = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(221, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(83, 15);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "HIT OR STAND";
            // 
            // btnHit
            // 
            btnHit.Location = new Point(12, 92);
            btnHit.Name = "btnHit";
            btnHit.Size = new Size(140, 62);
            btnHit.TabIndex = 1;
            btnHit.Text = "HIT";
            btnHit.UseVisualStyleBackColor = true;
            btnHit.Click += btnHit_Click;
            // 
            // btnStand
            // 
            btnStand.Location = new Point(202, 92);
            btnStand.Name = "btnStand";
            btnStand.Size = new Size(140, 62);
            btnStand.TabIndex = 2;
            btnStand.Text = "STAND";
            btnStand.UseVisualStyleBackColor = true;
            btnStand.Click += btnStand_Click;
            // 
            // btnDoubleDown
            // 
            btnDoubleDown.Location = new Point(365, 92);
            btnDoubleDown.Name = "btnDoubleDown";
            btnDoubleDown.Size = new Size(140, 62);
            btnDoubleDown.TabIndex = 3;
            btnDoubleDown.Text = "DOUBLE DOWN";
            btnDoubleDown.UseVisualStyleBackColor = true;
            btnDoubleDown.Click += btnDoubleDown_Click;
            // 
            // BlackJackHitOrStand
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(549, 233);
            Controls.Add(btnDoubleDown);
            Controls.Add(btnStand);
            Controls.Add(btnHit);
            Controls.Add(lblTitle);
            Name = "BlackJackHitOrStand";
            Text = "BlackJackHitOrStand";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Button btnHit;
        private Button btnStand;
        private Button btnDoubleDown;
    }
}