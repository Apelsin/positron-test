using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

using Positron;
using OpenTK;

namespace PunkyTown
{
    public static class SceneMainFactory
    {
        public static Scene Create(PositronGame game)
        {
            var scene = new Scene(game, "SceneMain");
            
            //var c0 = new SpinnyCircle(scene.Root, 0, 0, 20, 0.001f) { Color = Color.White, };
            //var c1 = new SpinnyCircle(c0, 1, 0, 20, 0.002f) { Color = Color.Blue, };
            //var c2 = new SpinnyCircle(c1, 1, 0, 20, 0.003f) { Color = Color.Green, };
            //var c3 = new SpinnyCircle(c2, 1, 0, 20, 0.004f) { Color = Color.Cyan, };
            //var c4 = new SpinnyCircle(c3, 1, 0, 20, 0.005f) { Color = Color.Yellow, };
            //var c5 = new SpinnyCircle(c4, 1, 0, 20, 0.006f) { Color = Color.Salmon, };
            //c5.mTransform.AddChild(scene.Camera.mTransform);
            //scene.Camera.mTransform.PositionLocalZ = 0;
            //scene.Camera.mTransform.PositionLocalY = 3f;
            //scene.Camera.mTransform.PositionLocalX = 3f;
            var sprite = new SpriteBase(scene.Root);
            sprite.mTransform._Local = Matrix4.CreateRotationX(0.5f * (float)Math.PI);
            sprite.mTransform.PositionLocalY = -1;
            scene.Camera = new SpinnyCamera(scene.Root);
            scene.Camera.FieldOfViewDeg = 45;
            scene.Camera.mTransform._Local = Matrix4.CreateRotationX(-0.5f);
            return scene;
        }
    }
}
