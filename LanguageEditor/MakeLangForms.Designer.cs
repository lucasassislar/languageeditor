namespace LanguageEditor
{
    partial class MakeLangForms
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
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.btnSearchFolder = new System.Windows.Forms.Button();
            this.list_htmls = new System.Windows.Forms.ListBox();
            this.button_addHtml = new System.Windows.Forms.Button();
            this.button_Make = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtFolder
            // 
            this.txtFolder.Location = new System.Drawing.Point(12, 12);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(395, 29);
            this.txtFolder.TabIndex = 0;
            // 
            // btnSearchFolder
            // 
            this.btnSearchFolder.Location = new System.Drawing.Point(413, 12);
            this.btnSearchFolder.Name = "btnSearchFolder";
            this.btnSearchFolder.Size = new System.Drawing.Size(55, 29);
            this.btnSearchFolder.TabIndex = 1;
            this.btnSearchFolder.Text = "...";
            this.btnSearchFolder.UseVisualStyleBackColor = true;
            this.btnSearchFolder.Click += new System.EventHandler(this.btnSearchFolder_Click);
            // 
            // list_htmls
            // 
            this.list_htmls.FormattingEnabled = true;
            this.list_htmls.ItemHeight = 21;
            this.list_htmls.Location = new System.Drawing.Point(12, 74);
            this.list_htmls.Name = "list_htmls";
            this.list_htmls.Size = new System.Drawing.Size(456, 130);
            this.list_htmls.TabIndex = 2;
            // 
            // button_addHtml
            // 
            this.button_addHtml.Location = new System.Drawing.Point(368, 210);
            this.button_addHtml.Name = "button_addHtml";
            this.button_addHtml.Size = new System.Drawing.Size(100, 48);
            this.button_addHtml.TabIndex = 3;
            this.button_addHtml.Text = "Add HTML";
            this.button_addHtml.UseVisualStyleBackColor = true;
            this.button_addHtml.Click += new System.EventHandler(this.button_addHtml_Click);
            // 
            // button_Make
            // 
            this.button_Make.Location = new System.Drawing.Point(368, 360);
            this.button_Make.Name = "button_Make";
            this.button_Make.Size = new System.Drawing.Size(100, 48);
            this.button_Make.TabIndex = 4;
            this.button_Make.Text = "Make";
            this.button_Make.UseVisualStyleBackColor = true;
            this.button_Make.Click += new System.EventHandler(this.button_Make_Click);
            // 
            // MakeLangForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 483);
            this.Controls.Add(this.button_Make);
            this.Controls.Add(this.button_addHtml);
            this.Controls.Add(this.list_htmls);
            this.Controls.Add(this.btnSearchFolder);
            this.Controls.Add(this.txtFolder);
            this.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MakeLangForms";
            this.Text = "MakeLangForms";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.Button btnSearchFolder;
        private System.Windows.Forms.ListBox list_htmls;
        private System.Windows.Forms.Button button_addHtml;
        private System.Windows.Forms.Button button_Make;
    }
}