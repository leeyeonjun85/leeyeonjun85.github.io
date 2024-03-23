namespace ocrTest
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOCR = new System.Windows.Forms.Button();
            this.tbxLog = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pbxImage = new System.Windows.Forms.PictureBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnOpenFileDialog = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImage)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOCR
            // 
            this.btnOCR.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.tableLayoutPanel1.SetColumnSpan(this.btnOCR, 2);
            this.btnOCR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOCR.Location = new System.Drawing.Point(5, 48);
            this.btnOCR.Margin = new System.Windows.Forms.Padding(5);
            this.btnOCR.Name = "btnOCR";
            this.btnOCR.Size = new System.Drawing.Size(290, 33);
            this.btnOCR.TabIndex = 2;
            this.btnOCR.Text = "Run OCR!!";
            this.btnOCR.UseVisualStyleBackColor = false;
            this.btnOCR.Click += new System.EventHandler(this.BtnOCR_Click);
            // 
            // tbxLog
            // 
            this.tbxLog.BackColor = System.Drawing.SystemColors.Info;
            this.tableLayoutPanel1.SetColumnSpan(this.tbxLog, 2);
            this.tbxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxLog.Location = new System.Drawing.Point(5, 91);
            this.tbxLog.Margin = new System.Windows.Forms.Padding(5);
            this.tbxLog.Multiline = true;
            this.tbxLog.Name = "tbxLog";
            this.tbxLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbxLog.Size = new System.Drawing.Size(290, 334);
            this.tbxLog.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.btnOCR, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pbxImage, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbxLog, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnOpenFileDialog, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.statusStrip1, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // pbxImage
            // 
            this.pbxImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxImage.Location = new System.Drawing.Point(303, 3);
            this.pbxImage.Name = "pbxImage";
            this.tableLayoutPanel1.SetRowSpan(this.pbxImage, 3);
            this.pbxImage.Size = new System.Drawing.Size(494, 424);
            this.pbxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbxImage.TabIndex = 6;
            this.pbxImage.TabStop = false;
            // 
            // textBox2
            // 
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox2.Location = new System.Drawing.Point(10, 10);
            this.textBox2.Margin = new System.Windows.Forms.Padding(10);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(230, 21);
            this.textBox2.TabIndex = 7;
            // 
            // btnOpenFileDialog
            // 
            this.btnOpenFileDialog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOpenFileDialog.Location = new System.Drawing.Point(260, 10);
            this.btnOpenFileDialog.Margin = new System.Windows.Forms.Padding(10);
            this.btnOpenFileDialog.Name = "btnOpenFileDialog";
            this.btnOpenFileDialog.Size = new System.Drawing.Size(30, 23);
            this.btnOpenFileDialog.TabIndex = 8;
            this.btnOpenFileDialog.Text = "...";
            this.btnOpenFileDialog.UseVisualStyleBackColor = true;
            this.btnOpenFileDialog.Click += new System.EventHandler(this.BtnOpenFileDialog_Click);
            // 
            // statusStrip1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.statusStrip1, 3);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbStatus,
            this.progressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 430);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 20);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lbStatus
            // 
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(83, 15);
            this.lbStatus.Text = "Status : Ready";
            // 
            // progressBar1
            // 
            this.progressBar1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(150, 14);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImage)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

    #endregion
    private System.Windows.Forms.Button btnOCR;
    private System.Windows.Forms.TextBox tbxLog;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.PictureBox pbxImage;
    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.Button btnOpenFileDialog;
    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.ToolStripProgressBar progressBar1;
    private System.Windows.Forms.ToolStripStatusLabel lbStatus;
  }
}

