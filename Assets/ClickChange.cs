using UnityEngine;
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
       // string hello = Path.GetDirectoryName("/Assets/Prefabs/Ship Modules/Attack/BasicTurret.prefab");
        
        //Destroy(transform.gameObject);
        //render.sprite = tempSprite;
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
