﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Digda
{
        class Digda
        {
	//일단 두더지를 정의해야지
	//두더지는 올라가는 속도랑 내려가는 속도가 따로야
	//랜덤이여야 해

	//두더지들은 크기도 다르지

	//목 길이도 다를꺼야

	//특이한 친구들도 있겠지

	//기본적으로 공통적인 사항은... 흠...
	//위치를 가지고, 체력을 가지겠지

	Random r = new Random();

	int health;				        //체력
	int startx, starty;			        //생성 위치
	int x, y;				        //움직임 위치
	//int speed;
	int stayTime;				        //노출시간
	int stayCnt;
	int limit;
	bool digsw = true;			        //들락날락 스위치
	bool alive;

	int imgCnt;				        //이미지 플립용
	int imgw, imgh;				        //두더지 스케일 조절용



	Bitmap digda;
	List<Bitmap> digdaAni = new List<Bitmap>();
	Bitmap digdaImg;

	public void Resize(int h)
	{
	        //세로 크기에 따라 가로 가변 조절
	        imgw = (int)(h / 3);
	}

	public Digda(int posx, int posy, int scale)
	{
	        imgw = 60;
	        imgh = 180;

	        digdaImg = Properties.Resources.test02;
	        for (int i = 0; i < 240; i += 60)
	        {
		Rectangle cutImg = new Rectangle(i, 0, imgw, imgh);
		Bitmap digdaSingle = digdaImg.Clone(cutImg, digdaImg.PixelFormat);
		digdaAni.Add(digdaSingle);
	        }
	        startx = posx;
	        starty = posy;

	        x = startx;
	        y = starty;

	        alive = true;

	        stayTime = r.Next(1, 20);		        //지속시간은 랜덤으로

	        Resize(scale);
	        limit = r.Next(50, 800);
	        if (limit > imgh)
		limit = imgh;
	}

	public void Up(int t)
	{
	        y -= t;
	}
	public void Down(int t)
	{
	        y += t;
	}

	public void Draw(Graphics scn)
	{
	        if (starty - y > 90)				//영역 침범 방지
		y = starty - 90;

	        resize();

	        imgCnt++;
	        digda = new Bitmap(digdaAni[imgCnt % 4], 30, 90);	        //줄줄이 그리자~
	        Rectangle r = new Rectangle(0, 0, 30, starty - y);
	        Bitmap temp = digda.Clone(r, digda.PixelFormat);
	        scn.DrawImage(temp, x, y);
	}

	public void Dig()
	{
	        if (digsw)
	        {
		Up(r.Next(1,20));
		if (Math.Abs(starty - y) > limit)
		        digsw = false;
	        }
	        else
	        {
		if (stayTime == stayCnt)
		{
		        Down(r.Next(1, 20));
		        if (starty - y <= 0)
		        {
			y = starty - 1;
			alive = false;
		        }
		}
		else
		{
		        stayCnt++;
		}

	        }
	}

	public bool DigdaAlive()
	{
	        return alive;
	}

        }



        class Dirt
        {
	Random r = new Random();

	int imgw, imgh;
	Bitmap dirt;
	Bitmap dirtImg;
	List<Bitmap> dirtAni = new List<Bitmap>();
	int startx, starty;
	int x, y;
	bool fin = false;

	int imgCnt;
	public Dirt(int posx, int posy, int scale)
	{
	        imgw = 60;
	        imgh = 60;

	        dirtImg = Properties.Resources.soil;
	        for (int i = 0; i < 480; i += 60)
	        {
		Rectangle cutImg = new Rectangle(i, 0, imgw, imgh);
		Bitmap dirtSingle = dirtImg.Clone(cutImg, dirtImg.PixelFormat);
		dirtAni.Add(dirtSingle);
	        }
	        startx = posx;
	        starty = posy;

	        

	        Resize(scale);

	        x = startx;
	        y = starty - imgh + 10;
	}
	public void Draw(Graphics scn)
	{

	        imgCnt++;
	        if (imgCnt >= 8)
	        {
		imgCnt = 7;
		fin = true;
	        }
	        dirt = new Bitmap(dirtAni[imgCnt % 8], imgw, imgh);	        //줄줄이 그리자~
	        scn.DrawImage(dirt, x, y);
	}

	public void Resize(int h)
	{
	        imgw = (int)(h / 3);
	        imgh = imgw;
	}

	public bool DrawFinish()
	{
	        return fin;
	}
        }
}
