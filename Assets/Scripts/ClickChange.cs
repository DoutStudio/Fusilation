using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

public class ClickChange : MonoBehaviour {

    //public Sprite spriteToSelect;
    SpriteRenderer render;
    public GameObject tempGO;
    public Text descriptionBox;
	public Text moduleSelection;
    private GameObject dunno;
	public int idNumber;
    public bool isEnemy;
    public bool isCaptain;

    // Use this for initialization
    void Start () {
		//Get the current sprite renderer
        render = GetComponent<SpriteRenderer>();

		//Get ready to transform the object based on loaded image
		//Transform currentObjectSize = GetComponent<Transform> ();

		//Get Sprite Renderer's current size
		float currX = render.bounds.size.x;
		float currY = render.bounds.size.y;
		float currZ = render.bounds.size.z;

		//Vector3 sizeToScale = new Vector3 (currX, currY, currZ);

		//Load the image
        // fuckBoats = AssetPreview.GetAssetPreview(tempGO);

		//Create a duplicate item with same properties

		dunno = (GameObject)Instantiate(tempGO, render.transform, false);
        dunno.gameObject.name = "Module#" + idNumber;
        //dunno.transform.localScale = new Vector3(.5f, .5f, 1);
		//dunno.transform.localScale = sizeToScale;
        //dunno.transform.localScale = new Vector3(currentObjectSize.localScale.x,
        //currentObjectSize.localScale.y, currentObjectSize.localScale.z);

		//Disable vision of standard object
        render.enabled = false;
        //Destroy (render.gameObject);
        //Debug.Log (renderer2.sprite);
    }
	
	// Update is called once per frame
	void Update () {
        //dunno.transform.localScale = new Vector3(.5f, .5f, 1);
        if (Input.GetMouseButtonDown(0))
        { // if left button pressed...
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            bool didItHitACollider = Physics.Raycast(ray, out hit);

			//If the user clicked on the object
			if (didItHitACollider && hit.collider.gameObject.name == dunno.gameObject.name)
            {
				
				if (moduleSelection != null)
                {
					descriptionBox.text = dunno.GetComponent<DescriptionScript>().description;
                }
                
                if (isEnemy)
                {
					moduleSelection.text = dunno.GetComponent<DescriptionScript>().title + " has been targeted";
                }
                else
                {
					moduleSelection.text = dunno.GetComponent<DescriptionScript>().title + " has been selected for repair";
                }
            }
        }
    }
}