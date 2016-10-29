using UnityEngine;
using System.Collections;

public class ShipLoaderScript : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        if (PlayerPrefs.GetInt("isSaved") == 1)
        {
            GameObject playerShip = ShipSaveLoadScript.LoadPlayerShip();
            Transform point2 = GameObject.Find("MovePoint2").transform;
            playerShip.transform.position = point2.position;
            TestMovement moveScript = playerShip.GetComponent<TestMovement>();
            moveScript.enabled = true;
            moveScript.FloatSpeed = 10;
            moveScript.MovePoints = new GameObject[2];
            moveScript.MovePoints[0] = GameObject.Find("MovePoint1");
            moveScript.MovePoints[1] = GameObject.Find("MovePoint2");
        }
        else
        {
            Debug.Log("Player Ship is not saved");
        }



        Destroy(this.gameObject);
	}
}
