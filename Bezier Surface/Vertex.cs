using System.Numerics;

namespace Bezier_Surface
{
	public class Vertex
	{
		public bool reseted { get; set; }
		public Vector3 pointBR;
		public Vector3 puBR;
		public Vector3 pvBR;
		public Vector3 normalBR;
		public Vector3 normalAR;
		public Vector3 normalModified;
		public Vector3 pvAR;
		public Vector3 puAR;
		public Vector3 pointAR;
		public Vector3 textureN;
		public float u;
		public float v;
		public Vertex(Vector3 point, float u, float v, Vector3 pu, Vector3 pv)
		{
			this.pointBR = point;
			puBR = pu;
			pvBR = pv;
			normalBR = Vector3.Cross(puBR, pvBR);
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
		public void Rotate(Matrix4x4 MX, Matrix4x4 MZ)
		{
			if (!reseted)
			{
				RotateZ(MZ);
				RotateX(MX); // TODO Sortuj po z
				puAR = Vector3.Normalize(puAR);
				pvAR = Vector3.Normalize(pvAR);
				normalAR = Vector3.Normalize(Vector3.Cross(puAR, pvAR));
				ModifyNormal();
				reseted = true;
				normalModified = Vector3.Normalize(normalModified);

			}
		}

		private void RotateZ(Matrix4x4 MZ)
		{
			//if (alfa == 0)
			//{
				puAR = puBR;
				pvAR = pvBR;
				//normalAR = normalBR;
				pointAR = pointBR;
				//return;
			//}
			//var MZ = GetMZ(alfa);
			var result = MZ * MatrixFromVector(puBR);
			puAR = new Vector3(result.M11, result.M21, result.M31);
			result = MZ * MatrixFromVector(pvBR);
			pvAR = new Vector3(result.M11, result.M21, result.M31);
			result = MZ * MatrixFromVector(pointBR);
			pointAR = new Vector3((int)result.M11, (int)result.M21, (int)result.M31);
		}
		private void RotateX(Matrix4x4 MX)
		{
			//if (beta == 0)
			//{
				//return;
			//}
			//var MX = GetMX(beta);
			var result = MX * MatrixFromVector(puAR);
			puAR = new Vector3(result.M11, result.M21, result.M31);
			result = MX * MatrixFromVector(pvAR);
			pvAR = new Vector3(result.M11, result.M21, result.M31);
			result = MX * MatrixFromVector(pointAR);
			pointAR = new Vector3((int)result.M11, (int)result.M21, (int)result.M31);
		}
		//private static Matrix4x4 GetMZ(int alfa)
		//{
		//	var angle = (alfa * MathF.PI) / 180f;
		//	var cos = MathF.Cos(angle);
		//	var sin = MathF.Sin(angle);
		//	return new Matrix4x4(cos, -sin, 0, 0,
		//						sin, cos, 0, 0,
		//						0, 0, 1, 0,
		//						0, 0, 0, 1);
		//}
		//private static Matrix4x4 GetMX(int beta)
		//{
		//	var angle = (beta * MathF.PI) / 180f;
		//	var cos = MathF.Cos(angle);
		//	var sin = MathF.Sin(angle);
		//	return new Matrix4x4(1, 0, 0, 0,
		//						0, cos, -sin, 0,
		//						0, sin, cos, 0,
		//						0, 0, 0, 1);
		//}
		private static Matrix4x4 MatrixFromVector(Vector3 v)
		{
			return new Matrix4x4(v.X, 0, 0, 0, v.Y, 0, 0, 0, v.Z, 0, 0, 0, 0, 0, 0, 0);
		}

		internal void SetColor(Bitmap texture)
		{
			int x = (int)(v * (texture.Width - 1));
			int y = (int)(u * (texture.Height - 1));
			Color color = texture.GetPixel(x, y);
			var X = (color.R / 127.5f) - 1;
			var Y = (color.G / 127.5f) - 1;
			var Z = (color.B / 127.5f) - 1;
			textureN = Vector3.Normalize(new Vector3(X, Y, Z));
		}
		public void ModifyNormal()
		{
			normalModified = new Vector3(
				puAR.X * textureN.X + pvAR.X * textureN.Y + normalAR.X * textureN.Z,
				puAR.Y * textureN.X + pvAR.Y * textureN.Y + normalAR.Y * textureN.Z,
				puAR.Z * textureN.X + pvAR.Z * textureN.Y + normalAR.Z * textureN.Z
			);
			//normalModified = Vector3.Normalize(normalModified); // TODO Tried
			//var M = new Matrix4x4(puAR.X, pvAR.X, normalAR.X, 0,
			//	puAR.Y, pvAR.Y, normalAR.Y, 0,
			//	puAR.Z, pvAR.Z, normalAR.Z, 0,
			//	0, 0, 0, 0);
			//var result = M * MatrixFromVector(textureN);
			//normalModified = new Vector3((int)result.M11, (int)result.M21, (int)result.M31);
		}

		internal void Reset()
		{
			reseted = false;
		}
	}
}
