using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public GameObject MenuUI;
    public bool isOpen = false;
    [SerializeField] public GameObject Text;

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Start()
    {
       
    }

   


    public void reavealMenu()
    {
        if (!isOpen)
        {
            Text.GetComponent<UnityEngine.UI.Text>().text = "<";
            MenuUI.SetActive(true);
            isOpen = true;
        } else
        {
            Text.GetComponent<UnityEngine.UI.Text>().text = ">";
            MenuUI.SetActive(false);
            isOpen = false;
        }
        
    }
}
