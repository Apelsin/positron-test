using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

using OpenTK;
using Positron;

namespace PunkyTown
{
    [DataContract]
    class SpinnyCamera : Camera
    {
        public SpinnyCamera(Xform parent):
            base(parent)
        {

        }
        public override void Update()
        {
            base.Update();
            mTransform._Local *= Matrix4.CreateRotationY(0.01f);
        }
    }
}
