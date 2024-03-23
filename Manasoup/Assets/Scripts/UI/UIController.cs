using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public GameObject HolzCount;
    public GameObject GameOverObject;


    void Awake()
    {
        Time.timeScale = 1;
        GameOverObject.SetActive(false);
        //HolzCount = GameObject.FindWithTag("HolzCount");
        //GameOverObject = GameObject.FindWithTag("GameOver");
    }


    public void UpdateHolz(int holz)
    { 
        HolzCount.GetComponent<TextMeshProUGUI>().text = "Holz: " + holz.ToString();
    }

    public void GameOver()
    {
        GameOverObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
