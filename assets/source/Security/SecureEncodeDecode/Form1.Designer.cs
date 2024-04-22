namespace SecureEncodeDecode
{
  partial class Form1
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
      tabControl1 = new TabControl();
      tabPage1 = new TabPage();
      tabPage2 = new TabPage();
      tableLayoutPanel1 = new TableLayoutPanel();
      statusStrip1 = new StatusStrip();
      tableLayoutPanel2 = new TableLayoutPanel();
      textBox1 = new TextBox();
      button1 = new Button();
      textBox2 = new TextBox();
      button2 = new Button();
      textBox3 = new TextBox();
      button3 = new Button();
      tabControl1.SuspendLayout();
      tabPage1.SuspendLayout();
      tableLayoutPanel1.SuspendLayout();
      tableLayoutPanel2.SuspendLayout();
      SuspendLayout();
      // 
      // tabControl1
      // 
      tabControl1.Controls.Add(tabPage1);
      tabControl1.Controls.Add(tabPage2);
      tabControl1.Dock = DockStyle.Fill;
      tabControl1.Location = new Point(3, 83);
      tabControl1.Name = "tabControl1";
      tabControl1.SelectedIndex = 0;
      tabControl1.Size = new Size(794, 334);
      tabControl1.TabIndex = 0;
      // 
      // tabPage1
      // 
      tabPage1.Controls.Add(tableLayoutPanel2);
      tabPage1.Location = new Point(4, 24);
      tabPage1.Name = "tabPage1";
      tabPage1.Padding = new Padding(3);
      tabPage1.Size = new Size(786, 306);
      tabPage1.TabIndex = 0;
      tabPage1.Text = "tabPage1";
      tabPage1.UseVisualStyleBackColor = true;
      // 
      // tabPage2
      // 
      tabPage2.Location = new Point(4, 24);
      tabPage2.Name = "tabPage2";
      tabPage2.Padding = new Padding(3);
      tabPage2.Size = new Size(192, 72);
      tabPage2.TabIndex = 1;
      tabPage2.Text = "tabPage2";
      tabPage2.UseVisualStyleBackColor = true;
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.ColumnCount = 1;
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.Controls.Add(tabControl1, 0, 1);
      tableLayoutPanel1.Controls.Add(statusStrip1, 0, 2);
      tableLayoutPanel1.Dock = DockStyle.Fill;
      tableLayoutPanel1.Location = new Point(0, 0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 3;
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
      tableLayoutPanel1.Size = new Size(800, 450);
      tableLayoutPanel1.TabIndex = 1;
      // 
      // statusStrip1
      // 
      statusStrip1.Dock = DockStyle.Fill;
      statusStrip1.Location = new Point(0, 420);
      statusStrip1.Name = "statusStrip1";
      statusStrip1.Size = new Size(800, 30);
      statusStrip1.TabIndex = 1;
      statusStrip1.Text = "statusStrip1";
      // 
      // tableLayoutPanel2
      // 
      tableLayoutPanel2.ColumnCount = 2;
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 67.05128F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32.94872F));
      tableLayoutPanel2.Controls.Add(button2, 1, 1);
      tableLayoutPanel2.Controls.Add(textBox2, 0, 1);
      tableLayoutPanel2.Controls.Add(textBox1, 0, 0);
      tableLayoutPanel2.Controls.Add(button1, 1, 0);
      tableLayoutPanel2.Controls.Add(button3, 1, 2);
      tableLayoutPanel2.Controls.Add(textBox3, 0, 2);
      tableLayoutPanel2.Dock = DockStyle.Fill;
      tableLayoutPanel2.Location = new Point(3, 3);
      tableLayoutPanel2.Name = "tableLayoutPanel2";
      tableLayoutPanel2.RowCount = 4;
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel2.Size = new Size(780, 300);
      tableLayoutPanel2.TabIndex = 0;
      // 
      // textBox1
      // 
      textBox1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      textBox1.Location = new Point(3, 3);
      textBox1.Name = "textBox1";
      textBox1.Size = new Size(516, 23);
      textBox1.TabIndex = 0;
      // 
      // button1
      // 
      button1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      button1.Location = new Point(525, 3);
      button1.Name = "button1";
      button1.Size = new Size(252, 23);
      button1.TabIndex = 1;
      button1.Text = "button1";
      button1.UseVisualStyleBackColor = true;
      button1.Click += button1_Click;
      // 
      // textBox2
      // 
      textBox2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      textBox2.Location = new Point(3, 33);
      textBox2.Name = "textBox2";
      textBox2.Size = new Size(516, 23);
      textBox2.TabIndex = 2;
      // 
      // button2
      // 
      button2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      button2.Location = new Point(525, 33);
      button2.Name = "button2";
      button2.Size = new Size(252, 23);
      button2.TabIndex = 3;
      button2.Text = "button2";
      button2.UseVisualStyleBackColor = true;
      // 
      // textBox3
      // 
      textBox3.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      textBox3.Location = new Point(3, 63);
      textBox3.Name = "textBox3";
      textBox3.Size = new Size(516, 23);
      textBox3.TabIndex = 4;
      // 
      // button3
      // 
      button3.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      button3.Location = new Point(525, 63);
      button3.Name = "button3";
      button3.Size = new Size(252, 23);
      button3.TabIndex = 5;
      button3.Text = "button3";
      button3.UseVisualStyleBackColor = true;
      // 
      // Form1
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(800, 450);
      Controls.Add(tableLayoutPanel1);
      Name = "Form1";
      Text = "Form1";
      tabControl1.ResumeLayout(false);
      tabPage1.ResumeLayout(false);
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel1.PerformLayout();
      tableLayoutPanel2.ResumeLayout(false);
      tableLayoutPanel2.PerformLayout();
      ResumeLayout(false);
    }

    #endregion

    private TabControl tabControl1;
    private TabPage tabPage1;
    private TabPage tabPage2;
    private TableLayoutPanel tableLayoutPanel1;
    private StatusStrip statusStrip1;
    private TableLayoutPanel tableLayoutPanel2;
    private Button button2;
    private TextBox textBox2;
    private TextBox textBox1;
    private Button button1;
    private Button button3;
    private TextBox textBox3;
  }
}
