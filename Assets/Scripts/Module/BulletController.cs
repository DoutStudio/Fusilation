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
    [Range(0, 1)]
    public float Accuracy = 0.8f;
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
        if (Target && collision.transform.tag == Target.tag && collision.transform.root.gameObject != Creator)
        {
            if (Random.Range(0f, 1f) <= Accuracy) //HIT
            {
                Health itemHealth = collision.transform.root.GetComponent<Health>();
                if (itemHealth)
                {
                    itemHealth.CurrentHealth -= Damage;
                }
                if (/*I dunno if i want to keep this yet*/false && Explosion)
                {
                    ((GameObject)Instantiate(Explosion, transform.position, Quaternion.Euler(Vector3.zero))).transform.parent = GameObject.Find("ExplosionParent").transform;
                }
                Target = null;
                ((GameObject)Instantiate(Resources.Load("Prefabs/Hit FX"), transform.position, Quaternion.Euler(Vector3.zero))).transform.parent = GameObject.Find("Comic FX Parent").transform;
                Destroy(transform.gameObject);
            }
            else //MISS
            {
                Target = null;
                ((GameObject)Instantiate(Resources.Load("Prefabs/Miss FX"), transform.position, Quaternion.Euler(Vector3.zero))).transform.parent = GameObject.Find("Comic FX Parent").transform;
            }
        }
    }
}
