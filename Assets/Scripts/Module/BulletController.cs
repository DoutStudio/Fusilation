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
    [HideInInspector]
    public GameObject Target;
    [HideInInspector]
    public GameObject Creator;

    public GameObject Explosion;

    void Start()
    {

        GameObject parent = GameObject.Find("ProjectileParent");
        if (parent)
        {
            transform.parent = parent.transform;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == Target.tag && collision.transform.root.gameObject != Creator)
        {
            Health itemHealth = collision.gameObject.GetComponent<Health>();
            if (itemHealth)
            {
                itemHealth.CurrentHealth -= Damage;
            }
            //create explosion
            if (Explosion)
            {
                ((GameObject)Instantiate(Explosion, transform.position, Quaternion.Euler(Vector3.zero))).transform.parent = GameObject.Find("ExplosionParent").transform;
            }
            Destroy(transform.gameObject);
        }
    }
}
