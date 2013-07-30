namespace fidelity2
{
    partial class FormOutline
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
            this.titleText = new System.Windows.Forms.Label();
            this.wideViewTop = new System.Windows.Forms.Panel();
            this.wideViewText = new System.Windows.Forms.Label();
            this.wideViewPanel = new System.Windows.Forms.Panel();
            this.endingPanel = new System.Windows.Forms.Panel();
            this.wideViewTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleText
            // 
            this.titleText.AutoSize = true;
            this.titleText.BackColor = System.Drawing.Color.DarkOrange;
            this.titleText.Font = new System.Drawing.Font("Verdana", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleText.ForeColor = System.Drawing.Color.Black;
            this.titleText.Location = new System.Drawing.Point(437, 104);
            this.titleText.Name = "titleText";
            this.titleText.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.titleText.Size = new System.Drawing.Size(105, 45);
            this.titleText.TabIndex = 7;
            this.titleText.Text = "title ";
            // 
            // wideViewTop
            // 
            this.wideViewTop.BackColor = System.Drawing.Color.DarkSlateGray;
            this.wideViewTop.Controls.Add(this.wideViewText);
            this.wideViewTop.Location = new System.Drawing.Point(0, 523);
            this.wideViewTop.Name = "wideViewTop";
            this.wideViewTop.Size = new System.Drawing.Size(266, 27);
            this.wideViewTop.TabIndex = 9;
            this.wideViewTop.Tag = "";
            // 
            // wideViewText
            // 
            this.wideViewText.AutoSize = true;
            this.wideViewText.BackColor = System.Drawing.Color.Transparent;
            this.wideViewText.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wideViewText.ForeColor = System.Drawing.Color.DarkOrange;
            this.wideViewText.Location = new System.Drawing.Point(31, 3);
            this.wideViewText.Name = "wideViewText";
            this.wideViewText.Size = new System.Drawing.Size(222, 23);
            this.wideViewText.TabIndex = 11;
            this.wideViewText.Text = "Wide View (Clickable)";
            // 
            // wideViewPanel
            // 
            this.wideViewPanel.BackColor = System.Drawing.Color.DarkOrange;
            this.wideViewPanel.Location = new System.Drawing.Point(1, 550);
            this.wideViewPanel.Name = "wideViewPanel";
            this.wideViewPanel.Size = new System.Drawing.Size(265, 80);
            this.wideViewPanel.TabIndex = 10;
            this.wideViewPanel.Tag = "";
            // 
            // endingPanel
            // 
            this.endingPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.endingPanel.BackColor = System.Drawing.Color.DarkSlateGray;
            this.endingPanel.Location = new System.Drawing.Point(0, 0);
            this.endingPanel.Name = "endingPanel";
            this.endingPanel.Size = new System.Drawing.Size(53, 21);
            this.endingPanel.TabIndex = 11;
            this.endingPanel.UseWaitCursor = true;
            this.endingPanel.Visible = false;
            // 
            // FormOutline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 631);
            this.Controls.Add(this.endingPanel);
            this.Controls.Add(this.wideViewPanel);
            this.Controls.Add(this.wideViewTop);
            this.Controls.Add(this.titleText);
            this.Name = "FormOutline";
            this.Text = "FormOutline";
            this.wideViewTop.ResumeLayout(false);
            this.wideViewTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Label titleText;
        private System.Windows.Forms.Label wideViewText;
        protected System.Windows.Forms.Panel wideViewTop;
        protected System.Windows.Forms.Panel wideViewPanel;
        protected System.Windows.Forms.Panel endingPanel;

    }
}