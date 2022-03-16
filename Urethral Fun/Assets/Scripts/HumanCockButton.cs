using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HumanCockButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadHumanoid()
    {
        SceneManager.LoadScene(sceneBuildIndex: 2);
    }
}
