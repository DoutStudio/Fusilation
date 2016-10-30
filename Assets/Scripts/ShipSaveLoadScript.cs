using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public abstract class ShipSaveLoadScript : MonoBehaviour {

    //public int battleSceneNumber;
    //private GameObject captian;
    //private GameObject ship;

    //void Start()
    //{
    //    Button button = GetComponent<Button>();
    //    button.onClick.AddListener(TransferShipToBattle);

    //    ship = GameObject.FindGameObjectWithTag("Ship");
    //}

    //void TransferShipToBattle()
    //{
    //    // NOTE: The numebr of modules will change per ship
    //    PlayerPrefs.SetString("Ship", ship.name);
    //    for (int i = 0; i < ship.transform.childCount; ++i)
    //    {
    //        GameObject module = ship.transform.GetChild(i).gameObject;
    //        PlayerPrefs.SetString("Module_" + i, module.name);
    //    }
    //    //PlayerPrefs.SetString("Captain", captian.name);
    //    Debug.Log("Captain not saved in PlayerPrefs");

    //    Debug.Log("LEVEL LOAD METHOD NOT IMPLEMENTED");
    //    //DontDestroyOnLoad(ship);
    //    //SceneManager.LoadScene(battleSceneNumber);
    //}

    public static void SavePlayerShip(GameObject shipGameObject)
    {
        PlayerPrefs.SetInt("isSaved", 1);

        // save the ship id
        string shipName = shipGameObject.name.Replace("(Clone)", "");
        PlayerPrefs.SetString("Ship", shipName);

        
        // For Each fitting slot
        // save the id of each valid module
        // save location of each module in fitting slots
        Transform fittingSlots = shipGameObject.transform.FindChild("FittingSlots");
        for (int i = 0; i < fittingSlots.childCount; ++i)
        {
            GameObject latchSlot = fittingSlots.GetChild(i).gameObject;
            //PlayerPrefs.SetString("Module_" + i + "_location", latchSlot.name);
            if (latchSlot.transform.childCount > 0)
            {
                GameObject module = latchSlot.transform.GetChild(0).gameObject;
                string moduleName = module.name.Replace("(Clone)", "");
                PlayerPrefs.SetString("Module_" + i, moduleName);
            }
            else
            {
                // no module is at that slot
                PlayerPrefs.SetString("Module_" + i, "NULL");
            }
        }
    }

    /**
     * Loads the player ship and instantiates the game object.
     */
    public static GameObject LoadPlayerShip()
    {
        // Load the ship ID
        string shipName = PlayerPrefs.GetString("Ship");
        GameObject ship = Resources.Load("Ships/" + shipName) as GameObject;

        ship = Instantiate(ship);
        

        // Find valid ship modules
        // For each valid ship module
        // get teh id of the module
        // get the location of the module
        // place module on ship
        Transform fittingSlots = ship.transform.FindChild("FittingSlots");
        for (int i = 0; i < fittingSlots.childCount; ++i)
        {
            //string slotLocation = PlayerPrefs.GetString("Module_" + i + "_location");
            string moduleName = PlayerPrefs.GetString("Module_" + i);
            if (moduleName != "NULL")
            {
                GameObject module = Resources.Load<GameObject>("Ship Modules/Attack/" + moduleName);
                if (!module)
                {
                    module = Resources.Load<GameObject>("Ship Modules/Defense/" + moduleName);
                }
                else if(!module)
                {
                    module = Resources.Load<GameObject>("Ship Modules/Support/" + moduleName);
                }
                if (module == null)
                {
                    Debug.Log("The module " + moduleName + " could not be loaded");
                }
                GameObject moduleInGame = Instantiate(module, fittingSlots.GetChild(i).transform.position, Quaternion.identity) as GameObject; // might need location
                //moduleInGame.GetComponent<ConnectModuleScript>().isOverSlot = true;
                moduleInGame.GetComponent<ConnectModuleScript>().currentHoveredSlot = fittingSlots.GetChild(i).gameObject;
                moduleInGame.transform.parent = fittingSlots.GetChild(i).transform;
            }
            //fittingSlots.GetChild(i).GetComponent<Renderer>().enabled = false;
        }

        return ship;
    }

    public static void SavePlayerCaptain(GameObject shipGameObject)
    {
        // save captain if applicable (if thats how you spell it)
        if (shipGameObject.GetComponent<ShipProperties>().captain)
        {
            string capName = shipGameObject.GetComponent<ShipProperties>().captain.name.Replace("(Clone)", "");
            PlayerPrefs.SetString("Captain", capName);
        }
    }

    public static GameObject LoadPlayerCaptain()
    {
        string capName = PlayerPrefs.GetString("Captain");
        GameObject captain = Resources.Load<GameObject>("Ship Modules/Captain/" + capName);
        return captain;
    }
}
