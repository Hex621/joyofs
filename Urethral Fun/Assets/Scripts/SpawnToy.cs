using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnToy : MonoBehaviour
{
    [SerializeField] private GameObject slider;
    [SerializeField] private GameObject[] objects;
    [SerializeField] private GameObject dropdown;
   
    public void spawnSimpleObject()
    {

        GameObject spawnedObject = Instantiate(objects[dropdown.GetComponent<UnityEngine.UI.Dropdown>().value], new Vector3(8, 1.5f, 0), Quaternion.Euler( new Vector3(0, 0, 45)));
        spawnedObject.transform.localScale = new Vector3(slider.GetComponent<UnityEngine.UI.Slider>().value, slider.GetComponent<UnityEngine.UI.Slider>().value, 1f);
    }
}
