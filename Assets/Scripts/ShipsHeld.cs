using UnityEngine;
using System.Collections;

public class ShipsHeld : MonoBehaviour {

    public string team;
    public string nameOfShip;
    SpriteRenderer[] possibleShipParts;
    MeshRenderer[] possibleShipSlots;

    // Use this for initialization
    void Start () {

        //Collect all the visible parts of every ship
        possibleShipParts = FindObjectsOfType<SpriteRenderer>();
        possibleShipSlots = FindObjectsOfType<MeshRenderer>();
        string tempstring = "";
        string superParentName = "";
        string itemName = "";

        //Make them all invisible
        for (int i = 0; i < possibleShipParts.Length; i++)
        {
            try
            {
                superParentName = possibleShipParts[i].transform.parent.transform.parent.transform.parent.name;             
                tempstring = possibleShipParts[i].transform.parent.transform.parent.name;
                itemName = possibleShipParts[i].transform.parent.name;
                if (tempstring != nameOfShip && tempstring != "MessageBoxes" && superParentName == team)
                {
                    possibleShipParts[i].enabled = false;
                }
            }
            catch { }
        }
        for (int i = 0; i < possibleShipSlots.Length; i++)
        {
            try
            {
                superParentName = possibleShipSlots[i].transform.parent.transform.parent.transform.parent.name;
                tempstring = possibleShipSlots[i].transform.parent.transform.parent.name;
                itemName = possibleShipSlots[i].transform.parent.name;
                if (tempstring != nameOfShip && tempstring != "MessageBoxes" && superParentName == team)
                {
                    possibleShipSlots[i].enabled = false;
                }
            }
            catch { }
        }
    }
	
	// Update is called once per frame
	void Update () {

    }
}
