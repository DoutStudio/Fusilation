using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class buttonChange : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void SwitchScreen(int screenNumber)
    {
        SceneManager.LoadScene(screenNumber);
    }

}