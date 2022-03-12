using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class SpringMakerBetweenBones : ISpringMaker
    {
        private ISpringModifier currentSpringModifier = new SpringStiffnessModifierWithFrequencyandDamping(); 
        public void SpringMakerStrategy(int counter, List<Component> bones, Component bone, float frequency, float damping)
        {
            SpringJoint2D spring1 = bone.gameObject.AddComponent(typeof(SpringJoint2D)) as SpringJoint2D;
            currentSpringModifier.SpringModifierStrategy(spring1, frequency, damping);
            spring1.connectedBody = bones[counter - 1].GetComponent<Rigidbody2D>();
            //test
        }
    }
}
