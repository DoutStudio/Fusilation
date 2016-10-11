using UnityEngine;
using System.Collections;

public class LoadModule : MonoBehaviour {

    private Sprite currentSprite;
    Sprite spriteToLoad;
    Sprite[] allSprites;


	// Use this for initialization
	void Start () {
            allSprites = Resources.LoadAll<Sprite>("Prefabs");
        int hello = allSprites.Length;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
