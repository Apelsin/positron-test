using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

using Positron;
using OpenTK;

namespace PunkyTown
{
    [DataContract]
    class SpinnyCircle : Circle
    {
        [DataMember]
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
            Radius = 200f / (0.1f + (mTransform.Position - mCamera.mTransform.Position).Length);
        }
        public override void Render()
        {
            base.Render();
        }
    }
}