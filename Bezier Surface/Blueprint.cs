using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Bezier_Surface
{
	//TODO Fast bitmap, rotatematrix
	internal class Blueprint
	{
		public readonly static string FileName = "BezierSurface.txt";
		public Bitmap bitmap { get; set; }
		public PictureBox Canvas { get; set; }
		public Vector3[] CPs = new Vector3[16];
		public List<Triangle> triangularMesh = new List<Triangle>();
		public int alfa = 0; // z
		public int beta = 0; // x
		public int precision = 10;
		public Blueprint(int width, int height, PictureBox Canvas)
		{
			bitmap = new Bitmap(width, height);
			this.Canvas = Canvas;

			LoadPoints();
			Draw();
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
					CPs[i++] = (new Vector3(float.Parse(line[0]), float.Parse(line[1]), float.Parse(line[2])));
				}
			}
		}
		public void SortPoints()
		{
			CPs = CPs.OrderBy(p => p.X).ThenBy(p => p.Y).ToArray();
		}
		public void Draw()
		{

			CreateTriangularMesh();
			Rotate();
			using (var g = Graphics.FromImage(bitmap))
			{
				g.Clear(Color.White);
				SetOriginInCenter(g);
				foreach (var vertex in CPs)
				{
					g.DrawEllipse(new Pen(Color.RebeccaPurple, 10), vertex.X, vertex.Y, 10, 10);
				}
				foreach (Triangle triangle in triangularMesh)
				{
					triangle.Draw(g);
				}
				Canvas.Refresh();
			}
		}

		public Vertex[,] SubDivideCPs()
		{
			float step = 1.0f / (float)precision;
			Vertex[,] vertices = new Vertex[precision + 1, precision + 1];
			float u, v;
			// dla każdegu u i dla każdego v są punkty, punkt to suma i,j
			for (int r = 0; r <= precision; ++r) //n
			{
				u = step * r;
				for (int c = 0; c <= precision; ++c) //m
				{
					v = step * c;
					Vector3 vector = new Vector3();
					for (int i = 0; i < 4; i++) // n
					{
						for (int j = 0; j < 4; j++) // m
						{
							vector += CPs[4 * i + j] * MathHelper.CalcB(i, 3, u) * MathHelper.CalcB(j, 3, v);
						}
					}
					vertices[r, c] = new Vertex(vector);
				}
			}
			return vertices;
		}

		public void CreateTriangularMesh()
		{
			var vertices = SubDivideCPs();
			triangularMesh = new List<Triangle>();
			for (int c = 0; c < precision; ++c)
			{
				for (int r = 0; r < precision; ++r)
				{
					triangularMesh.Add(new Triangle(vertices[r, c], vertices[r, c + 1], vertices[r + 1, c + 1]));
					triangularMesh.Add(new Triangle(vertices[r, c], vertices[r + 1, c], vertices[r + 1, c + 1]));
				}
			}
		}
		public void Rotate()
		{
			foreach (Triangle triangle in triangularMesh)
			{
				triangle.Rotate(alfa, beta);
			}
		}

	}
}