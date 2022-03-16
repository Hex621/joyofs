using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FelkinCockButton : MonoBehaviour
{
    public void LoadFelkin()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }
}
