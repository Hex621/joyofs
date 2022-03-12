using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class RigidbodyMakerWithBurntInValues : IRigidbodyMaker
    {
        public void RigidbodyMakerStrategy(Component bone)
        {
            Rigidbody2D temp1 = bone.gameObject.AddComponent(typeof(Rigidbody2D)) as Rigidbody2D;
            bone.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
            bone.gameObject.GetComponent<Rigidbody2D>().drag = 0.5f;
            bone.gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
        }
    }
}
