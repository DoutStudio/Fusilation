using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CircleCollider2D))]
public class ShieldDeflector : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Bullet")
        {
            ((GameObject)Instantiate(Resources.Load("Prefabs/Miss FX"), collision.transform.position, Quaternion.Euler(Vector3.zero))).transform.parent = GameObject.Find("Comic FX Parent").transform;
            Destroy(collision.gameObject);
        }
    }
}
