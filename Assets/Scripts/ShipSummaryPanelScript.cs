using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShipSummaryPanelScript : MonoBehaviour {

    public Text titleText;
    public Text descText;
    public Text healthText;
    public Text damageMultiplierText;
    public Text attackSpeedText;
    public Text shieldText;
    public Text damageReductionText;
    public Text accuracyText;

    // Module Panel
    Text modTitle;
    Text modDesc;

    ShipProperties shipProperties;

	// Use this for initialization
	void Start () {

        ShipLoaderScript ls = GameObject.Find("ShipLoaderObject").GetComponent<ShipLoaderScript>();
        ls.readyE += shipReadyThrown;


        GameObject moduleDescPanel = GameObject.Find("ModuleStatsPanel");
        modTitle = moduleDescPanel.transform.Find("TitleText").GetComponent<Text>();
        modDesc = moduleDescPanel.transform.Find("DescriptionText").GetComponent<Text>();
    }

    private void shipReadyThrown()
    {
        GameObject ship = GameObject.FindGameObjectWithTag("Ship");

        titleText = transform.Find("ShipNameText").GetComponent<Text>();
        descText = transform.Find("DescriptionText").GetComponent<Text>();

        shipProperties = ship.GetComponent<ShipProperties>();
        // TODO: This will not work if multiple ship types
        // We will have to change this so it gets events from 
        // changing ship
        titleText.text = shipProperties.GetComponent<DescriptionScript>().title;
        descText.text = shipProperties.GetComponent<DescriptionScript>().description;

        shipProperties.addRmEvent += moduleRemovedOrAdded;
    }

    private void moduleRemovedOrAdded(bool wasAdded, GameObject module)
    {
        if (!wasAdded) // check if the module stats panel should be updated
        {
            DescriptionScript desc = module.GetComponent<DescriptionScript>();
            modTitle.text = desc.title;
            modDesc.text = desc.description;
        }

        titleText.text = shipProperties.GetComponent<DescriptionScript>().title;
        descText.text = shipProperties.GetComponent<DescriptionScript>().description;

        healthText.text = "Health: " + (shipProperties.health + shipProperties.hpBuff);
        damageMultiplierText.text = "Damage Multiplier: " + shipProperties.damageBuffMultiplier.ToString("0.00");
        attackSpeedText.text = "Attack Speed Multiplier: " + shipProperties.attackSpeedMultiplier.ToString("0.00");
        shieldText.text = "Shield Strength: " + shipProperties.shieldFlatBuff;
        damageReductionText.text = "Damage Reduction: " + shipProperties.damageReductionPercentage.ToString("0.00");
        accuracyText.text = "Accuracy Buff: " + shipProperties.accuracyMultiplier.ToString("0.00");
    }


    // Update is called once per frame
    void Update () {
	
	}
}
