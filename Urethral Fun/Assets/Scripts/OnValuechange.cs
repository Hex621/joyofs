using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnValuechange : MonoBehaviour
{

    [SerializeField] private GameObject slider;

    public void onValueChange()
    {
        if(this.GetComponent<UnityEngine.UI.Dropdown>().value == 0 || this.GetComponent<UnityEngine.UI.Dropdown>().value == 2)
        {
            slider.GetComponent<UnityEngine.UI.Slider>().maxValue = 0.13f;
            slider.GetComponent<UnityEngine.UI.Slider>().minValue = 0.01f;
            slider.GetComponent<UnityEngine.UI.Slider>().value = 0.06f;
        } else
        {
            slider.GetComponent<UnityEngine.UI.Slider>().maxValue = 1.8f;
            slider.GetComponent<UnityEngine.UI.Slider>().minValue = 0.5f;
            slider.GetComponent<UnityEngine.UI.Slider>().value = 0.9f;
        }
        
    }

}
