using UnityEngine;
using System.Collections;
/// <summary>
/// Ryan Scopio
/// Destroys bullets on trigger enter
/// </summary>
[RequireComponent(typeof(CircleCollider2D))]
public class ShieldDeflector : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //uncomment to stop ship from blocking it's own bullets
        if (collision.transform.tag == "Bullet")// && collision.GetComponent<BulletController>().Creator != transform.root.gameObject)
        {
            ((GameObject)Instantiate(Resources.Load("Prefabs/Miss FX"), collision.transform.position, Quaternion.Euler(Vector3.zero))).transform.parent = GameObject.Find("Comic FX Parent").transform;
            Destroy(collision.gameObject);
        }
    }
}
