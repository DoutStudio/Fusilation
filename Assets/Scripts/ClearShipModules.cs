using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ClearShipModules : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Button butt = GetComponent<Button>();
        butt.onClick.AddListener(ClearButtonClicked);
    }

    public void ClearButtonClicked()
    {
        // Find the ship
        GameObject shipObject = GameObject.FindGameObjectWithTag("Ship");
        List<GameObject> modules = shipObject.GetComponent<ShipProperties>().modules;

        // remove modules
        while (modules.Count > 0)
        {
            GameObject module = modules[0];
            modules.RemoveAt(0);
            Destroy(module);
        }

        // Turn back on the latch slots
        Transform fittingTrans = shipObject.transform.FindChild("FittingSlots");
        for (int i = 0; i < fittingTrans.childCount; ++i)
        {
            fittingTrans.GetChild(i).GetComponent<Renderer>().enabled = true;
            fittingTrans.GetChild(i).GetComponent<Collider2D>().enabled = true;
        }

    }
}
