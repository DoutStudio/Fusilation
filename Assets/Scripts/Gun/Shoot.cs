using UnityEngine;
using System.Collections;
/// <summary>
/// Ryan Scopio
/// [Not in use/better script created]Simple firing of projectile
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class Shoot : MonoBehaviour
{
    public GameObject Projectile;
    public GameObject Spawner;
    public float FireRate = 1f;
    float timer;
    Rigidbody2D parentBody;

    void Start()
    {
        parentBody = transform.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= FireRate)
        {
            timer = 0f;
            GameObject newBullet = (GameObject)Instantiate(Projectile, Spawner.transform.position, transform.rotation);
            //makes parents velocity the bullets starting velocity
            Rigidbody2D bulletBody = newBullet.GetComponent<Rigidbody2D>();
            if (parentBody)
            {
                bulletBody.velocity = parentBody.velocity;
            }
        }

    }
}
