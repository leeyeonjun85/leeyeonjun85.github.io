
namespace SeleniumTest
{
    partial class MainFrm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtbxMessage = new System.Windows.Forms.TextBox();
            this.btnRun = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lbShowCMD = new DevExpress.XtraEditors.LabelControl();
            this.lbShowBrows = new DevExpress.XtraEditors.LabelControl();
            this.tgbtnCmd = new DevExpress.XtraEditors.ToggleSwitch();
            this.tgbtnBrows = new DevExpress.XtraEditors.ToggleSwitch();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tgbtnCmd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tgbtnBrows.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.25F));
            this.tableLayoutPanel1.Controls.Add(this.txtbxMessage, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnRun, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.33334F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1029, 599);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtbxMessage
            // 
            this.txtbxMessage.BackColor = System.Drawing.SystemColors.Info;
            this.tableLayoutPanel1.SetColumnSpan(this.txtbxMessage, 2);
            this.txtbxMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtbxMessage.Font = new System.Drawing.Font("SUIT Light", 11F);
            this.txtbxMessage.Location = new System.Drawing.Point(4, 91);
            this.txtbxMessage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtbxMessage.Multiline = true;
            this.txtbxMessage.Name = "txtbxMessage";
            this.txtbxMessage.Size = new System.Drawing.Size(1021, 504);
            this.txtbxMessage.TabIndex = 0;
            this.txtbxMessage.Text = "■■ Message ■■";
            // 
            // btnRun
            // 
            this.btnRun.Appearance.Font = new System.Drawing.Font("SUIT ExtraBold", 12F, System.Drawing.FontStyle.Bold);
            this.btnRun.Appearance.Options.UseFont = true;
            this.btnRun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRun.Location = new System.Drawing.Point(4, 4);
            this.btnRun.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(555, 79);
            this.btnRun.TabIndex = 1;
            this.btnRun.Text = "Run~!";
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.67513F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.32487F));
            this.tableLayoutPanel2.Controls.Add(this.tgbtnBrows, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lbShowCMD, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbShowBrows, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tgbtnCmd, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(567, 4);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(458, 79);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // lbShowCMD
            // 
            this.lbShowCMD.Appearance.Font = new System.Drawing.Font("SUIT Medium", 10F, System.Drawing.FontStyle.Bold);
            this.lbShowCMD.Appearance.Options.UseFont = true;
            this.lbShowCMD.Appearance.Options.UseTextOptions = true;
            this.lbShowCMD.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbShowCMD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbShowCMD.Location = new System.Drawing.Point(4, 4);
            this.lbShowCMD.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbShowCMD.Name = "lbShowCMD";
            this.lbShowCMD.Size = new System.Drawing.Size(274, 31);
            this.lbShowCMD.TabIndex = 0;
            this.lbShowCMD.Text = "Show CMD";
            // 
            // lbShowBrows
            // 
            this.lbShowBrows.Appearance.Font = new System.Drawing.Font("SUIT Medium", 10F, System.Drawing.FontStyle.Bold);
            this.lbShowBrows.Appearance.Options.UseFont = true;
            this.lbShowBrows.Appearance.Options.UseTextOptions = true;
            this.lbShowBrows.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbShowBrows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbShowBrows.Location = new System.Drawing.Point(4, 43);
            this.lbShowBrows.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbShowBrows.Name = "lbShowBrows";
            this.lbShowBrows.Size = new System.Drawing.Size(274, 32);
            this.lbShowBrows.TabIndex = 1;
            this.lbShowBrows.Text = "Show Browser";
            // 
            // tgbtnCmd
            // 
            this.tgbtnCmd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tgbtnCmd.Location = new System.Drawing.Point(286, 4);
            this.tgbtnCmd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tgbtnCmd.Name = "tgbtnCmd";
            this.tgbtnCmd.Properties.Appearance.Font = new System.Drawing.Font("SUIT Light", 9F);
            this.tgbtnCmd.Properties.Appearance.Options.UseFont = true;
            this.tgbtnCmd.Properties.OffText = "Off";
            this.tgbtnCmd.Properties.OnText = "On";
            this.tgbtnCmd.Size = new System.Drawing.Size(168, 31);
            this.tgbtnCmd.TabIndex = 2;
            // 
            // tgbtnBrows
            // 
            this.tgbtnBrows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tgbtnBrows.EditValue = true;
            this.tgbtnBrows.Location = new System.Drawing.Point(286, 43);
            this.tgbtnBrows.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tgbtnBrows.Name = "tgbtnBrows";
            this.tgbtnBrows.Properties.Appearance.Font = new System.Drawing.Font("SUIT Light", 9F);
            this.tgbtnBrows.Properties.Appearance.Options.UseFont = true;
            this.tgbtnBrows.Properties.OffText = "Off";
            this.tgbtnBrows.Properties.OnText = "On";
            this.tgbtnBrows.Size = new System.Drawing.Size(168, 32);
            this.tgbtnBrows.TabIndex = 3;
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 599);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("SUIT Medium", 10F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainFrm";
            this.Text = "이연준의 Selenium 공부";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tgbtnCmd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tgbtnBrows.Properties)).EndInit();
            this.ResumeLayout(false);

        }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.TextBox txtbxMessage;
    private DevExpress.XtraEditors.SimpleButton btnRun;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    private DevExpress.XtraEditors.ToggleSwitch tgbtnBrows;
    private DevExpress.XtraEditors.LabelControl lbShowCMD;
    private DevExpress.XtraEditors.LabelControl lbShowBrows;
    private DevExpress.XtraEditors.ToggleSwitch tgbtnCmd;
  }
}

