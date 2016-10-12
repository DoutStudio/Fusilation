using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;

public class ClickChange : MonoBehaviour {

    //public Sprite spriteToSelect;
    SpriteRenderer render;
    Sprite tempSprite;
    public GameObject tempGO;

	// Use this for initialization
	void Start () {
        render = GetComponent<SpriteRenderer>();
        //Debug.Log(Path.GetDirectoryName("/Assets/Prefabs/Ship Modules/Attack/BasicTurret.prefab"));
		//GameObject prefab = Resources.Load<GameObject>("Ship Modules/Attack/BasicTurret");
		//Instantiate (prefab);
		//PLs or y
		GameObject fml = new GameObject();
		SpriteRenderer renderer = fml.AddComponent<SpriteRenderer> ();
		renderer.sprite = Resources.Load ("Sprites/BasicTurret", typeof(Sprite)) as Sprite;
		render.sprite = renderer.sprite;


		//SpriteRenderer renderer2 = prefab.GetComponent<SpriteRenderer>();
		//render.sprite = spriteToSelect;

		//Texture2D tempTexture = AssetPreview.GetAssetPreview (prefab);
		//Sprite prefabSprite = Sprite.Create (tempTexture, new Rect (0, 0, 128, 128), Vector2.zero);
		//render.GetComponent<GameObject> = prefab;

		//GameObject hello = Instantiate (prefab);
		//hello.transform.position = 	new Vector3 (render.transform.position.x, render.transform.position.y, 0);
		//Destroy (render.gameObject);
		//Debug.Log (renderer2.sprite);
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetMouseButtonDown(0))
        {
            //render.color = Color.blue;
            GameObject dunno = Resources.Load<GameObject>("Ship Modules\\Attack\\BasicTurret");
            Instantiate(tempGO, render.transform.position, Quaternion.identity);
            Destroy(render.gameObject);
        }
	}
}
