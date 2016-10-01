using UnityEngine;
using System.Collections;
/// <summary>
/// Ryan Scopio
/// Launches object on spawn with impulse
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class Launch : MonoBehaviour {

    Rigidbody2D body;
    public float Power = 1f;

	void Start () {
        body = GetComponent<Rigidbody2D>();
        body.AddForce(transform.up * Power, ForceMode2D.Impulse);
	}
}
