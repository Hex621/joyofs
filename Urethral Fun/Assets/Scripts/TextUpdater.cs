using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUpdater : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Text text;
    [SerializeField] GameObject slider;
    public void UpdateTextBasedOnSlider()
    {
        text.text = slider.GetComponent<UnityEngine.UI.Slider>().value.ToString();
    }
}
