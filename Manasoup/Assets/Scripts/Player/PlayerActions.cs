using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using static UnityEngine.RuleTile.TilingRuleOutput;
using UnityEngine.InputSystem;


public class PlayerActions : MonoBehaviour
{

    private CustomInput input = null;
    public TileBase barricade;
    public TileBase blueprint;
    public Tilemap barricateTilemap;
    public Tilemap blueprintTilemap;
    public NewPlayerMovement movement;
    public UIController controller;
    public int holz;
    public bool vergangenheit;
    private Vector3Int placePosition1;
    private Vector3Int placePosition2;
    private GameObject CutsceneSetup;

    public RandomSoundPlayer randomSoundPlayer;

    // Start is called before the first frame update
    void Awake()
    {
        //holz = 0;
        input = new CustomInput();
        movement = GetComponent<NewPlayerMovement>();
        controller = GameObject.FindWithTag("UIController").GetComponent<UIController>();
        CutsceneSetup = GameObject.FindWithTag("CutsceneSetup");
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.PlaceHolz.canceled += OnButtonEPress;
        input.Player.Rewind.canceled += OnButtonQPress;
    }

    private void OnDisable()
    {
        input.Disable();
        input.Player.PlaceHolz.canceled -= OnButtonEPress;
        input.Player.Rewind.canceled -= OnButtonQPress;
    }

    private void OnButtonEPress(InputAction.CallbackContext value)
    {
        if (vergangenheit == true && holz != 0)
        {
            PlaceBarricade();
            holz--;
            controller.UpdateHolz(holz);
            CutsceneSetup.GetComponent<CutsceneSetup>().CutsceneBeenden();
        }
        CutsceneSetup.GetComponent<CutsceneSetup>().CutsceneBeenden();
    }
    private void OnButtonQPress(InputAction.CallbackContext value)
    {
        if (vergangenheit == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (vergangenheit == true)
        {
            
            if (holz != 0)
            {
                DefinePlacePosition();
                UpdateBlueprint();
            }
            
        }
    }

    private void DefinePlacePosition()
    {
        placePosition1 = new Vector3Int(Mathf.FloorToInt(transform.position.x), Mathf.FloorToInt(transform.position.y), Mathf.FloorToInt(transform.position.z)); //holen wir neuste Spieler Position yes yes gute diese
        placePosition2 = placePosition1;
        if (movement.newestChange.y == -1)  //down
        {
            placePosition1.y = placePosition1.y - 2;
            placePosition2.y = placePosition1.y;
            placePosition2.x = placePosition1.x + 1;
        }
        if (movement.newestChange.x == -1)  //left
        {
            placePosition1.x = placePosition1.x - 2;
            placePosition2.x = placePosition1.x;
            placePosition2.y = placePosition1.y - 1;
        }
        if (movement.newestChange.x == 1)   //right
        {
            placePosition1.x = placePosition1.x + 2;
            placePosition2.x = placePosition1.x;
            placePosition2.y = placePosition1.y - 1;
        }
        if (movement.newestChange.y == 1)   //up
        {
            placePosition1.y = placePosition1.y + 2;
            placePosition2.y = placePosition1.y;
            placePosition2.x = placePosition1.x + 1;
        }
    }

    public void PlaceBarricade()
    {
        barricateTilemap.SetTile(placePosition1, barricade);
        barricateTilemap.SetTile(placePosition2, barricade);
        randomSoundPlayer.PlayRandomSound();
        Debug.Log("barricade placed");
    }

    private void UpdateBlueprint()
    {
        blueprintTilemap.ClearAllTiles();
        blueprintTilemap.SetTile(placePosition1, blueprint);
        blueprintTilemap.SetTile(placePosition2, blueprint);
    }

    public void IncreaseHolz()
    {
        holz++;
        controller.UpdateHolz(holz);
    }

    public void TimeChange(bool b)
    {
        vergangenheit = b;
        blueprintTilemap.ClearAllTiles();
    }

}
