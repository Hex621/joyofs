using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class MakeWheelJointsattheBonesPositionsAndBasedOnSectionNumber : IWheelJointMaker
    {
        public void WheelJointManager(int section, Component bone, GameObject tempBone, float topFrequency, float bottomFrequency,float topDampingRatio, float bottomDampingRatio)
        {
            WheelJoint2D temp3 = bone.gameObject.AddComponent(typeof(WheelJoint2D)) as WheelJoint2D;
            JointSuspension2D suspension = temp3.suspension;
            if (section == 0) //make it into a array or something
            {
                suspension.frequency = topFrequency;
                suspension.dampingRatio = topDampingRatio;
            }
            else if (section == 1)
            {
                suspension.frequency = bottomFrequency;
                suspension.dampingRatio = bottomDampingRatio;
            }
            temp3.suspension = suspension;
            bone.gameObject.GetComponent<WheelJoint2D>().connectedBody = tempBone.GetComponent<Rigidbody2D>();
        }
    }
}
