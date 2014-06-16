﻿using System;
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
	Bitmap actor;
	List<Bitmap> digda = new List<Bitmap>();
	int x = 0;
	//actor = digda[digda.Count];

	Bitmap soils;
	List<Bitmap> soil = new List<Bitmap>();
	int xx = 0;
	/////////////////////////////////////////////////////////////////////////////////////////
	List<Digda> digdig = new List<Digda>();
	int count = 0;
	


	public Form1()
	{
	        InitializeComponent();
	        timer1.Interval = 100;
	        timer1.Enabled = true;

	        Bitmap x = Properties.Resources.test02;
	        for (int i = 0; i < 240; i += 60)
	        {
		Rectangle rr = new Rectangle(i, 0, 60, 180);
		Bitmap s = x.Clone(rr, x.PixelFormat);
		digda.Add(s);
	        }
	        actor = digda[0];

	        x = Properties.Resources.soil;
	        for(int i = 0; i < 480; i += 60)
	        {
		Rectangle rr = new Rectangle(i, 0, 60, 60);
		Bitmap s = x.Clone(rr, x.PixelFormat);
		soil.Add(s);
	        }


	}

	void DigdaCreate()
	{
	        actor = digda[(x / 10) % 4];
	}

	        
	void update()
	{
	        if (MouseButtons == MouseButtons.Left)
		x += 10;
	        

	        soils = soil[(x / 10) % 8];

	        if (count == 0)
	        {
		Digda d = new Digda();
		digdig.Add(d);
		count++;
	        }
	        
	        for (int i = 0; i < digdig.Count; i++)
	        {
		digdig[0].dig();
		if (!digdig[0].DigdaAlive())
		{
		        digdig.RemoveAt(0);
		}
	        }
	        
	       
	        
	}

	


	void draw()
	{
	        Bitmap screen = new Bitmap(700, 700);	//더블 버퍼링을 위한 임시 판떼기
	        Graphics scn = Graphics.FromImage(screen);     //판떼기에 그래픽을 그릴꺼야
	        Graphics g = this.CreateGraphics();		//Real 판떼기

	        //Rectangle r = new Rectangle(0, 0, 60, 180);	//자르기용 박스
	        //Bitmap b1 = Properties.Resources.test01;
	        Bitmap back = Properties.Resources.back;
	        //b1 = new Bitmap(b1, 120, 800);		//리사이즈는 이런식으로
	        //Bitmap b2 = b1.Clone(r, b1.PixelFormat);
	        //g.DrawImage(b2, 0, 0);

	        
	        scn.DrawImage(back, 0, 0);
	        for (int i = 0; i < digdig.Count; i++ )
		digdig[0].draw(scn);
	        

	       

	        //scn.DrawImage(actor, 100, 100);
	        scn.DrawImage(soils, 200, 200);

	        g.DrawImage(screen, 0, 0);			//마지막에 따란~!
	        


	        g.Dispose();

	}

	private void timer1_Tick(object sender, EventArgs e)
	{
	        update();
	        draw();
	}

        }
}
