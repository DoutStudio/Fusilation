using UnityEngine;
using System.Collections;

public class FixTextIssue : MonoBehaviour {

    RectTransform textBox;

	// Use this for initialization
	void Start () {
        textBox = (RectTransform)GetComponent<RectTransform>().Find("messageBoxText2");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
