namespace Digda
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
	        this.components = new System.ComponentModel.Container();
	        this.timer1 = new System.Windows.Forms.Timer(this.components);
	        this.start = new System.Windows.Forms.Button();
	        this.catchDigLbl = new System.Windows.Forms.Label();
	        this.missDigLbl = new System.Windows.Forms.Label();
	        this.levelLbl = new System.Windows.Forms.Label();
	        this.timeLbl = new System.Windows.Forms.Label();
	        this.modeLbl = new System.Windows.Forms.Label();
	        this.trackBar1 = new System.Windows.Forms.TrackBar();
	        this.label1 = new System.Windows.Forms.Label();
	        this.label2 = new System.Windows.Forms.Label();
	        this.label3 = new System.Windows.Forms.Label();
	        ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
	        this.SuspendLayout();
	        // 
	        // timer1
	        // 
	        this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
	        // 
	        // start
	        // 
	        this.start.Font = new System.Drawing.Font("NanumGothicExtraBold", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
	        this.start.Location = new System.Drawing.Point(197, 443);
	        this.start.Name = "start";
	        this.start.Size = new System.Drawing.Size(284, 114);
	        this.start.TabIndex = 2;
	        this.start.Text = "START";
	        this.start.UseVisualStyleBackColor = true;
	        this.start.Click += new System.EventHandler(this.button1_Click);
	        // 
	        // catchDigLbl
	        // 
	        this.catchDigLbl.AutoSize = true;
	        this.catchDigLbl.BackColor = System.Drawing.Color.White;
	        this.catchDigLbl.Font = new System.Drawing.Font("NanumGothicExtraBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
	        this.catchDigLbl.Location = new System.Drawing.Point(12, 9);
	        this.catchDigLbl.Name = "catchDigLbl";
	        this.catchDigLbl.Size = new System.Drawing.Size(101, 19);
	        this.catchDigLbl.TabIndex = 3;
	        this.catchDigLbl.Text = "잡은 두더지 : ";
	        // 
	        // missDigLbl
	        // 
	        this.missDigLbl.AutoSize = true;
	        this.missDigLbl.BackColor = System.Drawing.Color.White;
	        this.missDigLbl.Font = new System.Drawing.Font("NanumGothicExtraBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
	        this.missDigLbl.Location = new System.Drawing.Point(12, 38);
	        this.missDigLbl.Name = "missDigLbl";
	        this.missDigLbl.Size = new System.Drawing.Size(101, 19);
	        this.missDigLbl.TabIndex = 4;
	        this.missDigLbl.Text = "놓친 두더지 : ";
	        // 
	        // levelLbl
	        // 
	        this.levelLbl.AutoSize = true;
	        this.levelLbl.BackColor = System.Drawing.Color.White;
	        this.levelLbl.Font = new System.Drawing.Font("NanumGothicExtraBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
	        this.levelLbl.Location = new System.Drawing.Point(12, 67);
	        this.levelLbl.Name = "levelLbl";
	        this.levelLbl.Size = new System.Drawing.Size(52, 19);
	        this.levelLbl.TabIndex = 5;
	        this.levelLbl.Text = "레벨 : ";
	        // 
	        // timeLbl
	        // 
	        this.timeLbl.AutoSize = true;
	        this.timeLbl.BackColor = System.Drawing.Color.White;
	        this.timeLbl.Font = new System.Drawing.Font("NanumGothicExtraBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
	        this.timeLbl.Location = new System.Drawing.Point(12, 98);
	        this.timeLbl.Name = "timeLbl";
	        this.timeLbl.Size = new System.Drawing.Size(79, 19);
	        this.timeLbl.TabIndex = 6;
	        this.timeLbl.Text = "시간(초) : ";
	        // 
	        // modeLbl
	        // 
	        this.modeLbl.AutoSize = true;
	        this.modeLbl.BackColor = System.Drawing.Color.White;
	        this.modeLbl.Font = new System.Drawing.Font("NanumGothicExtraBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
	        this.modeLbl.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
	        this.modeLbl.Location = new System.Drawing.Point(607, 9);
	        this.modeLbl.Name = "modeLbl";
	        this.modeLbl.Size = new System.Drawing.Size(65, 19);
	        this.modeLbl.TabIndex = 7;
	        this.modeLbl.Text = "Normal";
	        this.modeLbl.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
	        // 
	        // trackBar1
	        // 
	        this.trackBar1.AllowDrop = true;
	        this.trackBar1.BackColor = System.Drawing.Color.White;
	        this.trackBar1.Location = new System.Drawing.Point(197, 563);
	        this.trackBar1.Maximum = 3;
	        this.trackBar1.Minimum = 1;
	        this.trackBar1.Name = "trackBar1";
	        this.trackBar1.Size = new System.Drawing.Size(284, 45);
	        this.trackBar1.TabIndex = 8;
	        this.trackBar1.Value = 2;
	        this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
	        // 
	        // label1
	        // 
	        this.label1.AutoSize = true;
	        this.label1.BackColor = System.Drawing.Color.White;
	        this.label1.Font = new System.Drawing.Font("NanumGothicExtraBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
	        this.label1.Location = new System.Drawing.Point(193, 611);
	        this.label1.Name = "label1";
	        this.label1.Size = new System.Drawing.Size(41, 19);
	        this.label1.TabIndex = 9;
	        this.label1.Text = "Easy";
	        this.label1.Click += new System.EventHandler(this.label1_Click);
	        // 
	        // label2
	        // 
	        this.label2.AutoSize = true;
	        this.label2.BackColor = System.Drawing.Color.White;
	        this.label2.Font = new System.Drawing.Font("NanumGothicExtraBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
	        this.label2.Location = new System.Drawing.Point(308, 611);
	        this.label2.Name = "label2";
	        this.label2.Size = new System.Drawing.Size(65, 19);
	        this.label2.TabIndex = 10;
	        this.label2.Text = "Normal";
	        // 
	        // label3
	        // 
	        this.label3.AutoSize = true;
	        this.label3.BackColor = System.Drawing.Color.White;
	        this.label3.Font = new System.Drawing.Font("NanumGothicExtraBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
	        this.label3.Location = new System.Drawing.Point(440, 611);
	        this.label3.Name = "label3";
	        this.label3.Size = new System.Drawing.Size(46, 19);
	        this.label3.TabIndex = 11;
	        this.label3.Text = "Hard";
	        // 
	        // Form1
	        // 
	        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
	        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	        this.ClientSize = new System.Drawing.Size(684, 662);
	        this.Controls.Add(this.label3);
	        this.Controls.Add(this.label2);
	        this.Controls.Add(this.label1);
	        this.Controls.Add(this.trackBar1);
	        this.Controls.Add(this.modeLbl);
	        this.Controls.Add(this.timeLbl);
	        this.Controls.Add(this.levelLbl);
	        this.Controls.Add(this.missDigLbl);
	        this.Controls.Add(this.catchDigLbl);
	        this.Controls.Add(this.start);
	        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
	        this.Name = "Form1";
	        this.Text = "    ";
	        this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
	        ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
	        this.ResumeLayout(false);
	        this.PerformLayout();

	}

	#endregion

	private System.Windows.Forms.Timer timer1;
	private System.Windows.Forms.Button start;
	private System.Windows.Forms.Label catchDigLbl;
	private System.Windows.Forms.Label missDigLbl;
	private System.Windows.Forms.Label levelLbl;
	private System.Windows.Forms.Label timeLbl;
	private System.Windows.Forms.Label modeLbl;
	private System.Windows.Forms.TrackBar trackBar1;
	private System.Windows.Forms.Label label1;
	private System.Windows.Forms.Label label2;
	private System.Windows.Forms.Label label3;
        }
}

