using System.Collections;
using System.Collections.Generic;
using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScript : MonoBehaviour
{
    public bool vergangenheit;
    public GameObject Player;
    public GameObject Overlay;

    // Start is called before the first frame update
    void Start()
    {
        Overlay = GameObject.FindWithTag("CamOverlay");
        Player = GameObject.FindWithTag("Player");
        Overlay.GetComponent<Animator>().SetBool("vergangenheit", true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("reached exit");
            if (vergangenheit)
            {
                Player.GetComponent<PlayerMovement>().Respawn(); //Spieler Respawned
                Overlay.GetComponent<Animator>().SetBool("vergangenheit", false);
                vergangenheit = false;
            } else
            {
                SceneManager.LoadScene("Menu"); //insert name of next Scene
            }
        }
    }

}
