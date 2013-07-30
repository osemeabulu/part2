namespace fidelity2
{
    partial class createHelpPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(createHelpPage));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // content
            // 
            this.content.Size = new System.Drawing.Size(472, 121);
            this.content.Text = "1. When on the home screen, click create\r\n2. Fill in the criteria\r\n        -you m" +
                "ust have a year and date specified\r\n        -also a title must be specified\r\n3. " +
                "Click save\r\n";
            // 
            // sectionTitle
            // 
            this.sectionTitle.Size = new System.Drawing.Size(313, 37);
            this.sectionTitle.Text = "Creating Movie Entry";
            // 
            // link1
            // 
            this.link1.Location = new System.Drawing.Point(47, 530);
            this.link1.Size = new System.Drawing.Size(196, 20);
            this.link1.Text = "Steps to find a movie entry";
            // 
            // link2
            // 
            this.link2.Location = new System.Drawing.Point(47, 562);
            this.link2.Size = new System.Drawing.Size(176, 20);
            this.link2.Text = "General Navigation Info";
            // 
            // link4
            // 
            this.link4.Location = new System.Drawing.Point(47, 593);
            this.link4.Size = new System.Drawing.Size(72, 20);
            this.link4.Text = "Overview";
            // 
            // relevantSectionLabel
            // 
            this.relevantSectionLabel.Location = new System.Drawing.Point(25, 485);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(32, 534);
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(32, 566);
            // 
            // panel5
            // 
            this.panel5.Location = new System.Drawing.Point(32, 601);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(384, 579);
            // 
            // welcomeHelpLabel
            // 
            this.welcomeHelpLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeHelpLabel.Location = new System.Drawing.Point(47, 9);
            this.welcomeHelpLabel.Size = new System.Drawing.Size(431, 42);
            this.welcomeHelpLabel.Text = "Help Page - Create / Edit";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 242);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(317, 37);
            this.label1.TabIndex = 15;
            this.label1.Text = "Editing a Movie Entry";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Wheat;
            this.textBox1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(32, 283);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(455, 193);
            this.textBox1.TabIndex = 16;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // createHelpPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 637);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "createHelpPage";
            this.Text = "createHelpPage";
            this.Controls.SetChildIndex(this.textBox1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.content, 0);
            this.Controls.SetChildIndex(this.sectionTitle, 0);
            this.Controls.SetChildIndex(this.link1, 0);
            this.Controls.SetChildIndex(this.link2, 0);
            this.Controls.SetChildIndex(this.relevantSectionLabel, 0);
            this.Controls.SetChildIndex(this.link4, 0);
            this.Controls.SetChildIndex(this.closeButton, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.panel5, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}