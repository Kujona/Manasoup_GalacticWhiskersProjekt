using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class CutsceneManager : MonoBehaviour
{
    public string next;
    private CustomInput input = null;


    private void Awake()
    {
        input = new CustomInput();
    }


    private void OnEnable()
    {
        input.Enable();
        input.Player.PlaceHolz.canceled += OnButtonEPress;
    }

    private void OnDisable()
    {
        input.Disable();
        input.Player.PlaceHolz.canceled -= OnButtonEPress;
    }

    private void OnButtonEPress(InputAction.CallbackContext value)
    { 
        NextScene();
    }

    public void NextScene()
    {
        SceneManager.LoadScene(next);
    }
}
