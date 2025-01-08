using FastBitmapLib;
using System.Numerics;
using System.Runtime.ConstrainedExecution;

namespace Bezier_Surface
{
	internal class Blueprint
	{
		public string controlPointsFilePath = "ControlPoints/punkty2.txt";
		public string normalMapFilePatch = "NormalMaps\\bricks.JPG";
		public string textureFilePatch = "Textures\\bricks.JPG";
		public List<Vertex> tetrahedron = new List<Vertex>();
		public List<Triangle> tetTriangles = new List<Triangle>();
		public bool showTriangle = true;
		public Bitmap normalMap { get; set; }
		public Bitmap texture { get; set; }
		public Color[,] textureColors { get; set; }
		public Color[,] normalMapColors { get; set; }
		public Color lightColor = Color.White;
		public bool showLightPosition { get; set; }
		public bool showControlPoints = true;
		public bool showMesh { get; set; } = true;
		public Vector3 lightPosition = new Vector3(0, 0, 500);
		public static readonly object lockObject = new object();
		public bool useNormalMap { get; set; }
		public Bitmap bitmap { get; set; }
		public PictureBox canvas { get; set; }
		public int m { get; set; } = 10;
		public float ks { get; set; } = 0.2f;
		public float kd { get; set; } = 0.8f;
		public bool useReflector { get; set; }
		public int mL = 5;
		public bool useTexture { get; set; }
		public bool showFilling { get; internal set; } = true;
		public Single[,] zBuffer { get; set; }

		public Vertex[] CPs = new Vertex[16];
		public List<Triangle> triangularMesh = new List<Triangle>();
		public int alfa = 0; // z
		public int beta = 0; // x
		public int precision = 10;
		public Color survaceColor = Color.DeepPink;
		internal Animator animator;

		public Blueprint(int width, int height, PictureBox Canvas)
		{
			zBuffer = new Single[width, height];
			for (int i = 0; i < width; i++)
			{
				for (int j = 0; j < height; j++)
				{
					zBuffer[i, j] = Single.MinValue;
				}
			}
			bitmap = new Bitmap(width, height);
			this.canvas = Canvas;
			tetrahedron.Add(new Vertex(-200, -200, -100));
			tetrahedron.Add(new Vertex(0, 200, -100));
			tetrahedron.Add(new Vertex(200, -200, -100));
			tetrahedron.Add(new Vertex(0, 0, 300));

			tetrahedron[0].calcNormal(tetrahedron[1], tetrahedron[2], tetrahedron[3]);
			tetrahedron[1].calcNormal(tetrahedron[0], tetrahedron[2], tetrahedron[3]);
			tetrahedron[2].calcNormal(tetrahedron[1], tetrahedron[0], tetrahedron[3]);
			tetrahedron[3].calcNormal(tetrahedron[1], tetrahedron[0], tetrahedron[2]);

			LoadPoints();
			CreateTriangularMesh();
			Rotate();
			LoadTexture();
			LoadMap();
			DrawAndRefresh();

		}

		public void LoadMap()
		{
			lock (lockObject)
			{
				normalMap = new Bitmap(new Bitmap(normalMapFilePatch));
				normalMapColors = new Color[normalMap.Width, normalMap.Height];
				for (int i = 0; i < normalMap.Width; i++)
				{
					for (int j = 0; j < normalMap.Height; j++)
					{
						normalMapColors[i, j] = normalMap.GetPixel(i, j);
					}
				}
			}
		}
		public void LoadTexture()
		{
			lock (lockObject)
			{
				texture = new Bitmap(new Bitmap(textureFilePatch));
				textureColors = new Color[texture.Width, texture.Height];
				for (int i = 0; i < texture.Width; i++)
				{
					for (int j = 0; j < texture.Height; j++)
					{
						textureColors[i, j] = texture.GetPixel(i, j);
					}
				}
			}
		}

		public void SetOriginInCenter(Graphics g)
		{
			g.ScaleTransform(1, -1);
			g.TranslateTransform(canvas.Width / 2, -canvas.Height / 2);

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
		public void DrawAndRefresh()
		{
			lock (lockObject)
			{
				Draw();
				canvas.Refresh();
			}
		}
		public void Refresh()
		{
			lock (lockObject)
			{
				canvas.Refresh();
			}
		}
		public void AnimatorDraw()
		{
			lock (lockObject)
			{
				CreateTriangularMesh();
				Rotate();
				Draw();
			}
		}
		public void Draw()
		{
			for (int i = 0; i < canvas.Width; i++)
			{
				for (int j = 0; j < canvas.Height; j++)
				{
					zBuffer[i, j] = Single.MinValue;
				}
			}
			using (var g = Graphics.FromImage(bitmap))
			{
				using (var fbtmp = bitmap.FastLock())
				{
					fbtmp.Clear(Color.White);
				}
				SetOriginInCenter(g);
				if (showControlPoints)
				{
					for (int i = 0; i < 4; i++)
					{
						for (int j = 0; j < 4; j++)
						{
							g.DrawEllipse(new Pen(Color.RebeccaPurple, 10), CPs[4 * i + j].pointAR.X - 5, CPs[4 * i + j].pointAR.Y - 5, 10, 10);
							if (i < 3)
							{
								g.DrawLine(new Pen(Color.Black, 2), CPs[4 * i + j].pointAR.X, CPs[4 * i + j].pointAR.Y, CPs[4 * (i + 1) + j].pointAR.X, CPs[4 * (i + 1) + j].pointAR.Y);
								g.DrawLine(new Pen(Color.Black, 2), CPs[4 * j + i].pointAR.X, CPs[4 * j + i].pointAR.Y, CPs[4 * j + i + 1].pointAR.X, CPs[4 * j + i + 1].pointAR.Y);
							}
						}
					}
				}
				if (showFilling)
				{
					using (var fbtmp = bitmap.FastLock())
					{
						Parallel.ForEach<Triangle>(triangularMesh, (Triangle triangle) =>
						{
							triangle.FillTriangle(this, fbtmp);
						});
					}
				}
				if (showTriangle)
					using (var fbtmp = bitmap.FastLock())
					{
						Parallel.ForEach<Triangle>(tetTriangles, (Triangle triangle) =>
						{
							triangle.FillTriangle(this, fbtmp);
						});
					}

				if (showMesh)
				{
					foreach (var triangle in triangularMesh)
					{
						triangle.Draw(g);
					}
					if (showTriangle)
						foreach (var triangle in tetTriangles)
						{
							triangle.Draw(g);
						}
				}
				if (showLightPosition)
				{
					g.DrawEllipse(new Pen(Color.OrangeRed, 5), (int)lightPosition.X, (int)lightPosition.Y, 5, 5);
				}
			}
		}

		public Vertex[,] SubDivideCPs()
		{
			float step = 1.0f / (float)precision;
			Vertex[,] vertices = new Vertex[precision + 1, precision + 1];
			float u, v;

			var B3 = new float[4, precision + 1];
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
			triangularMesh = new List<Triangle>();
			for (int c = 0; c < precision; ++c)
			{
				for (int r = 0; r < precision; ++r)
				{
					triangularMesh.Add(new Triangle(vertices[r, c], vertices[r, c + 1], vertices[r + 1, c + 1]));
					triangularMesh.Add(new Triangle(vertices[r, c], vertices[r + 1, c], vertices[r + 1, c + 1]));
				}

			}


			tetTriangles.Add(new Triangle(tetrahedron[0], tetrahedron[1], tetrahedron[2]));
			tetTriangles.Add(new Triangle(tetrahedron[0], tetrahedron[1], tetrahedron[3]));
			tetTriangles.Add(new Triangle(tetrahedron[0], tetrahedron[3], tetrahedron[2]));
			tetTriangles.Add(new Triangle(tetrahedron[3], tetrahedron[1], tetrahedron[2]));

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
			if (animator != null && animator.running)
			{
				MZ = Matrix4x4.CreateRotationZ(((alfa + animator.angle) * MathF.PI) / 180f);
				MX = Matrix4x4.CreateRotationX(((beta + animator.angle) * MathF.PI) / 180f);
			}
			foreach (Triangle triangle in tetTriangles)
			{
				triangle.ResetRotationChecker();
			}
			foreach (Triangle triangle in tetTriangles)
			{
				triangle.Rotate(MX, MZ);
			}

		}
	}
}