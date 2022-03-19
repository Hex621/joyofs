using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ToySetup : MonoBehaviour
{
    private IRigidbodyMaker CurrentRigidbodyMaker = new RigidbodyMakerWithBurntInValues();
    private List<HingeJoint2D> hinges1 = new List<HingeJoint2D>();
    private List<HingeJoint2D> hinges2 = new List<HingeJoint2D>();

    // Start is called before the first frame update
    void Start()
    {
        Component[] bones2 = GetComponentsInChildren<Transform>();
        List<Component> bones = bones2.ToList();
        bones.RemoveAt(0);
        for (int i = 0; i < bones.Count; i++)
        {

            CurrentRigidbodyMaker.RigidbodyMakerStrategy(bones.ElementAt(i));

            CapsuleCollider2D temp2 = bones.ElementAt(i).gameObject.AddComponent(typeof(CapsuleCollider2D)) as CapsuleCollider2D;
            bones.ElementAt(i).gameObject.GetComponent<CapsuleCollider2D>().direction = CapsuleDirection2D.Horizontal;
            bones.ElementAt(i).gameObject.GetComponent<CapsuleCollider2D>().size = new Vector2(0.9f*gameObject.transform.localScale.x, 0.8f * gameObject.transform.localScale.y);
            
            if (i>0)
            {
                HingeJoint2D tempHinge = bones.ElementAt(i).gameObject.AddComponent(typeof(HingeJoint2D)) as HingeJoint2D;
                hinges1.Add(tempHinge);

            }
            if (i<bones.Count-1)
            {
                HingeJoint2D tempHinge2 = bones.ElementAt(i).gameObject.AddComponent(typeof(HingeJoint2D)) as HingeJoint2D;
                hinges2.Add(tempHinge2);
            }
           
        }
        for (int i = 0; i < hinges2.Count; i++)
        {
            hinges2.ElementAt(i).connectedBody = bones.ElementAt(i+1).GetComponent<Rigidbody2D>();
        }
        for (int i = 0; i < hinges2.Count; i++)
        {
            hinges1.ElementAt(i).connectedBody = bones.ElementAt(i).GetComponent<Rigidbody2D>();
        }






    }

    // Update is called once per frame
  
}
