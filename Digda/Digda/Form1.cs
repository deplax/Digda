using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digda
{
        public partial class Form1 : Form
        {
	Random r = new Random();

	/////////////////////////////////////////////////////////////////////////////////////////
	List<Digda> digdig = new List<Digda>();
	List<Dirt> dirt = new List<Dirt>();
	//int count = 0;
	int allDigda;
	int score;
	int level;

	int startTime;
	int currentTime;

	int gameStatFlag = 0;		//0 Main     1 Run     -1 Finish

	public Form1()
	{
	        InitializeComponent();

	        score = 0;
	        allDigda = 0;
	        level = 0;

	        timer1.Interval = 20;		        /////////////////////////////////////////////////
	        timer1.Enabled = true;

	        Bitmap x = Properties.Resources.soil;
	        for (int i = 0; i < 480; i += 60)
	        {
		Rectangle rr = new Rectangle(i, 0, 60, 60);
		Bitmap s = x.Clone(rr, x.PixelFormat);
	        }


	}

	void DigdaCreate()
	{
	        //actor = digda[(x / 10) % 4];
	}


	void update()
	{
	        if (gameStatFlag == 0)
	        {
		
	        }
	        else if (gameStatFlag == 1)
	        {
		if (currentTime - startTime > 0)
		        level = (currentTime - startTime) / 10 + 1;
		

		currentTime = Convert.ToInt32(DateTime.Now.ToString("mm")) * 60 + Convert.ToInt32(DateTime.Now.ToString("ss"));
		catchDigLbl.Text = "잡은 두더지 : " + Convert.ToString(score);
		missDigLbl.Text = "놓친 두더지 : " + Convert.ToString(allDigda - score);
		levelLbl.Text = "레벨 : " + Convert.ToString(level);
		timeLbl.Text = "시간(초) : " + Convert.ToString(currentTime - startTime);

		

		int randx = r.Next(0, 610);		        //0, 610
		int randy = r.Next(200, 600);	        //200 600
		int rands = r.Next(720 - ((level) * 150), 721+((level) * 150));	        // 50 700

		if (digdig.Count < level)	        //공존하는 두더지 숫자
		{
		        Digda d = new Digda(randx, randy, rands);
		        d.SetLimit(r.Next(100, level * 100));	        //50, 1000
		        digdig.Add(d);
		        allDigda++;
		        Dirt dd = new Dirt(randx, randy, rands);
		        dirt.Add(dd);

		       // count++;
		}

		for (int i = 0; i < digdig.Count; i++)
		{
		        if (dirt[i].DrawFinish())
		        {
			digdig[i].Dig();
		        }
		        if (!digdig[i].DigdaAlive())	        //두더지가 죽었거나 튀었는지 검사
		        {
			digdig.RemoveAt(i);	        //없으면 지움
			dirt.RemoveAt(i);
		        }
		}

		if((allDigda - score)  > 50)		        //게임오버 조건
		{
		        gameStatFlag = -1;
		        start.Text = "RESTART";
		        start.Visible = true;
		        trackBar1.Visible = true;
		        label1.Visible = true;
		        label2.Visible = true;
		        label3.Visible = true;

		}
	        }
	        else if(gameStatFlag == -1)
	        {

	        }
	}




	void draw()
	{
	        Bitmap screen = new Bitmap(700, 700);	//더블 버퍼링을 위한 임시 판떼기
	        Graphics scn = Graphics.FromImage(screen);     //판떼기에 그래픽을 그릴꺼야
	        Graphics g = this.CreateGraphics();		//Real 판떼기


	        if (gameStatFlag == 0)			//main
	        {
		Bitmap main = Properties.Resources.main;
		scn.DrawImage(main, 0, 0);
	        }
	        else if (gameStatFlag == 1)			//run
	        {
		Bitmap back = Properties.Resources.back;	//실행배경 가져온다.
		scn.DrawImage(back, 0, 0);
		for (int i = 0; i < digdig.Count; i++)
		{
		        if (dirt[i].DrawFinish())
		        {
			digdig[i].Draw(scn);
		        }
		        dirt[i].Draw(scn);
		}
	        }
	        else if(gameStatFlag == -1)			//finish
	        {
		Bitmap finish = Properties.Resources.finish;
		scn.DrawImage(finish, 0, 0);
	        }
	        g.DrawImage(screen, 0, 0);			//마지막에 따란~!
	        g.Dispose();

	        
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
	        update();
	        draw();
	}

	private void Form1_MouseDown(object sender, MouseEventArgs e)
	{
	        Point p = new Point(e.X, e.Y);
	        for (int i = 0; i < digdig.Count; i++)
	        {
		Rectangle r = digdig[i].Getbox();
		if (digdig[i].GetDie() == false)
		{
		        Rectangle sensor = new Rectangle(digdig[i].Getx(), digdig[i].Gety(), r.Width, r.Width * 2);
		        if (sensor.Contains(p))
		        {
			digdig[i].DigdaDie();
			score++;
		        }
		}
	        }
	}

	private void button1_Click(object sender, EventArgs e)	//start button
	{
	        gameStatFlag = 1;
	        start.Visible = false;
	        trackBar1.Visible = false;
	        label1.Visible = false;
	        label2.Visible = false;
	        label3.Visible = false;


	        score = 0;
	        allDigda = 0;
	        //start.Location = new Point(100, 100);
	        startTime = Convert.ToInt32(DateTime.Now.ToString("mm")) * 60 + Convert.ToInt32(DateTime.Now.ToString("ss"));
	        
	}
	private void GameEnd()
	{
	        gameStatFlag = -1;

	}

	private void trackBar1_Scroll(object sender, EventArgs e)
	{
	        if (trackBar1.Value == 1)
	        {
		modeLbl.Text = "Easy";
		timer1.Interval = 40;
	        }
	        else if (trackBar1.Value == 2)
	        {
		modeLbl.Text = "Normal";
		timer1.Interval = 20;
	        }
	        else if (trackBar1.Value == 3)
	        {
		modeLbl.Text = "Hard";
		timer1.Interval = 1;
	        }
	}

	private void label1_Click(object sender, EventArgs e)
	{

	}

        }
}
