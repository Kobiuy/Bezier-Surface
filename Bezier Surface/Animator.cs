using FastBitmapLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Bezier_Surface
{
	internal class Animator
	{
		private CancellationTokenSource cts;
		private Thread animationThread;
		private Blueprint blueprint;
		private Form form;
		public int speed = 50;
		public bool running { get; private set; }
		public Animator(Blueprint blueprint, Form form)
		{
			this.blueprint = blueprint;
			ChangeState();
			this.form = form;
		}
		public void ChangeState()
		{
			if (running)
			{
				cts.Cancel();
				running = false;
				animationThread.Join();
			}
			else
			{
				cts = new CancellationTokenSource();
				animationThread = new Thread(Animate);
				running = true;
				animationThread.IsBackground = true;
				animationThread.Start();
			}
		}

		private void Animate()
		{
			float angle = 0f;
			int radius = 0;
			bool goBack = false;
			int offset = 0;
			int speedDelay = 0;
			CancellationToken token = cts.Token;
			while (!cts.IsCancellationRequested)
			{
				blueprint.lightPosition.X = radius * (float)MathF.Cos(angle);
				blueprint.lightPosition.Y = radius * (float)MathF.Sin(angle);
				angle += 0.0036f * (speed - speed / 300f * speedDelay);
				AnimateControlPoints((offset++)/10f);
				blueprint.AnimatorDraw();
				form.BeginInvoke(blueprint.Refresh);
				Thread.Sleep(25);
				if (goBack)
				{
					radius--;
					speedDelay--;
				}
				else
				{
					radius++;
					speedDelay++;
				}
				if (radius == 0 || radius == 300)
				{
					goBack = !goBack;
				}
				if (offset == 360*10)
				{
					offset = 0;
				}
			}
		}

		private void AnimateControlPoints(float offset)
		{
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					var p = blueprint.CPs[i * 4 + j].pointBR;
					blueprint.CPs[i * 4 + j].pointBR = new Vector3(p.X, p.Y, p.Z + 10*(float)Math.Sin(360 / ((j+i) + 1) + offset));
				}
			}
		}
	}
}
