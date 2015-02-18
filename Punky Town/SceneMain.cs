using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Positron;

using OpenTK;

namespace PunkyTown
{
    class SceneMain : Scene
    {
        public SceneMain(PositronGame game):
            base(game, "Main")
        {
            Camera = new Camera(Root);
            Camera.mTransform.PositionLocalZ = -5f;
            var c0 = new SpinnyCircle(Root, 0, 0, 20, 0.001f) { Color = Color.White, };
            var c1 = new SpinnyCircle(c0, 1, 0, 20, 0.002f) { Color = Color.Blue, };
            var c2 = new SpinnyCircle(c1, 1, 0, 20, 0.003f) { Color = Color.Green, };
            var c3 = new SpinnyCircle(c2, 1, 0, 20, 0.004f) { Color = Color.Cyan, };
            var c4 = new SpinnyCircle(c3, 1, 0, 20, 0.005f) { Color = Color.Yellow, };
            var c5 = new SpinnyCircle(c4, 1, 0, 20, 0.006f) { Color = Color.Salmon, };
        }
    }
}
