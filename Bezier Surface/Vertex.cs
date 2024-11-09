using System.Numerics;

namespace Bezier_Surface
{
	public class Vertex
	{
		public Vector3 pointBR;
		public Vector3 puBR;
		public Vector3 pvBR;
		public Vector3 normalBR;
		public Vector3 normalAR;
		public Vector3 pvAR;
		public Vector3 puAR;
		public Vector3 pointAR;
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
		public void Rotate(int alfa, int beta)
		{
			RotateZ(alfa);
			RotateX(beta); // TODO Sortuj po z
			normalAR = Vector3.Cross(puAR, pvAR);
		}
		private void RotateZ(int alfa)
		{
			if (alfa == 0)
			{
				puAR = puBR;
				pvAR = pvBR;
				normalAR = normalBR;
				pointAR = pointBR;
				return;
			}
			//var MZ = GetMZ(alfa);
			var MZ = Matrix4x4.CreateRotationZ((alfa * MathF.PI) / 180f);
			var result = MZ * MatrixFromVector(puBR);
			puAR = new Vector3(result.M11, result.M21, result.M31);
			result = MZ * MatrixFromVector(pvBR);
			pvAR = new Vector3(result.M11, result.M21, result.M31);
			result = MZ * MatrixFromVector(pointBR);
			pointAR = new Vector3((int)result.M11, (int)result.M21, (int)result.M31);
		}
		private void RotateX(int beta)
		{
			if (beta == 0)
			{
				return;
			}
			//var MX = GetMX(beta);
			var MX = Matrix4x4.CreateRotationX((beta * MathF.PI) / 180f);
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
	}
}
