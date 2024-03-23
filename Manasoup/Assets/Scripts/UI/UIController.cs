using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public GameObject HolzCount;

    // Start is called before the first frame update
    void Start()
    {
        HolzCount = GameObject.FindWithTag("HolzCount");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHolz(int holz)
    { 
        HolzCount.GetComponent<TextMeshProUGUI>().text = "Holz: " + holz.ToString();
    }

}
