using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
using UnityEditor;

public class ModuleThumbnailScript : MonoBehaviour ,
    IPointerExitHandler,
    IPointerDownHandler,
    IPointerUpHandler
{

    public GameObject shipModule;

    event EventHandler itemSelected;

    public GameObject shipStatPanel; // all have a ref but whatevs

    private bool downReset = true;

    private static bool spawnReset = true; // MWAHAHAHAHA

	// Use this for initialization
	void Start () {

        // subscribe event
        if (shipModule.GetComponent<DescriptionScript>().type == DescriptionScript.ModuleType.CAPTAIN)
        {
            itemSelected += GameObject.Find("CaptainStatsPanel").GetComponent<SelectedItemScript>().SelectedItemScript_itemSelected;
        }
        else
        {
            itemSelected += GameObject.Find("ShipStatsPanel").GetComponent<SelectedItemScript>().SelectedItemScript_itemSelected;
        }

        // check to see if the slot connector module is installed
        if (shipModule.GetComponent<ConnectModuleScript>() == null)
        {
            shipModule.AddComponent<ConnectModuleScript>();
        }
        // check if the rigid body is added
        if (shipModule.GetComponent<Rigidbody>() == null)
        {
            shipModule.AddComponent<Rigidbody>();
            shipModule.GetComponent<Rigidbody>().useGravity = false;
        }
        // check if the module has a collider
        if (shipModule.GetComponent<Collider>() == null)
        {
            shipModule.AddComponent<SphereCollider>();
            shipModule.GetComponent<SphereCollider>().isTrigger = true;
        }

        // Set the name of the list item
        Transform childTransform = transform.FindChild("ItemNameText");
        childTransform.GetComponent<Text>().text = shipModule.name;

        // Set thumbnail image
        Texture2D texture = null;
        while (!texture)
        {
            // Asset Preview runs assynchonously with main instantiation thread
            // texture might not be available on first call
            texture = AssetPreview.GetAssetPreview(shipModule);
        }

        if (texture == null)
        {
            Debug.Log("Could not load texture from" + shipModule.name + "{" + (shipModule != null) + "}");
        }

        Transform imageTransform = transform.FindChild("ItemThumbnailImage");
        Sprite spriteThumbnail = Sprite.Create(texture, new Rect(0, 0, 128, 128), Vector2.zero); // All asset previews are 128,128
        imageTransform.GetComponent<Image>().overrideSprite = spriteThumbnail;
        imageTransform.GetComponent<Image>().sprite = spriteThumbnail;
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public void SpawnModuleAtMousePosition()
    {
        Vector3 mPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mPos.z = 0;
        GameObject module = (GameObject) Instantiate(shipModule, mPos, Quaternion.identity);
        module.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        Debug.Log("held is false");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (Input.GetMouseButton(0) && shipModule.GetComponent<ConnectModuleScript>().enabled && spawnReset)
        {
            SpawnModuleAtMousePosition();
            spawnReset = false;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        EventHandler handler = itemSelected;
        if (downReset && handler != null)
        {
            ItemSelectedArgs args = new ItemSelectedArgs();
            args.gameObject = shipModule;
            handler(this, args);
            downReset = false;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        downReset = true;
        spawnReset = true;
    }
}
