namespace Challenge_11_Develop_a_Windows_Form_Project_to_Display_HTML
{
    partial class Form1
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
            this.buttonDowload = new System.Windows.Forms.Button();
            this.textBoxUrl = new System.Windows.Forms.TextBox();
            this.labelViewHtml = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonDowload
            // 
            this.buttonDowload.Location = new System.Drawing.Point(396, 12);
            this.buttonDowload.Name = "buttonDowload";
            this.buttonDowload.Size = new System.Drawing.Size(131, 31);
            this.buttonDowload.TabIndex = 0;
            this.buttonDowload.Text = "Download";
            this.buttonDowload.UseVisualStyleBackColor = true;
            this.buttonDowload.Click += new System.EventHandler(this.buttonDowload_Click);
            // 
            // textBoxUrl
            // 
            this.textBoxUrl.Location = new System.Drawing.Point(12, 18);
            this.textBoxUrl.Name = "textBoxUrl";
            this.textBoxUrl.Size = new System.Drawing.Size(378, 20);
            this.textBoxUrl.TabIndex = 1;
            // 
            // labelViewHtml
            // 
            this.labelViewHtml.Location = new System.Drawing.Point(12, 46);
            this.labelViewHtml.Name = "labelViewHtml";
            this.labelViewHtml.Size = new System.Drawing.Size(513, 561);
            this.labelViewHtml.TabIndex = 2;
            this.labelViewHtml.Text = "Here must be the downloaded html";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 616);
            this.Controls.Add(this.labelViewHtml);
            this.Controls.Add(this.textBoxUrl);
            this.Controls.Add(this.buttonDowload);
            this.Name = "Form1";
            this.Text = "HtmlDownloader";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonDowload;
        private System.Windows.Forms.TextBox textBoxUrl;
        private System.Windows.Forms.Label labelViewHtml;
    }
}

