using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class MakeAreaEffectorWithBurntInLayer : IMakeAreaEffector
    {
        public void MakeAreaEffectorStrategy(GameObject current)
        {
            AreaEffector2D temp1 = current.gameObject.AddComponent(typeof(AreaEffector2D)) as AreaEffector2D;
            current.gameObject.GetComponent<AreaEffector2D>().useColliderMask = true;
            current.gameObject.GetComponent<AreaEffector2D>().forceMagnitude = 0;
            current.gameObject.GetComponent<AreaEffector2D>().forceVariation = 0;
            int layer = 8;
            current.gameObject.GetComponent<AreaEffector2D>().colliderMask = 1 << layer;
        }
    }
}
