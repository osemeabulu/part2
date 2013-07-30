namespace fidelity2
{
    partial class helpMain
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
            this.SuspendLayout();
            // 
            // content
            // 
            this.content.Size = new System.Drawing.Size(472, 147);
            this.content.Text = "Help contains information on general tasks in the application. It also provides h" +
                "elp with navigation and input keys.\r\n\r\nClick on any topic to go to the relevant " +
                "help page.";
            // 
            // sectionTitle
            // 
            this.sectionTitle.Size = new System.Drawing.Size(147, 37);
            this.sectionTitle.Text = "Overview";
            // 
            // link1
            // 
            this.link1.Location = new System.Drawing.Point(47, 321);
            this.link1.Size = new System.Drawing.Size(245, 20);
            this.link1.Text = "Steps to create/edit a movie entry";
            // 
            // link2
            // 
            this.link2.Location = new System.Drawing.Point(47, 353);
            this.link2.Size = new System.Drawing.Size(158, 20);
            this.link2.Text = "Steps to Find a Entry";
            // 
            // link4
            // 
            this.link4.Location = new System.Drawing.Point(47, 385);
            this.link4.Size = new System.Drawing.Size(174, 20);
            this.link4.Text = "General navigation Info";
            // 
            // relevantSectionLabel
            // 
            this.relevantSectionLabel.Location = new System.Drawing.Point(25, 274);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(32, 325);
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(32, 357);
            // 
            // panel5
            // 
            this.panel5.Location = new System.Drawing.Point(32, 389);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(384, 370);
            // 
            // welcomeHelpLabel
            // 
            this.welcomeHelpLabel.Location = new System.Drawing.Point(27, 5);
            this.welcomeHelpLabel.Size = new System.Drawing.Size(491, 55);
            this.welcomeHelpLabel.Text = "Help Page - Overview";
            // 
            // helpMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(542, 428);
            this.Name = "helpMain";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
