using UnityEngine;
using System.Collections;

public class Track : MonoBehaviour {

    public Transform Target;
    public float TurnSpeed = 5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Target)
        { // enemy alive and at sight: aim at him!
            Vector3 dir = Target.position - transform.position; // find direction
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, TurnSpeed * Time.deltaTime);
            // you may shoot here
        }
        else
        {
            // no enemy or enemy dead: find the nearest
            // victim and assign it to currentEnemy
        }
    }
}
