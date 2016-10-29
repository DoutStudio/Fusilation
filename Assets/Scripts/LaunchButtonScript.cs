using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LaunchButtonScript : MonoBehaviour {

    public int battleScene = 6;

	// Use this for initialization
	void Start () {
        Button butt = GetComponent<Button>();
        butt.onClick.AddListener(LaunchButtonClicked); 
	}
	
	void LaunchButtonClicked ()
    {
        GameObject shipObject = GameObject.FindGameObjectWithTag("Ship");
        ShipSaveLoadScript.SavePlayerShip(shipObject);
        // TODO: save captain
        SceneManager.LoadScene(battleScene);
	}
}
