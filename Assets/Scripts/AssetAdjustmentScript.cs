using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEditor;

public class AssetAdjustmentScript : MonoBehaviour {

    public int assetCount;

	// Use this for initialization
	void Start () {
        AssetPreview.SetPreviewTextureCacheSize(assetCount);
        Debug.Log("Asset Thumbnail size set to: " + assetCount);
	}
}
