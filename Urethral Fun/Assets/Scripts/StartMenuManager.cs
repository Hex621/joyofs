using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public GameObject MenuUI;
    public void RevealMenu()
    {
       
        MenuUI.SetActive(true);
        this.gameObject.SetActive(false);
        //Time.timeScale = 0.8f;
    }
}
