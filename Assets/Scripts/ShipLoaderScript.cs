using UnityEngine;
using System.Collections;

public class ShipLoaderScript : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        if (PlayerPrefs.GetInt("isSaved") == 1)
        {
            GameObject playerShip = ShipSaveLoadScript.LoadPlayerShip();
            GameObject captain = ShipSaveLoadScript.LoadPlayerCaptain();
            if (captain)
            {
                captain = Instantiate(captain);
                captain.transform.parent = playerShip.transform;
                playerShip.GetComponent<ShipProperties>().captain = captain;
                ItemSelectedArgs args = new ItemSelectedArgs();
                args.gameObject = captain;
                GameObject.Find("CaptainStatsPanel").GetComponent<SelectedItemScript>().SelectedItemScript_itemSelected(this, args);
            }
            //Transform point2 = GameObject.Find("MovePoint2").transform;
            //playerShip.transform.position = point2.position;
            //TestMovement moveScript = playerShip.GetComponent<TestMovement>();
            //moveScript.enabled = true;
            //moveScript.Speed = 10;
            //moveScript.MovePoints = new GameObject[2];
            //moveScript.MovePoints[0] = GameObject.Find("MovePoint1");
            //moveScript.MovePoints[1] = GameObject.Find("MovePoint2");
        }
        else
        {
            Debug.Log("Player Ship is not saved load default ship");
            GameObject prafab = Resources.Load<GameObject>("Ships/FederationFrigate");
            if (prafab)
            {
                Instantiate(prafab);
            }
            else
            {
                Debug.Log("Could not load Default Ship: FederationFrigate");
            }
            
        }



        Destroy(this.gameObject);
	}
}
