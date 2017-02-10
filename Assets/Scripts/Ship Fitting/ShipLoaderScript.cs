using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ShipLoaderScript : MonoBehaviour {

    public Vector3 ShipStartPosition;
    public float ShipStartRotation;
    public GameObject[] PlayerMovePoints;
    public GameObject[] PlayerWarpPoints;
    public GameObject[] PlayerStopPoints;

    public delegate void ShipReadyEvent();
    public event ShipReadyEvent readyE;

	// Use this for initialization
	void Start ()
    {
        switch(SceneManager.GetActiveScene().buildIndex)
        {
            case 2: // fitting scene
                LoadShipInFittingRoom();
                break;
            default: // battle scene
                LoadShipInBattleRoom();
                break;
        }   
	}


    private void LoadShipInFittingRoom()
    {
        if (PlayerPrefs.GetInt("isSaved") == 1)
        {
            GameObject playerShip = ShipSaveLoadScript.LoadPlayerShip();
            playerShip.GetComponent<Rigidbody2D>().isKinematic = true;
            GameObject captain = ShipSaveLoadScript.LoadPlayerCaptain();
            if (captain)
            {
                captain = Instantiate(captain);
                captain.transform.parent = playerShip.transform;
                captain.GetComponentInChildren<Renderer>().enabled = false;
                playerShip.GetComponent<ShipProperties>().captain = captain;
                ItemSelectedArgs args = new ItemSelectedArgs();
                args.gameObject = captain;
                GameObject.Find("CaptainStatsPanel").GetComponent<SelectedItemScript>().SelectedItemScript_itemSelected(this, args);
            }

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

        if (readyE != null)
        {
            readyE.Invoke();
        }

        Destroy(this.gameObject);
    }

    private void LoadShipInBattleRoom()
    {
        GameObject playerShip = ShipSaveLoadScript.LoadPlayerShip();
        float offset = playerShip.transform.Find("Nose").position.magnitude;
        playerShip.transform.position = new Vector3(ShipStartPosition.x + offset, ShipStartPosition.y, ShipStartPosition.z);
        playerShip.transform.rotation = Quaternion.Euler(0, 0, ShipStartRotation);
        ShipMovement movementScript = playerShip.GetComponent<ShipMovement>();
        movementScript.MovePoints = PlayerMovePoints;
        movementScript.WarpPoints = new List<GameObject>(PlayerWarpPoints);
        movementScript.StopPoints = new List<GameObject>(PlayerStopPoints);
        movementScript.enabled = true;

        // Enable ship weapons
        GameObject[] modules = playerShip.GetComponent<ShipProperties>().GetAllShipModules();
        foreach (GameObject module in modules)
        {
            DescriptionScript desc = module.GetComponent<DescriptionScript>();
            switch (desc.type)
            {
                case DescriptionScript.ModuleType.ATTACK:
                    GunController gun = module.GetComponent<GunController>();
                    if (gun != null)
                    {
                        gun.enabled = true;
                    }
                    TargetingComputer targ = module.GetComponent<TargetingComputer>();
                    if (targ != null)
                    {
                        targ.enabled = true;
                    }
                    Track track = module.GetComponent<Track>();
                    if (track != null)
                    {
                        track.enabled = true;
                    }
                    Transform laser = module.transform.Find("Laser");
                    if (laser != null)
                    {
                        laser.gameObject.SetActive(true);
                    }
                    break;
                case DescriptionScript.ModuleType.DEFENSE:
                    break;
                case DescriptionScript.ModuleType.SUPPORT:
                    break;
            }
        }


        GameObject captain = ShipSaveLoadScript.LoadPlayerCaptain();
        if (captain)
        {
            captain = Instantiate(captain);
            captain.transform.parent = playerShip.transform;
            captain.GetComponent<ConnectModuleScript>().enabled = false;
            captain.GetComponentInChildren<Renderer>().enabled = false;
            playerShip.GetComponent<ShipProperties>().captain = captain;
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
}
