using System;
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

	int health;			        //체력
	public int startx, starty;			        //생성 위치
	public int x, y;				        //움직임 위치
	int speed;
	int upTime, StayTime, DownTime;	        //노출시간
	public int limit = 100;
	public bool digsw = true;		        //들락날락 스위치
	bool alive;



	Bitmap digda;
	List<Bitmap> digdaAni = new List<Bitmap>();
	Bitmap digdaImg;

	public void resize()
	{

	}

	public Digda()
	{
	       digdaImg = Properties.Resources.test02;
	        for (int i = 0; i < 240; i += 60)
	        {
		Rectangle  cutImg = new Rectangle(i, 0, 60, 180);
		Bitmap digdaSingle = digdaImg.Clone(cutImg, digdaImg.PixelFormat);
		digdaAni.Add(digdaSingle);
	        }
	        startx = 200;
	        starty = 200;

	        x = startx;
	        y = starty;

	        alive = true;
	}

	public void Up()
	{
	        y -= 10;
	}
	public void Down()
	{
	        y += 10;
	}

	public void draw(Graphics scn)
	{
	        digda = digdaAni[Math.Abs(y % 4)];
	        Rectangle r = new Rectangle(0, 0, 60, starty - y);
	        Bitmap temp = digda.Clone(r, digda.PixelFormat);
	        scn.DrawImage(temp, x, y);
	}

	public void dig()
	{
	        if (digsw)
	        {
		Up();
		if (Math.Abs(starty -y) > limit)
		        digsw = false;
	        }
	        else
	        {
		Down();
		if (starty - y <= 0)
		{
		        y = starty - 1;
		        alive = false;
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
	int time;

	public void TimeLatency()
	{

	}
        }
}
