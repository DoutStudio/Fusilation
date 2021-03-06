﻿using UnityEngine;
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
    private bool captainOrShip = false;

    private static bool spawnReset = true; // MWAHAHAHAHA


	// Use this for initialization
	void Start () {

        // subscribe event
        if (shipModule.GetComponent<DescriptionScript>().type == DescriptionScript.ModuleType.CAPTAIN)
        {
            itemSelected += GameObject.Find("CaptainStatsPanel").GetComponent<SelectedItemScript>().SelectedItemScript_itemSelected;
            captainOrShip = true;
        }
        else if (shipModule.GetComponent<DescriptionScript>().type == DescriptionScript.ModuleType.SHIP)
        {
            captainOrShip = true;
        }
        else
        {
            itemSelected += GameObject.Find("ModuleStatsPanel").GetComponent<SelectedItemScript>().SelectedItemScript_itemSelected;

        }

        // check to see if the slot connector module is installed
        if (shipModule.GetComponent<ConnectModuleScript>() == null)
        {
            //shipModule.AddComponent<ConnectModuleScript>();
            //shipModule.GetComponent<ConnectModuleScript>().enabled = true;
        }
        // check if the rigid body is added
        if (shipModule.GetComponent<Rigidbody>() == null && shipModule.GetComponent<Rigidbody2D>() == null)
        {
            //shipModule.AddComponent<Rigidbody>();
            //shipModule.GetComponent<Rigidbody>().useGravity = false;
        }
        // check if the module has a collider
        if (shipModule.GetComponent<Collider>() == null)
        {
            //shipModule.AddComponent<SphereCollider>();
            //shipModule.GetComponent<SphereCollider>().isTrigger = true;
        }

        // Set the name of the list item
        Transform childTransform = transform.FindChild("ItemNameText");
        childTransform.GetComponent<Text>().text = shipModule.name;

        // Set the description of the list item
        transform.FindChild("DescriptionText").GetComponent<Text>().text = shipModule.GetComponent<DescriptionScript>().description;

        // Set thumbnail image
        Texture2D texture = null;
        while (!texture)
        {
            // Asset Preview runs assynchonously with main instantiation thread
            // texture might not be available on first call
            texture = AssetPreview.GetAssetPreview(shipModule); // pulling the prefab
        }

        if (texture == null)
        {
            Debug.Log("Could not load texture from" + shipModule.name + "{" + (shipModule != null) + "}");
        }

        Transform imageTransform = transform.FindChild("ItemThumbnailImage");
        Sprite spriteThumbnail = Sprite.Create(texture, new Rect(0, 0, 128, 128), Vector2.zero); // All asset previews are 128,128
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
        module.GetComponent<ConnectModuleScript>().enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (Input.GetMouseButton(0) && spawnReset && !captainOrShip)
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
