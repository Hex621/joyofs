using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class SpringStiffnessModifierWithFrequencyandDamping : ISpringModifier
    {
        public void SpringModifierStrategy(SpringJoint2D spring1, float frequency, float damping)
        {
            spring1.frequency = 8f;
            spring1.dampingRatio = 0.8f;
        }
    }
}
