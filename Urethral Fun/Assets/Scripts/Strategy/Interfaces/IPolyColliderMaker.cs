using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    interface IPolyColliderMaker
    {
        void PolyColliderMakerStrategy(List<int> sectionnumbers, List<Vector2> points, GameObject current);
    }
}
