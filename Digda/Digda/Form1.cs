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
	int count = 0;



	public Form1()
	{
	        InitializeComponent();
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

	        if (MouseButtons == MouseButtons.Left)
	        {
		//MessageBox.Show("test");
		//x += 10;
	        }

	        int randx = r.Next(0, 610);
	        int randy = r.Next(200, 600);
	        int rands = r.Next(50, 700);

	        if (digdig.Count < 4)
	        {
		Digda d = new Digda(randx, randy, rands);
		digdig.Add(d);

		Dirt dd = new Dirt(randx, randy, rands);
		dirt.Add(dd);

		count++;
	        }
	        //공존하는 두더지 숫자를 결정필요
	        for (int i = 0; i < digdig.Count; i++)
	        {
		if (dirt[i].DrawFinish())
		{
		        digdig[i].Dig();
		}

		if (!digdig[i].DigdaAlive())	        //두더지가 죽었거나 튀었는지 검사
		{
		        digdig.RemoveAt(i);		        //없으면 지움
		        dirt.RemoveAt(i);
		}
	        }
	}




	void draw()
	{
	        Bitmap screen = new Bitmap(700, 700);	//더블 버퍼링을 위한 임시 판떼기
	        Graphics scn = Graphics.FromImage(screen);     //판떼기에 그래픽을 그릴꺼야
	        Graphics g = this.CreateGraphics();		//Real 판떼기
	        Bitmap back = Properties.Resources.back;

	        scn.DrawImage(back, 0, 0);

	        for (int i = 0; i < digdig.Count; i++)
	        {
		if (dirt[i].DrawFinish())
		{
		        digdig[i].Draw(scn);
		}
		dirt[i].Draw(scn);
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
		Rectangle sensor = new Rectangle(digdig[i].Getx(), digdig[i].Gety(), r.Width, r.Height / 3 + 5);
		if(sensor.Contains(p))
		{
		        digdig[i].DigdaDie();
		        //MessageBox.Show("hit");
		}
	        }
	}

        }
}
