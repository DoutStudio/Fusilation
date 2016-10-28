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
    Sprite tempSprite;
    public GameObject tempGO;
    public Text textBoxToChange;
    private GUIText[] allTextBoxes;
    private GameObject dunno;
    public int wtf;
    SpriteRenderer renderer;

    // Use this for initialization
    void Start () {
        render = GetComponent<SpriteRenderer>();
        //Debug.Log(Path.GetDirectoryName("/Assets/Prefabs/Ship Modules/Attack/BasicTurret.prefab"));
		//GameObject prefab = Resources.Load<GameObject>("Ship Modules/Attack/BasicTurret");
		//Instantiate (prefab);
		//PLs or y
		GameObject fml = new GameObject();
		renderer = fml.AddComponent<SpriteRenderer> ();
		renderer.sprite = Resources.Load("Sprites/BasicTurret", typeof(Sprite)) as Sprite;
		render.sprite = renderer.sprite;


        //dunno = Resources.Load<GameObject>("Ship Modules\\Attack\\BasicTurret");
        dunno = (GameObject)Instantiate(tempGO, render.transform.position, Quaternion.identity);

        Texture2D fuckBoats = AssetPreview.GetAssetPreview(tempGO);

        dunno.GetComponent<Image>().sprite =
            Sprite.Create(fuckBoats, new Rect(0, 0, 128, 128), Vector2.zero);
        GetComponent<Collider>().gameObject.name = dunno.gameObject.name;

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
        Destroy (render.gameObject);
        //Debug.Log (renderer2.sprite);
    }
	
	// Update is called once per frame
	void Update () { 
        if (Input.GetMouseButtonDown(0))
        { // if left button pressed...
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            bool didItHitACollider = Physics.Raycast(ray, out hit);
            if (didItHitACollider && hit.collider.gameObject.name == dunno.gameObject.name)
            {
                //textBoxToChange.text = dunno.GetComponent<DescriptionScript>().description;
                textBoxToChange.text = dunno.gameObject.name;
            }
        }
    }
}