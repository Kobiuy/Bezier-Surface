using FastBitmapLib;
using System.Drawing;
using System.Numerics;

namespace Bezier_Surface
{
	internal class Triangle
	{
		private enum FillingStage { Inside, Outside }
		public Vertex[] vertices = new Vertex[3];
		public Triangle(Vertex v1, Vertex v2, Vertex v3)
		{
			vertices[0] = v1;
			vertices[1] = v2;
			vertices[2] = v3;
		}
		public void Draw(Graphics g)
		{
			DrawLineBetweenVertices(vertices[0], vertices[1], g);
			DrawLineBetweenVertices(vertices[0], vertices[2], g);
			DrawLineBetweenVertices(vertices[1], vertices[2], g);
			g.DrawEllipse(new Pen(Color.DarkBlue, 1), vertices[0].pointAR.X - 1.5f, vertices[0].pointAR.Y - 1.5f, 3, 3);
			g.DrawEllipse(new Pen(Color.DarkBlue, 1), vertices[1].pointAR.X - 1.5f, vertices[1].pointAR.Y - 1.5f, 3, 3);
			g.DrawEllipse(new Pen(Color.DarkBlue, 1), vertices[2].pointAR.X - 1.5f, vertices[2].pointAR.Y - 1.5f, 3, 3);
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
		}
		public void FillTriangle(Blueprint blueprint, FastBitmap fbtmp)
		{
			int minY = int.MaxValue;
			int maxY = int.MinValue;
			Dictionary<int, List<Edge>> AET = new Dictionary<int, List<Edge>>(); //TODO Zamień dictionary na array
			Dictionary<int, List<Edge>> ET = new Dictionary<int, List<Edge>>();
			List<Edge> edges = new List<Edge>();
			edges.Add(new Edge(vertices[0], vertices[1]));
			edges.Add(new Edge(vertices[2], vertices[1]));
			edges.Add(new Edge(vertices[0], vertices[2]));
			foreach (Vertex v in vertices)
			{
				minY = v.pointAR.Y < minY ? (int)v.pointAR.Y : minY;
				maxY = v.pointAR.Y > maxY ? (int)v.pointAR.Y : maxY;
			}

			foreach (Edge e in edges)
			{
				if (!ET.ContainsKey((int)e.yMin))
				{
					ET.Add((int)e.yMin, new List<Edge>());
				}
				ET[(int)e.yMin].Add(e);
			}
			//foreach (var list in ET.Values)
			//{
			//	list.Sort((Edge e1, Edge e2) => (int)(e1.x - e2.x));
			//} 
			// TODO Fix Sorting - Presort for faster AED sorting

			int y = minY;
			Edge first = null;
			List<Edge> tempForSorting = new List<Edge>();
			while (AET.Count != 0 || ET.Count != 0)
			{
				first = UpdateAET(AET, ET, y++, fbtmp, first, blueprint, tempForSorting);
			}
		}

		public Edge UpdateAET(Dictionary<int, List<Edge>> AET, Dictionary<int, List<Edge>> ET, int y, FastBitmap fbtmp, Edge prefFirst, Blueprint blueprint, List<Edge> tempForSorting)
		{
			tempForSorting.Clear();
			if (ET.ContainsKey(y))
			{
				foreach (Edge e in ET[y])
				{
					if (!AET.ContainsKey((int)e.yMax))
						AET.Add((int)e.yMax, new List<Edge>());
					AET[(int)e.yMax].Add(e); // TODO
				}
				ET.Remove(y);
			}
			foreach (List<Edge> edges in AET.Values)
			{
				tempForSorting.AddRange(edges);
			}
			tempForSorting = tempForSorting.OrderBy(e => e.x).ToList<Edge>();
			for (int i = 0; i < tempForSorting.Count - 1; i++)
			{
				tempForSorting[i].next = tempForSorting[i + 1];
			}
			Edge first = prefFirst;
			if (tempForSorting.Count > 0)
			{
				tempForSorting.Last().next = null;
				first = tempForSorting[0];
			}
			Edge edge = first;

			var status = FillingStage.Inside;
			while (edge.next != null)
			{
				if (status == FillingStage.Inside)
				{
					for (int i = (int)edge.x; i <= edge.next.x; i++)
					{
						int X = i + fbtmp.Width / 2;
						int Y = -y + fbtmp.Height / 2;
						Color color = CalculateFinalColor(blueprint, new Vector2(i, y));
						if (X >= 0 && Y >= 0 && X < fbtmp.Width && Y < fbtmp.Height)
							fbtmp.SetPixel(X, Y, color);
					}
					// TODO Temporary While Stripes Solution
					if ((int)edge.yMax != (int)edge.next.yMin && (int)edge.yMin != (int)edge.next.yMax)
						status = status == FillingStage.Inside ? FillingStage.Outside : FillingStage.Inside;
				}
				edge = edge.next;
			}
			AET.Remove(y); // When yMax == just collored y, remove bcs edge finished

			foreach (List<Edge> edges in AET.Values)
			{
				foreach (var e in edges)
				{
					e.IncreaseX();
				}
			}
			return first;
		}
		public Color CalculateFinalColor(Blueprint bp, Vector2 point)
		{
			(var normal, var z, var color) = InterpolateNormalAndZ(vertices[0], vertices[1], vertices[2], point, bp);
			if (!bp.useTexture)
			{
				color = bp.survaceColor;
			}
			var ioil = (new Vector3(bp.lightColor.R, bp.lightColor.G, bp.lightColor.B) / 255f) *
			(new Vector3(color.R, color.G, color.B) / 255f);

			Vector3 L = Vector3.Normalize(bp.lightPosition - new Vector3(point, z)); // TODO check
			var NL = Vector3.Dot(normal, L);
			Vector3 R = 2 * NL * normal - L;
			var V = new Vector3(0, 0, 1);
			var colorResult = (bp.kd * ioil * Math.Clamp(NL, 0, 1) + bp.ks * ioil * (float)Math.Pow(Math.Clamp(Vector3.Dot(V, R), 0, 1), bp.m));

			int r = (int)Math.Clamp(Math.Round(colorResult.X * 255), 0, 255);
			int g = (int)Math.Clamp(Math.Round(colorResult.Y * 255), 0, 255);
			int b = (int)Math.Clamp(Math.Round(colorResult.Z * 255), 0, 255);
			return Color.FromArgb(255, r, g, b);
		}

		private Color CalculateColor(Vertex vertex1, Vertex vertex2, Vertex vertex3, Vector2 point, Blueprint bp)
		{
			throw new NotImplementedException();
		}

		public (Vector3, float, Color) InterpolateNormalAndZ(Vertex v1, Vertex v2, Vertex v3, Vector2 P, Blueprint bp)
		{
			var v1N = v1.normalAR;
			var v2N = v2.normalAR;
			var v3N = v3.normalAR;
			if (bp.useNormalMap)
			{
				v1N = v1.normalModified;
				v2N = v2.normalModified;
				v3N = v3.normalModified;
			}
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
			Color color = Color.FromArgb(255,
				(int)Math.Clamp((a * vertices[0].textureColor.R + b * vertices[1].textureColor.R + c * vertices[2].textureColor.R), 0, 255),
				(int)Math.Clamp((a * vertices[0].textureColor.G + b * vertices[1].textureColor.G + c * vertices[2].textureColor.G), 0, 255),
				(int)Math.Clamp((a * vertices[0].textureColor.B + b * vertices[1].textureColor.B + c * vertices[2].textureColor.B), 0, 255));
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
