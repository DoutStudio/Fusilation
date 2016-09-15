using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PolygonCollider2D))]
public class BulletController : MonoBehaviour
{

    public float Damage = 1;

    // Use this for initialization
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
