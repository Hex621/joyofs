using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SlidersFunction : MonoBehaviour
{
    [SerializeField] private GameObject AreaVelocitySlider;
    [SerializeField] private GameObject TopStretchSlider;
    [SerializeField] private GameObject BottomStretchSlider;
    [SerializeField] private GameObject Cock;

    public void StretchSliderManager()
    {
        int section = 0;

        int counter = 0;
        Component[] bones2 = Cock.gameObject.GetComponentsInChildren<Transform>();
        List<Component> bones = bones2.ToList();
        bones.RemoveAt(0);
        bool afterChild = false;

        foreach (Component bone in bones)
        {


            Debug.Log(bone.transform.name);
            Debug.Log(bone.transform.GetChildCount());


        }
    }
}

