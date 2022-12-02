using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void SelectLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void SelectLevel2()
    {
        //SceneManager.LoadScene("Level2");
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
