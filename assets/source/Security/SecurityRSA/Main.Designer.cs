
namespace SecurityRSA
{
    partial class Main
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
            this.tbxMessage = new System.Windows.Forms.TextBox();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnGetPublicKey = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lbNomalText = new System.Windows.Forms.Label();
            this.tbxNomalText = new System.Windows.Forms.TextBox();
            this.lbPrivateKey = new System.Windows.Forms.Label();
            this.tbxPrivateKey = new System.Windows.Forms.TextBox();
            this.tbxEncryptText = new System.Windows.Forms.TextBox();
            this.lbEncryptText = new System.Windows.Forms.Label();
            this.lbPublicKey = new System.Windows.Forms.Label();
            this.tbxPublicKey = new System.Windows.Forms.TextBox();
            this.btnGetPrivateKey = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.tbxMessage, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnDecrypt, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnEncrypt, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnGetPublicKey, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnGetPrivateKey, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("굴림", 10F);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tbxMessage
            // 
            this.tbxMessage.BackColor = System.Drawing.SystemColors.Info;
            this.tableLayoutPanel1.SetColumnSpan(this.tbxMessage, 2);
            this.tbxMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxMessage.Location = new System.Drawing.Point(3, 183);
            this.tbxMessage.Multiline = true;
            this.tbxMessage.Name = "tbxMessage";
            this.tbxMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxMessage.Size = new System.Drawing.Size(794, 264);
            this.tbxMessage.TabIndex = 5;
            this.tbxMessage.Text = "■ Input Text and Run~!";
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDecrypt.Location = new System.Drawing.Point(643, 138);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(154, 39);
            this.btnDecrypt.TabIndex = 4;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEncrypt.Location = new System.Drawing.Point(643, 93);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(154, 39);
            this.btnEncrypt.TabIndex = 2;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // btnGetPublicKey
            // 
            this.btnGetPublicKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGetPublicKey.Location = new System.Drawing.Point(643, 3);
            this.btnGetPublicKey.Name = "btnGetPublicKey";
            this.btnGetPublicKey.Size = new System.Drawing.Size(154, 39);
            this.btnGetPublicKey.TabIndex = 7;
            this.btnGetPublicKey.Text = "Get Public Key";
            this.btnGetPublicKey.UseVisualStyleBackColor = true;
            this.btnGetPublicKey.Click += new System.EventHandler(this.btnGetPublicKey_Click_1);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.LavenderBlush;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel2.Controls.Add(this.lbNomalText, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tbxNomalText, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbPrivateKey, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.tbxPrivateKey, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.tbxEncryptText, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.lbEncryptText, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lbPublicKey, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tbxPublicKey, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel1.SetRowSpan(this.tableLayoutPanel2, 4);
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(634, 174);
            this.tableLayoutPanel2.TabIndex = 11;
            // 
            // lbNomalText
            // 
            this.lbNomalText.AutoSize = true;
            this.lbNomalText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbNomalText.Location = new System.Drawing.Point(3, 0);
            this.lbNomalText.Name = "lbNomalText";
            this.lbNomalText.Size = new System.Drawing.Size(120, 43);
            this.lbNomalText.TabIndex = 8;
            this.lbNomalText.Text = "Nomal Text";
            this.lbNomalText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbxNomalText
            // 
            this.tbxNomalText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxNomalText.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbxNomalText.Location = new System.Drawing.Point(129, 3);
            this.tbxNomalText.Multiline = true;
            this.tbxNomalText.Name = "tbxNomalText";
            this.tbxNomalText.Size = new System.Drawing.Size(502, 37);
            this.tbxNomalText.TabIndex = 0;
            // 
            // lbPrivateKey
            // 
            this.lbPrivateKey.AutoSize = true;
            this.lbPrivateKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbPrivateKey.Location = new System.Drawing.Point(3, 129);
            this.lbPrivateKey.Name = "lbPrivateKey";
            this.lbPrivateKey.Size = new System.Drawing.Size(120, 45);
            this.lbPrivateKey.TabIndex = 10;
            this.lbPrivateKey.Text = "Private Key";
            this.lbPrivateKey.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbxPrivateKey
            // 
            this.tbxPrivateKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxPrivateKey.Location = new System.Drawing.Point(129, 132);
            this.tbxPrivateKey.Multiline = true;
            this.tbxPrivateKey.Name = "tbxPrivateKey";
            this.tbxPrivateKey.Size = new System.Drawing.Size(502, 39);
            this.tbxPrivateKey.TabIndex = 6;
            // 
            // tbxEncryptText
            // 
            this.tbxEncryptText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxEncryptText.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbxEncryptText.Location = new System.Drawing.Point(129, 89);
            this.tbxEncryptText.Multiline = true;
            this.tbxEncryptText.Name = "tbxEncryptText";
            this.tbxEncryptText.Size = new System.Drawing.Size(502, 37);
            this.tbxEncryptText.TabIndex = 3;
            // 
            // lbEncryptText
            // 
            this.lbEncryptText.AutoSize = true;
            this.lbEncryptText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbEncryptText.Location = new System.Drawing.Point(3, 86);
            this.lbEncryptText.Name = "lbEncryptText";
            this.lbEncryptText.Size = new System.Drawing.Size(120, 43);
            this.lbEncryptText.TabIndex = 9;
            this.lbEncryptText.Text = "Encrypt Text";
            this.lbEncryptText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbPublicKey
            // 
            this.lbPublicKey.AutoSize = true;
            this.lbPublicKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbPublicKey.Location = new System.Drawing.Point(3, 43);
            this.lbPublicKey.Name = "lbPublicKey";
            this.lbPublicKey.Size = new System.Drawing.Size(120, 43);
            this.lbPublicKey.TabIndex = 11;
            this.lbPublicKey.Text = "Public Key";
            this.lbPublicKey.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbxPublicKey
            // 
            this.tbxPublicKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxPublicKey.Location = new System.Drawing.Point(129, 46);
            this.tbxPublicKey.Multiline = true;
            this.tbxPublicKey.Name = "tbxPublicKey";
            this.tbxPublicKey.Size = new System.Drawing.Size(502, 37);
            this.tbxPublicKey.TabIndex = 12;
            // 
            // btnGetPrivateKey
            // 
            this.btnGetPrivateKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGetPrivateKey.Location = new System.Drawing.Point(643, 48);
            this.btnGetPrivateKey.Name = "btnGetPrivateKey";
            this.btnGetPrivateKey.Size = new System.Drawing.Size(154, 39);
            this.btnGetPrivateKey.TabIndex = 12;
            this.btnGetPrivateKey.Text = "Get Private Key";
            this.btnGetPrivateKey.UseVisualStyleBackColor = true;
            this.btnGetPrivateKey.Click += new System.EventHandler(this.btnGetPrivateKey_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Main";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.TextBox tbxNomalText;
    private System.Windows.Forms.TextBox tbxEncryptText;
    private System.Windows.Forms.TextBox tbxMessage;
    private System.Windows.Forms.TextBox tbxPrivateKey;
    private System.Windows.Forms.Label lbPrivateKey;
    private System.Windows.Forms.Label lbEncryptText;
    private System.Windows.Forms.Label lbNomalText;
    private System.Windows.Forms.Button btnDecrypt;
    private System.Windows.Forms.Button btnEncrypt;
    private System.Windows.Forms.Button btnGetPublicKey;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    private System.Windows.Forms.Label lbPublicKey;
    private System.Windows.Forms.TextBox tbxPublicKey;
    private System.Windows.Forms.Button btnGetPrivateKey;
  }
}

