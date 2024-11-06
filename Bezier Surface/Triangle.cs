using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Bezier_Surface
{
	internal class Triangle
	{
		public Vertex[] vertices = new Vertex[3];
		public Triangle(Vertex v1, Vertex v2, Vertex v3)
		{
			vertices[0] = v1;
			vertices[1] = v2;
			vertices[2] = v3;
		}
		public void Draw(Graphics g)
		{
			g.DrawEllipse(new Pen(Color.DarkBlue, 3), vertices[0].pointAfterRotation.X-1.5f, vertices[0].pointAfterRotation.Y - 1.5f, 3, 3);
			g.DrawEllipse(new Pen(Color.DarkBlue, 3), vertices[1].pointAfterRotation.X - 1.5f, vertices[1].pointAfterRotation.Y - 1.5f, 3, 3);
			g.DrawEllipse(new Pen(Color.DarkBlue, 3), vertices[2].pointAfterRotation.X - 1.5f, vertices[2].pointAfterRotation.Y - 1.5f, 3, 3);
			DrawLineBetweenVertices(vertices[0], vertices[1], g);
			DrawLineBetweenVertices(vertices[0], vertices[2], g);
			DrawLineBetweenVertices(vertices[1], vertices[2], g);
		}
		private void DrawLineBetweenVertices(Vertex v1, Vertex v2, Graphics g)
		{
			g.DrawLine(new Pen(Color.DarkBlue, 3), v1.pointAfterRotation.X, v1.pointAfterRotation.Y, v2.pointAfterRotation.X, v2.pointAfterRotation.Y);
		}
		public void Rotate(int alfa, int beta)
		{
			vertices[0].Rotate(alfa, beta);
			vertices[1].Rotate(alfa, beta);
			vertices[2].Rotate(alfa, beta);

		}
	}
}
