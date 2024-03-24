using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Cutscene1"); //just loadin tha sample scene 4 now
    }
    public void Options()
    {
        //if you press this FUCK YOU YOU SUCK
    }
    public void Quit()
    {
        Application.Quit();
    }


}
