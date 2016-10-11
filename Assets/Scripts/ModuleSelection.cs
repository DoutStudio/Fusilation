using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ModuleSelection : MonoBehaviour {

    private Text popup = null;
    private DescriptionScript descriptionS;
    private string descriptionText;

	// Use this for initialization
	void Start () {
        popup = GameObject.Find("messageBoxTextEnemy").GetComponent<Text>();
        string hello = "LatchSlotLoad";
        descriptionS = GameObject.Find(hello).GetComponent<DescriptionScript>();
        descriptionText = descriptionS.description;
	}

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            ChangeText(popup, descriptionText);
        }
    }

    public void ChangeText (Text popUp, string moduleDescription)
    {
        popUp.text = moduleDescription;
    }
}
