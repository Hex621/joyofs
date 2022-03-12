using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    interface ISpringModifier
    {
        void SpringModifierStrategy(SpringJoint2D spring1, float frequency, float damping);
    }
}
