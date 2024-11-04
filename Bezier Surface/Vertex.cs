using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Bezier_Surface
{
	internal class Vertex
	{
		public Vector3 pointBeforeRotation;
		public Vector3 puBeforeRotation;
		public Vector3 pvBeforeRotation;
		public Vector3 normalBeforeRotation;
		public Vector3 normalAfterRotation;
		public Vector3 pvAfterRotation;
		public Vector3 puAfterRotation;
		public Vector3 pointAfterRotation;
		public Vertex(Vector3 point)
		{
			this.pointBeforeRotation = point;
			normalBeforeRotation = puBeforeRotation * pvAfterRotation;
		}
		public Vertex(float x, float y, float z)
		{
			this.pointBeforeRotation = new Vector3(x, y, z);
			normalBeforeRotation = puBeforeRotation * pvAfterRotation;
		}
		public void Rotate(int alfa, int beta)
		{
			RotateZ(alfa);
			RotateX(beta);
			normalAfterRotation = puAfterRotation * pvAfterRotation;

		}
		private void RotateZ(int alfa)
		{
			if (alfa == 0)
			{
				puAfterRotation = puBeforeRotation;
				pvAfterRotation = pvBeforeRotation;
				normalAfterRotation = normalBeforeRotation;
				pointAfterRotation = pointBeforeRotation;
				return;
			}
			var MZ = GetMZ(alfa);
			var result = MZ * MatrixFromVector(puBeforeRotation);
			puAfterRotation = new Vector3(result.M11, result.M21, result.M31);
			result = MZ * MatrixFromVector(pvBeforeRotation);
			pvAfterRotation = new Vector3(result.M11, result.M21, result.M31);
			result = MZ * MatrixFromVector(pointBeforeRotation);
			pointAfterRotation = new Vector3(result.M11, result.M21, result.M31);
		}
		private void RotateX(int beta)
		{
			if (beta == 0)
			{
				return;
			}
			var MX = GetMX(beta);
			var result = MX * MatrixFromVector(puAfterRotation);
			puAfterRotation = new Vector3(result.M11, result.M21, result.M31);
			result = MX * MatrixFromVector(pvAfterRotation);
			pvAfterRotation = new Vector3(result.M11, result.M21, result.M31);
			result = MX * MatrixFromVector(pointAfterRotation);
			pointAfterRotation = new Vector3(result.M11, result.M21, result.M31);
		}
		private static Matrix4x4 GetMZ(int alfa)
		{
			var angle = (alfa * MathF.PI) / 180f;
			var cos = MathF.Cos(angle);
			var sin = MathF.Sin(angle);
			return new Matrix4x4(cos, -sin, 0, 0,
								sin, cos, 0, 0,
								0, 0, 1, 0,
								0, 0, 0, 0);
		}
		private static Matrix4x4 GetMX(int beta)
		{
			var angle = (beta * MathF.PI) / 180f;
			var cos = MathF.Cos(angle);
			var sin = MathF.Sin(angle);
			return new Matrix4x4(1, 0, 0, 0,
								0, cos, -sin, 0,
								0, sin, MathF.Cos(angle), 0,
								0, 0, 0, 0);
		}
		private static Matrix4x4 MatrixFromVector(Vector3 v)
		{
			return new Matrix4x4(v.X, 0, 0, 0, v.Y, 0, 0, 0, v.Z, 0, 0, 0, 0, 0, 0, 0);
		}
	}
}
