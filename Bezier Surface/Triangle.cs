using FastBitmapLib;
using System.Drawing;
using System.Numerics;

namespace Bezier_Surface
{
	internal class Triangle
	{
		private enum FillingStage { Inside, Outside }
		public Vertex[] vertices = new Vertex[3];
		int minY = int.MaxValue;
		int maxY = int.MinValue;
		Color myColor;
		bool inTet;
		List<Edge> edges;
		public Triangle(Vertex v1, Vertex v2, Vertex v3)
		{
			vertices[0] = v1;
			vertices[1] = v2;
			vertices[2] = v3;
			Random random = new Random();
			int red = random.Next(100, 256);
			int green = random.Next(100, 256);
			int blue = random.Next(100, 256);
			myColor = Color.FromArgb(red, green, blue);
		}
		public void Draw(Graphics g)
		{
			DrawLineBetweenVertices(vertices[0], vertices[1], g);
			DrawLineBetweenVertices(vertices[0], vertices[2], g);
			DrawLineBetweenVertices(vertices[1], vertices[2], g);
			g.DrawEllipse(new Pen(Color.DarkBlue, 2), vertices[0].pointAR.X - 1.5f, vertices[0].pointAR.Y - 1.5f, 3, 3);
			g.DrawEllipse(new Pen(Color.DarkBlue, 2), vertices[1].pointAR.X - 1.5f, vertices[1].pointAR.Y - 1.5f, 3, 3);
			g.DrawEllipse(new Pen(Color.DarkBlue, 2), vertices[2].pointAR.X - 1.5f, vertices[2].pointAR.Y - 1.5f, 3, 3);
		}
		private void DrawLineBetweenVertices(Vertex v1, Vertex v2, Graphics g)
		{
			g.DrawLine(new Pen(Color.BlueViolet, 1), v1.pointAR.X, v1.pointAR.Y, v2.pointAR.X, v2.pointAR.Y);
		}
		public void Rotate(Matrix4x4 MX, Matrix4x4 MZ)
		{
			vertices[0].Rotate(MX, MZ);
			vertices[1].Rotate(MX, MZ);
			vertices[2].Rotate(MX, MZ);
			minY = int.MaxValue;
			maxY = int.MinValue;
			foreach (Vertex v in vertices)
			{
				minY = v.pointAR.Y < minY ? (int)v.pointAR.Y : minY;
				maxY = v.pointAR.Y > maxY ? (int)v.pointAR.Y : maxY;
			}
		}
		public void UpdateEdgeList()
		{
			edges =
			[
				new Edge(vertices[0], vertices[1]),
				new Edge(vertices[2], vertices[1]),
				new Edge(vertices[0], vertices[2]),
			];
		}
		public void FillTriangle(Blueprint blueprint, FastBitmap fbtmp)
		{
			inTet = blueprint.tetTriangles.Contains(this);
			int wOffset = fbtmp.Width / 2;
			int hOffset = fbtmp.Height / 2;

			Edge? first = null;
			var AET = new List<Edge>();
			var ET = new Dictionary<int, List<Edge>>();

			UpdateEdgeList();

			foreach (Edge e in edges)
			{
				if (!ET.ContainsKey((int)e.yMin))
				{
					ET.Add((int)e.yMin, new List<Edge>());
				}
				ET[(int)e.yMin].Add(e);
			}

			int y = minY;
			while (AET.Count != 0 || ET.Count != 0)
			{
				first = UpdateAETAndColor(AET, ET, y++, fbtmp, first, blueprint, wOffset, hOffset);
			}
		}

		public Edge UpdateAETAndColor(List<Edge> AET, Dictionary<int, List<Edge>> ET, int y, FastBitmap fbtmp, Edge? prefFirst, Blueprint blueprint, int wOffset, int hOffset)
		{
			if (ET.ContainsKey(y))
			{
				AET.AddRange(ET[y]);
				ET.Remove(y);
			}
			// Sorting
			AET.Sort((e1, e2) => e1.x.CompareTo(e2.x));
			for (int i = 0; i < AET.Count - 1; i++)
			{
				AET[i].next = AET[i + 1];
			}
			if (AET.Count > 0)
			{
				AET.Last().next = null;
			}
			Edge edge = AET[0];
			//

			var status = FillingStage.Inside;
			int X;
			int Y;
			while (edge.next != null)
			{
				if (status == FillingStage.Inside)
				{
					for (int i = (int)edge.x; i <= edge.next.x; i++)
					{
						X = i + wOffset;
						Y = -y + hOffset;
						(Color color, Single z) = CalculateFinalColor(blueprint, new Vector2(i, y));
						if (X >= 0 && Y >= 0 && X < fbtmp.Width && Y < fbtmp.Height)
						{
							if (z > blueprint.zBuffer[X, Y])
							{
								fbtmp.SetPixel(X, Y, color);
								blueprint.zBuffer[X, Y] = z;
							}

						}
					}
					if ((int)edge.yMax != (int)edge.next.yMin && (int)edge.yMin != (int)edge.next.yMax)
						status = status == FillingStage.Inside ? FillingStage.Outside : FillingStage.Inside;
				}
				edge = edge.next;
			}

			edge = AET[0];
			var first = edge;
			while (edge != null)
			{
				if (edge.yMax <= y)
					AET.Remove(edge);
				edge = edge.next;
			}
			foreach (var e in AET)
			{
				e.IncreaseX();
			}

			return first;
		}
		public (Color, Single) CalculateFinalColor(Blueprint bp, Vector2 point)
		{
			(var normal, var z, var color) = InterpolateNormalAndZ(vertices[0], vertices[1], vertices[2], point, bp);
			if (!bp.useTexture)
			{
				color = bp.survaceColor;
			}
			if (inTet)
			{
				color = myColor;
			}
			var io = new Vector3(bp.lightColor.R, bp.lightColor.G, bp.lightColor.B) / 255f;
			var il = new Vector3(color.R, color.G, color.B) / 255f;

			Vector3 L = Vector3.Normalize(bp.lightPosition - new Vector3(point, z));
			if (bp.useReflector)
			{
				il = il * (float)Math.Pow(Vector3.Dot(L, Vector3.Normalize(bp.lightPosition)), bp.mL);
			}
			var ioil = (io) * ((il));

			var NL = Vector3.Dot(normal, L);
			Vector3 R = 2 * NL * normal - L;
			var V = new Vector3(0, 0, 1);
			var colorResult = (bp.kd * ioil * Math.Clamp(NL, 0, 1) + bp.ks * ioil * (float)Math.Pow(Math.Clamp(Vector3.Dot(V, R), 0, 1), bp.m));

			int r = Math.Clamp((int)Math.Round(colorResult.X * 255), 0, 255);
			int g = Math.Clamp((int)Math.Round(colorResult.Y * 255), 0, 255);
			int b = Math.Clamp((int)Math.Round(colorResult.Z * 255), 0, 255);
			return (Color.FromArgb(255, r, g, b), z);
		}

		public (Vector3, float, Color) InterpolateNormalAndZ(Vertex v1, Vertex v2, Vertex v3, Vector2 P, Blueprint bp)
		{
			var v1N = v1.normalAR;
			var v2N = v2.normalAR;
			var v3N = v3.normalAR;
			float denominator = (v1.pointAR.Y - v3.pointAR.Y) * (v2.pointAR.X - v3.pointAR.X)
							  + (v3.pointAR.X - v1.pointAR.X) * (v2.pointAR.Y - v3.pointAR.Y);

			if (Math.Abs(denominator) < 1e-6)
			{
				return (Vector3.Zero, 0, Color.Black);
			}

			float a = Math.Abs(((v2.pointAR.Y - v3.pointAR.Y) * (P.X - v3.pointAR.X)
							+ (v3.pointAR.X - v2.pointAR.X) * (P.Y - v3.pointAR.Y)) / denominator);
			float b = Math.Abs(((v3.pointAR.Y - v1.pointAR.Y) * (P.X - v3.pointAR.X)
							+ (v1.pointAR.X - v3.pointAR.X) * (P.Y - v3.pointAR.Y)) / denominator);
			float c = Math.Max(0, 1 - a - b);


			Vector3 interpolatedNormal = a * v1N + b * v2N + c * v3N;
			if (interpolatedNormal == Vector3.Zero)
			{
				return (Vector3.Zero, 0, Color.Black);
			}
			interpolatedNormal = Vector3.Normalize(interpolatedNormal);
			float interpolatedZ = a * v1.pointAR.Z + b * v2.pointAR.Z + c * v3.pointAR.Z;
			Color color = bp.survaceColor;
			if (!inTet && (bp.useNormalMap || bp.useTexture))
			{
				(float u, float v) = (Math.Clamp(a * v1.u + b * v2.u + c * v3.u, 0, 1), Math.Clamp(a * v1.v + b * v2.v + c * v3.v, 0, 1));
				if (bp.useTexture)
				{
					int x = (int)(v * (bp.textureColors.GetLength(0) - 1));
					int y = (int)(u * (bp.textureColors.GetLength(1) - 1));
					color = bp.textureColors[x, y];
				}
				if (bp.useNormalMap)
				{
					int x = (int)(v * (bp.normalMapColors.GetLength(0) - 1));
					int y = (int)(u * (bp.normalMapColors.GetLength(1) - 1));
					(var pu, var pv) = (Vector3.Normalize(a * v1.puAR + b * v2.puAR + c * v3.puAR), Vector3.Normalize(a * v1.pvAR + b * v2.pvAR + c * v3.pvAR));
					Color nmpc;
					nmpc = bp.normalMapColors[x, y];
					var X = (nmpc.R / 127.5f) - 1;
					var Y = (nmpc.G / 127.5f) - 1;
					var Z = (nmpc.B / 127.5f) - 1;
					var normalMapN = Vector3.Normalize(new Vector3(X, Y, Z));
					interpolatedNormal = Vector3.Normalize(Vertex.CreateNormalUsingNormalMap(pu, pv, interpolatedNormal, normalMapN));
				}
			}

			return (interpolatedNormal, interpolatedZ, color);
		}

		internal void ResetRotationChecker()
		{
			vertices[0].Reset();
			vertices[1].Reset();
			vertices[2].Reset();
		}
	}

}
