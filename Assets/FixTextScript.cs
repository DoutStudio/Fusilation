using UnityEngine;
using System.Collections;

public class FixTextScript : MonoBehaviour {

    public GameObject enemyTextObj;
    public GameObject enemyTextTarget;
    public bool upperTextAlignmentAboveItem;
    public bool lowerTextAlignmentBelowItem;
    public int moveItBitch;

	// Use this for initialization
	void Start ()
    {
        //Vector3 worldPosition = Camera.main.ScreenToWorldPoint(enemyTextObj.GetComponent<RectTransform>().position);
        Vector3 worldPosition = enemyTextObj.transform.position;
        Vector3 targetPosition = enemyTextTarget.transform.position;
        Vector3 specialtargetPosition = enemyTextObj.GetComponent<RectTransform>().position;
        int scaleFactor = Camera.main.pixelHeight - (int)enemyTextTarget.transform.position.y;
        //targetPosition.y = enemyTextTarget.transform.position.y;

        Vector3 screenAdditive = Camera.main.WorldToScreenPoint(targetPosition);
        if (upperTextAlignmentAboveItem && !lowerTextAlignmentBelowItem)
        {
            screenAdditive.y = enemyTextTarget.transform.position.y + scaleFactor - 50;
            
        }

        if(lowerTextAlignmentBelowItem && !upperTextAlignmentAboveItem)
        {
            screenAdditive.y = -(scaleFactor - screenAdditive.y - 500); //enemyTextTarget.transform.position.y - scaleFactorLower + 50;
        }
        if(moveItBitch != 0)
        {
            screenAdditive.x += moveItBitch;
        }
        enemyTextObj.transform.position = screenAdditive;

        //enemyTextObj.GetComponent<RectTransform>().position += screenAdditive;

    }

    // Update is called once per frame
    void Update () {
	
	}
}
