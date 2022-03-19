using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ToySetup : MonoBehaviour
{
    private IRigidbodyMaker CurrentRigidbodyMaker = new RigidbodyMakerWithBurntInValues();
    // Start is called before the first frame update
    void Start()
    {
        Component[] bones2 = GetComponentsInChildren<Transform>();
        List<Component> bones = bones2.ToList();
        foreach (Component bone in bones)
        {

            CurrentRigidbodyMaker.RigidbodyMakerStrategy(bone);

        }

    }

    // Update is called once per frame
  
}
