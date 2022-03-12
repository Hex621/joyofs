using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    interface IWheelJointMaker
    {
        void WheelJointManager(int section, Component bone, GameObject tempBone);
    }
}
