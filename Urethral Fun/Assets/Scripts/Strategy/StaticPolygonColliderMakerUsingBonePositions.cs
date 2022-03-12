using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class StaticPolygonColliderMakerUsingBonePositions : IPolyColliderMaker
    {
        public void PolyColliderMakerStrategy(List<int> sectionnumbers, List<Vector2> points, GameObject current)
        {
            points.Reverse((sectionnumbers[0]) + 1, sectionnumbers[1] - sectionnumbers[0]);
            PolygonCollider2D temp1 = current.gameObject.AddComponent(typeof(PolygonCollider2D)) as PolygonCollider2D;
            points.RemoveAt(points.Count - 1); //Should try to figure why is this scuffed
                                               //points.Add(points[0]);
            current.gameObject.GetComponent<PolygonCollider2D>().points = points.ToArray();
            current.gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
            current.gameObject.GetComponent<PolygonCollider2D>().usedByEffector = true;
        }
    }
}
