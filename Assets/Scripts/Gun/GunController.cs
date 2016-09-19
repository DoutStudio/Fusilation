using UnityEngine;
using System.Collections;

/// <summary>
/// Ryan Scopio
/// Fires a bullet from this object at a defined fire rate
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class GunController : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject BulletSpawner;
    public float FireRate = 1f;

    public float Power = 0.1f;
    float timer = 0f;
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
            GameObject newBullet = (GameObject)Instantiate(Bullet, BulletSpawner.transform.position, transform.rotation);
            Rigidbody2D bulletBody = newBullet.GetComponent<Rigidbody2D>();
            if (parentBody)
            {
                bulletBody.velocity = parentBody.velocity;
            }
            bulletBody.AddRelativeForce(Vector2.up * Power, ForceMode2D.Impulse);
        }
    }
}
