using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider musicSlider;
    public Slider sfxSlider;
    public Slider voiceSlider;
    
    public bool isPaused;
    public GameObject pauseMenu;
    
    private CustomInput input;
    
    void Awake()
    {
        pauseMenu.SetActive(false);
        input = new CustomInput();
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.Pause.started += OnPausePress;
    }

    private void OnDisable()
    {
        input.Disable();
        input.Player.Pause.started -= OnPausePress;
    }

    private void OnPausePress(InputAction.CallbackContext value)
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }
    
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }
    
    // Slider controls
    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        audioMixer.SetFloat("musicVolume", volume);
    }
    
    public void SetSFXVolume()
    {
        float volume = sfxSlider.value;
        audioMixer.SetFloat("sfxVolume", volume);
    }
    
    public void SetVoiceVolume()
    {
        float volume = voiceSlider.value;
        audioMixer.SetFloat("voiceVolume", volume);
    }
    
    // Buttons
    public void Continue()
    {
        ResumeGame();
    }
}
