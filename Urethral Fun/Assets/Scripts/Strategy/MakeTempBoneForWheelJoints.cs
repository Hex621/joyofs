using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class MakeTempBoneForWheelJoints : ITempBoneMaker
    {
        public GameObject TempBoneMakerStrategy(List<Component> bones, Component bone)
        {
            var tempBone = UnityEngine.Object.Instantiate(bone.gameObject, new Vector3(bone.gameObject.transform.position.x, bone.gameObject.transform.position.y, bone.gameObject.transform.position.z), bone.transform.rotation);
            if (tempBone.transform.childCount > 0) { UnityEngine.Object.Destroy(tempBone.transform.GetChild(0).gameObject); }
            tempBone.transform.SetParent(bones[0].transform);

            Rigidbody2D temp0 = tempBone.gameObject.AddComponent(typeof(Rigidbody2D)) as Rigidbody2D;
            tempBone.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            return tempBone;
        }
    }
}
