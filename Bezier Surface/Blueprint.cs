using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Bezier_Surface
{

	internal class Blueprint
	{
		public readonly static string FileName = "BezierSurface.txt";
		public Bitmap bitmap { get; set; }
		public PictureBox Canvas { get; set; }
		public Vector3[] points = new Vector3[16];
		public Blueprint(int width, int height, PictureBox Canvas)
		{
			bitmap = new Bitmap(width, height);
			this.Canvas = Canvas;
			using (var g = Graphics.FromImage(bitmap))
			{
				SetOriginInCenter(g);
			}
			LoadPoints();
		}

		public void SetOriginInCenter(Graphics g)
		{
			g.ScaleTransform(1, -1);
			g.TranslateTransform(Canvas.Width / 2, -Canvas.Height / 2);
		}
		public void LoadPoints()
		{
			using (var streamReader = new StreamReader(FileName))
			{
				int i = 0;
				while (!streamReader.EndOfStream && i != 16)
				{
					string[] line = streamReader.ReadLine().Split();
					points[i++] = new Vector3(float.Parse(line[0]), float.Parse(line[1]), float.Parse(line[2]));
				}
			}
		}
	}
}