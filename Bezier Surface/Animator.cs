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
			//Bitmap bitmap = new Bitmap(blueprint.Canvas.Width, blueprint.Canvas.Height);
			CancellationToken token = cts.Token;
			while (!cts.IsCancellationRequested)
			{
				blueprint.lightPosition.X = 300 * (float)MathF.Cos(angle);
				blueprint.lightPosition.Y = 300 * (float)MathF.Sin(angle);
				angle += 0.3f;
				blueprint.AnimatorDraw();
				form.BeginInvoke(blueprint.Refresh);
				//form.BeginInvoke(blueprint.DrawAndRefresh);
				Thread.Sleep(100);
			}
		}
	}
}
