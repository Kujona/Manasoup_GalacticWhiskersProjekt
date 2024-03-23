using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerActions : MonoBehaviour
{

    public TileBase barricade;
    public Tilemap barricateTilemap;
    public PlayerMovement movement;
    private Vector3Int placePosition1;
    private Vector3Int placePosition2;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        DefinePlacePosition();
        if (Input.GetKeyDown("e"))
        {
            PlaceBarricade();
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
        Debug.Log("barricade placed");
    }

}
