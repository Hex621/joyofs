using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    interface ISpringMaker
    {
        void SpringMakerStrategy(int counter, List<Component> bones, Component bone, float frequency, float damping);
    }
}
