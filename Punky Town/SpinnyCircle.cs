using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Positron;
using OpenTK;

namespace PunkyTown
{
    class SpinnyCircle : Circle
    {
        float Spin;
        public SpinnyCircle(Xform parent, float x, float y, float radius, float spin):
            base (parent, x, y, radius)
        {
            Spin = spin;
        }
        public SpinnyCircle(GameObject parent, float x, float y, float radius, float spin) :
            this(parent.mTransform, x, y, radius, spin)
        {
        }
        public override void Update()
        {
            base.Update();
            mTransform._Local *= Matrix4.CreateRotationZ(Spin);
        }
    }
}