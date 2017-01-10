using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
using UnityEditor;



public class SelectedItemScript : MonoBehaviour {

    public Text titleTextScript;
    public Text descTextScript;

	// Use this for initialization
	void Start () {
        titleTextScript = transform.FindChild("TitleText").GetComponent<Text>();
        descTextScript = transform.FindChild("DescriptionText").GetComponent<Text>();
    }

    public void SelectedItemScript_itemSelected(object sender, EventArgs e)
    {
        GameObject obj = ((ItemSelectedArgs)e).gameObject;

        titleTextScript.text = obj.GetComponent<DescriptionScript>().title;
        descTextScript.text = obj.GetComponent<DescriptionScript>().description;

        // check if it's the captain
        if (obj.GetComponent<DescriptionScript>().type == DescriptionScript.ModuleType.CAPTAIN)
        {
            // Set thumbnail image

            SpriteRenderer sr = obj.GetComponentInChildren<SpriteRenderer>();
            Texture2D texture = sr.sprite.texture;

            Transform imageTransform = transform.FindChild("ThumbnailImage");
            Sprite spriteThumbnail = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero); // All asset previews are 128,128
            imageTransform.GetComponent<Image>().overrideSprite = spriteThumbnail;

            GameObject.FindGameObjectWithTag("Ship").GetComponent<ShipProperties>().captain = obj;
        }
    }
}
