using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Positron;
using OpenTK;

namespace PunkyTown
{
    class CircleBlip : Circle
    {
        protected float _MaxRadius;
        public float MaxRadius { get { return _MaxRadius; } set { _MaxRadius = value; } }
        public CircleBlip(Xform parent, float x, float y, float max_radius) :
            base(parent, x, y, 1f)
        {

        }
        public override void Update()
        {
            base.Update();
            Radius = Radius + 1f;
            if (Radius > MaxRadius)
                mTransform.Parent.RemoveChild(this.mTransform);
        }
    }
}
