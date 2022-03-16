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
    [SerializeField] private float defaultTopStretch = 3f;
    [SerializeField] private float defaultBottomStretch = 1f;
    [SerializeField] private float defaultTopDamping = 0.8f;
    [SerializeField] private float defaultBottomDamping = 0.5f;
    [SerializeField] private float forceVariation = 200f;
    [SerializeField] private float forceMagnitude = 200f;

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


            //Debug.Log(bone.transform.name);
            Debug.Log(bone.transform.childCount);
            if(bone.transform.childCount == 0)
            {
                Debug.Log(bone.transform.name);
                section++;
            }
            if (section < 2)
            {
                JointSuspension2D suspension = bone.gameObject.GetComponent<WheelJoint2D>().suspension;

                

                if (section == 0)
                {
                    suspension.frequency = defaultTopStretch*TopStretchSlider.GetComponent<UnityEngine.UI.Slider>().value;
                    suspension.dampingRatio = defaultTopDamping* TopStretchSlider.GetComponent<UnityEngine.UI.Slider>().value;
                } else
                {
                    suspension.frequency = defaultBottomStretch* BottomStretchSlider.GetComponent<UnityEngine.UI.Slider>().value;
                    suspension.dampingRatio = defaultBottomDamping* BottomStretchSlider.GetComponent<UnityEngine.UI.Slider>().value;
                }

                bone.gameObject.GetComponent<WheelJoint2D>().suspension = suspension;
            } 

        }
    }
    public void AreaVelocityManager()
    {
        AreaEffector2D area = Cock.GetComponent<AreaEffector2D>();
        area.forceMagnitude = forceMagnitude * AreaVelocitySlider.GetComponent<UnityEngine.UI.Slider>().value;
        area.forceVariation = forceVariation * AreaVelocitySlider.GetComponent<UnityEngine.UI.Slider>().value;


    }
}

