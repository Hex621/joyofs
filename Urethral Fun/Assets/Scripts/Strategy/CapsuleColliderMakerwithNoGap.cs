using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class CapsuleColliderMakerwithNoGap : ICapsuleColliderMaker
    {
        public void CapsuleColliderMakerStrategy(int section, int counter, List<UnityEngine.Component> bones, UnityEngine.Component bone)
        {
            float distance = Vector2.Distance(bones[counter + 1].transform.position, bone.transform.position);
            //Debug.Log(distance);
            
            if (section == 0)
            {
                CapsuleMaker(bone, distance);
                bone.gameObject.GetComponent<CapsuleCollider2D>().offset = new Vector2(distance / 2, 0.025f);
            }
            else if (section == 1)
            {
                CapsuleMaker(bone, distance);
                bone.gameObject.GetComponent<CapsuleCollider2D>().offset = new Vector2(distance / 2, -0.023f);
            }
            else if (section > 1)
            {
                
            }
        }

        private static void CapsuleMaker(UnityEngine.Component bone, float distance)
        {
            CapsuleCollider2D temp2 = bone.gameObject.AddComponent(typeof(CapsuleCollider2D)) as CapsuleCollider2D;
            bone.gameObject.GetComponent<CapsuleCollider2D>().direction = CapsuleDirection2D.Horizontal;
            bone.gameObject.GetComponent<CapsuleCollider2D>().size = new Vector2(distance * 0.9f, distance * 0.8f);
        }
    }
}
