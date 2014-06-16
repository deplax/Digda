using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

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
	bool die;

	int imgCnt;				        //이미지 플립용
	int imgw, imgh;				        //두더지 스케일 조절용

	int dieCnt;


	Bitmap digda;
	List<Bitmap> digdaAni = new List<Bitmap>();
	Bitmap digdaImg;

	Bitmap hit;
	Rectangle box;

	public void Resize(int h)
	{
	        //세로 크기에 따라 가로 가변 조절
	        imgw = (int)(h / 8);
	}
	public void test()
	{
	        hit = Properties.Resources.angry;
	       // hit.
	        MessageBox.Show("test");
	}

	public Digda(int posx, int posy, int scale)
	{
	        imgw = 90;
	        imgh = scale ;

	        digdaImg = Properties.Resources.digda;
	        for (int i = 0; i < 720; i += 90)
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
	        die = false;

	        stayTime = r.Next(1, 20);		        //지속시간은 랜덤으로

	        Resize(scale);
	        limit = r.Next(50, 700);
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
	        if (starty - y > imgh)				//영역 침범 방지
		y = starty - imgh;
	        else if(starty - y == 0)
		y = starty + 1;

	        imgCnt++;
	        digda = new Bitmap(digdaAni[imgCnt % 8], imgw, imgh);	        //줄줄이 그리자~
	        box = new Rectangle(0, 0, imgw, starty - y );
	        Bitmap temp;
	        hit = Properties.Resources.angry;
	        hit = new Bitmap(hit, imgw, imgh);
	        if (!die)
		temp = digda.Clone(box, digda.PixelFormat);
	        else
	        {
		
		if (dieCnt > 2)
		{
		        alive = false;
		}
		temp = hit.Clone(box, hit.PixelFormat);
		dieCnt++;
	        }
	        scn.DrawImage(temp, x, y);


	}

	public void Dig()
	{
	        if (digsw)
	        {
		Up(r.Next(10, 40));
		if (Math.Abs(starty - y) > limit)
		        digsw = false;
	        }
	        else
	        {
		if (stayTime == stayCnt)
		{
		        Down(r.Next(10, 40));
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

	public Rectangle Getbox()
	{
	        return box;
	}
	public int Getx()
	{
	        return x;
	}
	public int Gety()
	{
	        return y;
	}
	public void DigdaDie()
	{
	        die = true;
	        

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
	        imgw = (int)(h / 8);
	        imgh = imgw;
	}

	public bool DrawFinish()
	{
	        return fin;
	}
        }
}
