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
		public Vector3 normalMapN;
		public Color textureColor;
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

		internal void SetNormalVectors(Bitmap noramlmap)
		{
			int x = (int)(v * (noramlmap.Width - 1));
			int y = (int)(u * (noramlmap.Height - 1));
			Color color = noramlmap.GetPixel(x, y);
			var X = (color.R / 127.5f) - 1;
			var Y = (color.G / 127.5f) - 1;
			var Z = (color.B / 127.5f) - 1;
			normalMapN = Vector3.Normalize(new Vector3(X, Y, Z));
		}
		public void ModifyNormal()
		{
			normalModified = new Vector3(
				puAR.X * normalMapN.X + pvAR.X * normalMapN.Y + normalAR.X * normalMapN.Z,
				puAR.Y * normalMapN.X + pvAR.Y * normalMapN.Y + normalAR.Y * normalMapN.Z,
				puAR.Z * normalMapN.X + pvAR.Z * normalMapN.Y + normalAR.Z * normalMapN.Z
			);
		}

		internal void Reset()
		{
			reseted = false;
		}

		internal void SetColorFromTexture(Bitmap texture)
		{
			int x = (int)(v * (texture.Width - 1));
			int y = (int)(u * (texture.Height - 1));
			textureColor = texture.GetPixel(x, y);
		}
	}
}
