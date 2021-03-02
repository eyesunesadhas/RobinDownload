
namespace RobinHoodDownload
{
    partial class RobinDownload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RobinDownload));
            this.SBar = new System.Windows.Forms.StatusStrip();
            this.lblMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.panHeader = new System.Windows.Forms.Panel();
            this.BtnExcelExport = new System.Windows.Forms.Button();
            this.RobinKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SBar.SuspendLayout();
            this.panHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // SBar
            // 
            this.SBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMessage});
            this.SBar.Location = new System.Drawing.Point(0, 63);
            this.SBar.Name = "SBar";
            this.SBar.Size = new System.Drawing.Size(955, 22);
            this.SBar.TabIndex = 1;
            this.SBar.Text = "statusStrip1";
            // 
            // lblMessage
            // 
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(39, 17);
            this.lblMessage.Text = "Ready";
            // 
            // panHeader
            // 
            this.panHeader.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panHeader.BackgroundImage")));
            this.panHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panHeader.Controls.Add(this.BtnExcelExport);
            this.panHeader.Controls.Add(this.RobinKey);
            this.panHeader.Controls.Add(this.label1);
            this.panHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panHeader.Location = new System.Drawing.Point(0, 0);
            this.panHeader.Name = "panHeader";
            this.panHeader.Size = new System.Drawing.Size(955, 63);
            this.panHeader.TabIndex = 2;
            // 
            // BtnExcelExport
            // 
            this.BtnExcelExport.Image = ((System.Drawing.Image)(resources.GetObject("BtnExcelExport.Image")));
            this.BtnExcelExport.Location = new System.Drawing.Point(908, 11);
            this.BtnExcelExport.Name = "BtnExcelExport";
            this.BtnExcelExport.Size = new System.Drawing.Size(35, 34);
            this.BtnExcelExport.TabIndex = 2;
            this.BtnExcelExport.UseVisualStyleBackColor = true;
            this.BtnExcelExport.Click += new System.EventHandler(this.ToolExcel_Click);
            // 
            // RobinKey
            // 
            this.RobinKey.Location = new System.Drawing.Point(54, 17);
            this.RobinKey.Name = "RobinKey";
            this.RobinKey.Size = new System.Drawing.Size(848, 23);
            this.RobinKey.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(8, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bearer";
            // 
            // RobinDownload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 85);
            this.Controls.Add(this.panHeader);
            this.Controls.Add(this.SBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RobinDownload";
            this.Text = "Robin Download";
            this.SBar.ResumeLayout(false);
            this.SBar.PerformLayout();
            this.panHeader.ResumeLayout(false);
            this.panHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip SBar;
        private System.Windows.Forms.ToolStripStatusLabel lblMessage;
        private System.Windows.Forms.Panel panHeader;
        private System.Windows.Forms.TextBox RobinKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnExcelExport;
    }
}

