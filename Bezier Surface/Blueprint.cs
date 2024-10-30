using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bezier_Surface
{

	internal class Blueprint
	{
		public Bitmap bitmap { get; set; }
		public PictureBox Canvas { get; set; }
		public Blueprint(int width, int height, PictureBox Canvas)
		{
			bitmap = new Bitmap(width, height);
			this.Canvas = Canvas;
			using (var g = Graphics.FromImage(bitmap))
			{
				SetOriginInCenter(g);
			}
		}

		public void SetOriginInCenter(Graphics g)
		{
			g.ScaleTransform(1, -1);
			g.TranslateTransform(Canvas.Width / 2, -Canvas.Height / 2);
		}
	}
}
