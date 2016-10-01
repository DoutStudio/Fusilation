using UnityEngine;
using System.Collections;

/// <summary>
/// Ryan Scopio
/// Defines object damage and interaction with other objects health
/// </summary>
[RequireComponent(typeof(PolygonCollider2D))]
public class BulletController : MonoBehaviour
{

    public float Damage = 1;

    void Start()
    {
        GameObject parent = GameObject.Find("ProjectileParent");
        if (parent)
        {
            transform.parent = parent.transform;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag != "Turret" && collision.transform.tag != "Bullet")
        {
            Health itemHealth = collision.gameObject.GetComponent<Health>();
            if (itemHealth)
            {
                itemHealth.CurrentHealth -= Damage;
            }
            //create explosion
            Destroy(transform.gameObject);
        }
    }
}
