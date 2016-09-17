using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Launch : MonoBehaviour {

    Rigidbody2D body;
    public float Power = 1f;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
        body.AddForce(transform.up * Power, ForceMode2D.Impulse);
	}
}
