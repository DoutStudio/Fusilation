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
    public Text textBoxToChange;
    private GameObject dunno;
    public int idNumber;
    public bool grabName;
    public bool isEnemy;
    public bool isCaptain;

    // Use this for initialization
    void Start () {
        render = GetComponent<SpriteRenderer>();
        Transform currentObjectSize = GetComponent<Transform>();
        //Debug.Log(Path.GetDirectoryName("/Assets/Prefabs/Ship Modules/Attack/BasicTurret.prefab"));
		//GameObject prefab = Resources.Load<GameObject>("Ship Modules/Attack/BasicTurret");
		//Instantiate (prefab);
		//PLs or y
		//GameObject fml = new GameObject();
		//renderer = fml.AddComponent<SpriteRenderer> ();
		//renderer.sprite = Resources.Load("Sprites/BasicTurret", typeof(Sprite)) as Sprite;
		//render.sprite = renderer.sprite;

        Texture2D fuckBoats = AssetPreview.GetAssetPreview(tempGO);
        //fuckBoats



        //dunno = Resources.Load<GameObject>("Ship Modules\\Attack\\BasicTurret");
        
        dunno = (GameObject)Instantiate(tempGO, render.transform, false);
        dunno.gameObject.name = "Module#" + idNumber;
        dunno.transform.localScale = new Vector3(1, 1, 1);
        dunno.transform.localScale = new Vector3(currentObjectSize.localScale.x,
            currentObjectSize.localScale.y, currentObjectSize.localScale.z);
        //dunno.AddComponent<SpriteRenderer>();
        //render.sprite = dunno.GetComponent<SpriteRenderer>().sprite;
        //Sprite tempSprite = Sprite.Create(fuckBoats, new Rect(0, 0, fuckBoats.width, fuckBoats.height), Vector2.zero);
        //dunno.GetComponent<SpriteRenderer>().sprite = tempSprite;
        //dunno.transform.SetParent(render.transform);
        
        //GetComponent<Collider>().gameObject.name = dunno.gameObject.name;

        //Destroy(render.gameObject);
        /*allTextBoxes = FindObjectsOfType<GUIText>();
        for(int i = 0; i < allTextBoxes.Length; i++)
        {
            if (allTextBoxes[i].name == "messageBoxTextEnemy")
            {
                enemyText = allTextBoxes[i];
            }
            else if (allTextBoxes[i].name == "messageBoxTextEnemy")
            {
                allyText = allTextBoxes[i];
            }
        }
*/

        //SpriteRenderer renderer2 = prefab.GetComponent<SpriteRenderer>();
        //render.sprite = spriteToSelect;

        //Texture2D tempTexture = AssetPreview.GetAssetPreview (prefab);
        //Sprite prefabSprite = Sprite.Create (tempTexture, new Rect (0, 0, 128, 128), Vector2.zero);
        //render.GetComponent<GameObject> = prefab;

        //GameObject hello = Instantiate (prefab);
        //hello.transform.position = 	new Vector3 (render.transform.position.x, render.transform.position.y, 0);
        //dunno.transform.SetParent(dunno.transform);
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
            if (didItHitACollider && hit.collider.gameObject.name == dunno.gameObject.name)
            {
                if (!grabName)
                {
                    textBoxToChange.text = dunno.GetComponent<DescriptionScript>().description;
                }
                else
                {
                    if (isEnemy)
                    {
                        textBoxToChange.text = dunno.gameObject.name + " has been targeted";
                    }
                    else
                    {
                        textBoxToChange.text = dunno.gameObject.name + " has been selected for repair";
                    }
                }
            }
        }
    }
}