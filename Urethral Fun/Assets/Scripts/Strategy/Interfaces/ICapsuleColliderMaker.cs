using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    interface ICapsuleColliderMaker
    {
        void CapsuleColliderMakerStrategy(int section, int counter, List<UnityEngine.Component> bones, UnityEngine.Component bone);
    }
}
