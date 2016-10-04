using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
using UnityEditor;



public class SelectedItemScript : MonoBehaviour {

    Text titleTextScript;
    Text descTextScript;

	// Use this for initialization
	void Start () {
        titleTextScript = transform.FindChild("TitleText").GetComponent<Text>();
        descTextScript = transform.FindChild("DescriptionText").GetComponent<Text>();

        //titleTextScript.text = "";
        //descTextScript.text = "";
    }

    public void SelectedItemScript_itemSelected(object sender, EventArgs e)
    {
        //Debug.Log("test");

        GameObject obj = ((ItemSelectedArgs)e).gameObject;

        titleTextScript.text = obj.GetComponent<DescriptionScript>().title;
        descTextScript.text = obj.GetComponent<DescriptionScript>().description;

        // check if it's the captain
        if (obj.GetComponent<DescriptionScript>().type == DescriptionScript.ModuleType.CAPTAIN)
        {
            // Set thumbnail image
            Texture2D texture = AssetPreview.GetAssetPreview(obj);
            Transform imageTransform = transform.FindChild("ThumbnailImage");
            Sprite spriteThumbnail = Sprite.Create(texture, new Rect(0, 0, 128, 128), Vector2.zero); // All asset previews are 128,128
            imageTransform.GetComponent<Image>().overrideSprite = spriteThumbnail;
        }
    }
}
