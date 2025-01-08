using System.Numerics;

namespace Bezier_Surface
{
	public class Vertex
	{
		public bool reseted { get; set; }
		public Vector3 pointBR { get; set; }
		public Vector3 puBR { get; set; }
		public Vector3 pvBR { get; set; }
		public Vector3 normalBR { get; set; }
		public Vector3 normalAR { get; set; }
		public Vector3 pvAR { get; set; }
		public Vector3 puAR { get; set; }
		public Vector3 pointAR { get; set; }
		public float u;
		public float v;
		public Vertex(Vector3 point, float u, float v, Vector3 pu, Vector3 pv)
		{
			this.pointBR = point;
			puBR = Vector3.Normalize(pu);
			pvBR = Vector3.Normalize(pv);
			normalBR = Vector3.Normalize(Vector3.Cross(puBR, pvBR));
			this.u = u;
			this.v = v;
		}
		public Vertex(float x, float y, float z, float u, float v)
		{
			this.pointBR = new Vector3(x, y, z);
			normalBR = Vector3.Cross(puBR, pvBR);
			this.u = u;
			this.v = v;
		}

		public Vertex(float x, float y, float z)
		{

			//float u, v;

			//B3[j, i] = MathHelper.CalcB(j, 3, u);


			//Vector3 vector = new Vector3();
			//Vector3 pu = new Vector3();
			//Vector3 pv = new Vector3();


			//vector += CPs[4 * i + j].pointBR * B3[i, r] * B3[j, c];
			//if (j != 3)
			//{
			//	pu += 3 * (CPs[(j + 1) * 4 + i].pointBR - CPs[j * 4 + i].pointBR) * MathHelper.CalcB(j, 2, u) * B3[i, c];
			//	pv += 3 * (CPs[i * 4 + j + 1].pointBR - CPs[i * 4 + j].pointBR) * B3[i, r] * MathHelper.CalcB(j, 2, v);
			//}
			//puBR = pu;
			//pvBR= pv;
			//puBR = new Vector3(0, 0, 1);
			//pvBR = new Vector3(0, 0, 1);
			this.pointBR = new Vector3(x, y, z);
			normalBR = Vector3.Cross(puBR, pvBR);
			this.u = 0;
			this.v = 0;
		}

		public void calcNormal(Vertex v1, Vertex v2, Vertex v3)
		{
			var a = v2.pointBR - v1.pointBR;
			var b = v2.pointBR - v3.pointBR;
			puBR = b;
			pvBR = a;
			normalBR = Vector3.Normalize(Vector3.Cross(puBR, pvBR));
		}

		public void Rotate(Matrix4x4 MX, Matrix4x4 MZ)
		{
			if (!reseted)
			{
				RotateZ(MZ);
				RotateX(MX);
				puAR = Vector3.Normalize(puAR);
				pvAR = Vector3.Normalize(pvAR);
				normalAR = Vector3.Normalize(Vector3.Cross(puAR, pvAR));

				reseted = true;
			}
		}

		private void RotateZ(Matrix4x4 MZ)
		{
			puAR = puBR;
			pvAR = pvBR;
			pointAR = pointBR;
			var result = MZ * MatrixFromVector(puBR);
			puAR = new Vector3(result.M11, result.M21, result.M31);
			result = MZ * MatrixFromVector(pvBR);
			pvAR = new Vector3(result.M11, result.M21, result.M31);
			result = MZ * MatrixFromVector(pointBR);
			pointAR = new Vector3((int)result.M11, (int)result.M21, (int)result.M31);
		}
		private void RotateX(Matrix4x4 MX)
		{
			var result = MX * MatrixFromVector(puAR);
			puAR = new Vector3(result.M11, result.M21, result.M31);
			result = MX * MatrixFromVector(pvAR);
			pvAR = new Vector3(result.M11, result.M21, result.M31);
			result = MX * MatrixFromVector(pointAR);
			pointAR = new Vector3((int)result.M11, (int)result.M21, (int)result.M31);
		}
		private static Matrix4x4 MatrixFromVector(Vector3 v)
		{
			return new Matrix4x4(v.X, 0, 0, 0, v.Y, 0, 0, 0, v.Z, 0, 0, 0, 0, 0, 0, 0);
		}

		public static Vector3 CreateNormalUsingNormalMap(Vector3 puAR, Vector3 pvAR, Vector3 normalAR, Vector3 normalMapN)
		{
			return new Vector3(
				puAR.X * normalMapN.X + pvAR.X * normalMapN.Y + normalAR.X * normalMapN.Z,
				puAR.Y * normalMapN.X + pvAR.Y * normalMapN.Y + normalAR.Y * normalMapN.Z,
				puAR.Z * normalMapN.X + pvAR.Z * normalMapN.Y + normalAR.Z * normalMapN.Z
			);
		}

		internal void Reset()
		{
			reseted = false;
		}
	}
}
