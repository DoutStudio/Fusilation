using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ModuleSelection : MonoBehaviour {

    private Text popup = null;
    private DescriptionScript descriptionS;
    private string descriptionText;

	// Use this for initialization
	void Start () {
        string currentObject = this.gameObject.name;
        popup = GameObject.Find("messageBoxText").GetComponent<Text>();
        descriptionS = GameObject.Find(currentObject).GetComponent<DescriptionScript>();
        descriptionText = descriptionS.description;
	}

    void Update()
    {
    }

    public void ChangeText (Text popUp, string moduleDescription)
    {
        popUp.text = moduleDescription;
    }

    void OnMouseDown()
    {
        ChangeText(popup, descriptionText);
    }
}
