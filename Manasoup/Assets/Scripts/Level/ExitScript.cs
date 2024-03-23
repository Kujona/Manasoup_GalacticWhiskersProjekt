using System.Collections;
using System.Collections.Generic;
using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ExitScript : MonoBehaviour
{
    public bool vergangenheit;
    public GameObject Player;
    public GameObject Overlay;
    public GameObject HolzCount;

    // Start is called before the first frame update
    void Start()
    {
        Overlay = GameObject.FindWithTag("CamOverlay");
        Player = GameObject.FindWithTag("Player");
        Overlay.GetComponent<Animator>().SetBool("vergangenheit", true);
        HolzCount = GameObject.FindWithTag("HolzCount");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("reached exit");
            if (vergangenheit)
            {
                Player.GetComponent<PlayerMovement>().Respawn(); //Spieler Respawned
                Player.GetComponent<PlayerActions>().TimeChange(false); //true = Vergangenheit, false = Gegenwart
                Overlay.GetComponent<Animator>().SetBool("vergangenheit", false);
                HolzCount.GetComponent<TextMeshProUGUI>().text = " ";
                vergangenheit = false;
            } else
            {
                SceneManager.LoadScene("Menu"); //insert name of next Scene
            }
        }
    }

}
