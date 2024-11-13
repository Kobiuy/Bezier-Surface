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
			CancellationToken token = cts.Token;
			while (!cts.IsCancellationRequested)
			{
				blueprint.lightPosition.X = 300 * (float)MathF.Cos(angle);
				blueprint.lightPosition.Y = 300 * (float)MathF.Sin(angle);
				angle += 0.0036f*speed;
				blueprint.AnimatorDraw();
				form.BeginInvoke(blueprint.Refresh);
				Thread.Sleep(25);
			}
		}
	}
}
