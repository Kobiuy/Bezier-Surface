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
            int speedDelay = 0;
            CancellationToken token = cts.Token;
            while (!cts.IsCancellationRequested)
            {
                blueprint.lightPosition.X = radius * (float)MathF.Cos(angle);
                blueprint.lightPosition.Y = radius * (float)MathF.Sin(angle);
                angle += 0.0036f * (speed - speed/300f*speedDelay);
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
            }
        }
    }
}
