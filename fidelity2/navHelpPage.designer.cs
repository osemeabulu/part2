namespace fidelity2
{
    partial class navHelpPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(navHelpPage));
            this.SuspendLayout();
            // 
            // content
            // 
            this.content.Size = new System.Drawing.Size(472, 332);
            this.content.Text = resources.GetString("content.Text");
            // 
            // sectionTitle
            // 
            this.sectionTitle.Size = new System.Drawing.Size(291, 37);
            this.sectionTitle.Text = "General Navigation";
            // 
            // link1
            // 
            this.link1.Location = new System.Drawing.Point(47, 501);
            this.link1.Size = new System.Drawing.Size(245, 20);
            this.link1.Text = "Steps to create/edit a movie entry";
            // 
            // link2
            // 
            this.link2.Location = new System.Drawing.Point(47, 533);
            this.link2.Size = new System.Drawing.Size(196, 20);
            this.link2.Text = "Steps to find a movie entry";
            // 
            // link4
            // 
            this.link4.Location = new System.Drawing.Point(47, 564);
            this.link4.Size = new System.Drawing.Size(72, 20);
            this.link4.Text = "Overview";
            // 
            // relevantSectionLabel
            // 
            this.relevantSectionLabel.Location = new System.Drawing.Point(25, 455);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(32, 505);
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(32, 537);
            // 
            // panel5
            // 
            this.panel5.Location = new System.Drawing.Point(32, 572);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(384, 550);
            // 
            // welcomeHelpLabel
            // 
            this.welcomeHelpLabel.Location = new System.Drawing.Point(8, 5);
            this.welcomeHelpLabel.Size = new System.Drawing.Size(518, 55);
            this.welcomeHelpLabel.Text = "Help Page - Navigation";
            // 
            // navHelpPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 607);
            this.Name = "navHelpPage";
            this.Text = "generalNavigationHelp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}