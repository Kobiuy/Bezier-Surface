using FastBitmapLib;
using System.Numerics;

namespace Bezier_Surface
{
	internal class Blueprint
	{
		public string controlPointsFilePath = "punkty3.txt";
		public string normalMapFilePatch = "brick_normalmap.png";
		public string textureFilePatch = "texture.jpg";

		public Bitmap normalMap { get; set; }
		public Bitmap texture { get; set; }
		public Color lightColor = Color.White;
		public bool showControlPoints = true;
		public bool showMesh = true;
		public Vector3 lightPosition = new Vector3(0, 0, 500);
		public bool useNormalMap { get; set; }
		public Bitmap bitmap { get; set; }
		public PictureBox Canvas { get; set; }
		public int m { get; set; } = 10;
		public float ks { get; set; } = 0.2f;
		public float kd { get; set; } = 0.8f;
		public bool useTexture { get; set; }

		public Vertex[] CPs = new Vertex[16];
		public List<Triangle> triangularMesh = new List<Triangle>();
		public int alfa = 0; // z
		public int beta = 0; // x
		public int precision = 10;
		public Color survaceColor = Color.DeepPink;
		public Blueprint(int width, int height, PictureBox Canvas)
		{
			bitmap = new Bitmap(width, height);
			this.Canvas = Canvas;
			LoadMap();
			LoadPoints();
			LoadTexture();
			CreateTriangularMesh();
			Rotate();
			Draw();
		}

		private void LoadMap()
		{
			normalMap = new Bitmap(new Bitmap(normalMapFilePatch));
		}
		private void LoadTexture()
		{
			texture = new Bitmap(new Bitmap(textureFilePatch));
		}

		public void SetOriginInCenter(Graphics g)
		{
			g.ScaleTransform(1, -1);
			g.TranslateTransform(Canvas.Width / 2, -Canvas.Height / 2);

		}
		public void LoadPoints()
		{
			using (var streamReader = new StreamReader(controlPointsFilePath))
			{
				int i = 0;
				while (!streamReader.EndOfStream && i != 16)
				{
					string[] line = streamReader.ReadLine().Split();
					CPs[i++] = (new Vertex(float.Parse(line[0]), float.Parse(line[1]), float.Parse(line[2]), 0, 0));
				}
			}
		}
		public void SortPoints()
		{
			CPs = CPs.OrderBy(p => p.pointBR.X).ThenBy(p => p.pointBR.Y).ToArray();
		}
		public void Draw()
		{
			using (var g = Graphics.FromImage(bitmap))
			{
				using (var fbtmp = bitmap.FastLock())
				{
					fbtmp.Clear(Color.White);
				}
				SetOriginInCenter(g);
				if (showControlPoints)
				{
					foreach (var vertex in CPs)
					{
						g.DrawEllipse(new Pen(Color.RebeccaPurple, 10), vertex.pointAR.X - 5, vertex.pointAR.Y - 5, 10, 10);
					}
				}
				using (var fbtmp = bitmap.FastLock())
				{
					foreach (Triangle triangle in triangularMesh)
					{
						triangle.FillTriangle(this, fbtmp);
					}
				}
				if (showMesh)
				{
					foreach (var triangle in triangularMesh)
					{
						triangle.Draw(g);
					}
				}
				Canvas.Refresh();
			}
		}

		public Vertex[,] SubDivideCPs()
		{
			float step = 1.0f / (float)precision;
			Vertex[,] vertices = new Vertex[precision + 1, precision + 1];
			float u, v;

			var B3 = new float[4, precision+1];
			for (int i = 0; i <= precision; ++i) //n
			{
				u = step * i;
				for (int j = 0; j < 4; j++) // m
				{
					B3[j, i] = MathHelper.CalcB(j, 3, u);
				}
			}
			for (int r = 0; r <= precision; ++r) //n
			{
				u = step * r;
				for (int c = 0; c <= precision; ++c) //m
				{
					v = step * c;
					Vector3 vector = new Vector3();
					Vector3 pu = new Vector3();
					Vector3 pv = new Vector3();

					for (int i = 0; i < 4; i++) // n
					{
						for (int j = 0; j < 4; j++) // m
						{
							vector += CPs[4 * i + j].pointBR * B3[i, r] * B3[j, c];
							if (j != 3)
							{
								pu += 3 * (CPs[(j + 1) * 4 + i].pointBR - CPs[j * 4 + i].pointBR) * MathHelper.CalcB(j, 2, u) * B3[i, c];
								pv += 3 * (CPs[i * 4 + j + 1].pointBR - CPs[i * 4 + j].pointBR) * B3[i, r] * MathHelper.CalcB(j, 2, v);
							}
						}
					}

					vertices[r, c] = new Vertex(new Vector3((int)vector.X, (int)vector.Y, (int)vector.Z), u, v, pu, pv);
				}
			}
			return vertices;
		}

		public void CreateTriangularMesh()
		{
			var vertices = SubDivideCPs();
			foreach (var vertex in vertices)
			{
				vertex.SetNormalVectors(normalMap);
				vertex.SetColorFromTexture(texture);
			}
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
			var MZ = Matrix4x4.CreateRotationZ((alfa * MathF.PI) / 180f);
			var MX = Matrix4x4.CreateRotationX((beta * MathF.PI) / 180f);
			foreach (Triangle triangle in triangularMesh)
			{
				triangle.ResetRotationChecker();
			}
			foreach (Triangle triangle in triangularMesh)
			{
				triangle.Rotate(MX, MZ);
			}
			foreach (var cp in CPs)
			{
				cp.reseted = false;
				cp.Rotate(MX, MZ);
			}
		}
	}
}