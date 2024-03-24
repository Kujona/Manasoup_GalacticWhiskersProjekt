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
    public GameObject Hints;
    public GameObject Time;
    public GameObject Bloodspills;
    private GameObject CutsceneSetup;

    public AudioSource bgm;
    public AudioClip gegenwartMusic;

    // Start is called before the first frame update
    void Awake()
    {
        Overlay = GameObject.FindWithTag("CamOverlay");
        Player = GameObject.FindWithTag("Player");
        Overlay.GetComponent<Animator>().SetBool("vergangenheit", true);
        HolzCount = GameObject.FindWithTag("HolzCount");
        Hints = GameObject.FindWithTag("Hints");
        Time = GameObject.FindWithTag("Time");
        Bloodspills = GameObject.FindWithTag("Bloodspills");
        CutsceneSetup = GameObject.FindWithTag("CutsceneSetup");
        Bloodspills.SetActive(false);
        
        bgm = GameObject.FindWithTag("BGM").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("reached exit");
            if (vergangenheit)
            {
                Player.GetComponent<NewPlayerMovement>().Respawn(); //Spieler Respawned
                Player.GetComponent<PlayerActions>().TimeChange(false); //true = Vergangenheit, false = Gegenwart
                Overlay.GetComponent<Animator>().SetBool("vergangenheit", false);
                HolzCount.GetComponent<TextMeshProUGUI>().text = " ";
                Hints.GetComponent<TextMeshProUGUI>().text = "Survive!";
                Time.GetComponent <TextMeshProUGUI>().text = "Heute (ZDay)";
                Time.GetComponent<Animator>().SetTrigger("Trigger");
                Bloodspills.SetActive(true);

                bgm.Stop();
                bgm.clip = gegenwartMusic;
                bgm.Play();
                
                vergangenheit = false;
            } else
            {
                bgm.Stop();
                CutsceneSetup.GetComponent<CutsceneSetup>().EndLevelCutscene();
                //SceneManager.LoadScene("Menu"); //insert name of next Scene
            }
        }
    }

}
