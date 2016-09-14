using UnityEngine;
using System.Collections;

public class Track : MonoBehaviour {

    public Transform target;
    public float turnSpeed = 5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (target)
        { // enemy alive and at sight: aim at him!
            Vector3 dir = target.position - transform.position; // find direction
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, turnSpeed * Time.deltaTime);
            // you may shoot here
        }
        else
        {
            // no enemy or enemy dead: find the nearest
            // victim and assign it to currentEnemy
        }
    }
}
