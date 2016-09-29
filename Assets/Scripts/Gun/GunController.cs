using UnityEngine;
using System.Collections;

/// <summary>
/// Ryan Scopio
/// Fires a bullet from this object at a defined fire rate
/// IF projectile is a seeker, this requires a targeting computer; probably a safer way to do this
/// </summary>
[RequireComponent(typeof(Rigidbody2D), typeof(TargetingComputer))]
public class GunController : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject BulletSpawner;
    public float FireRate = 1f;

    public float Power = 0.1f;
    float timer = 0f;
    Rigidbody2D parentBody;
    TargetingComputer targComp;

    void Start()
    {
        parentBody = transform.GetComponent<Rigidbody2D>();
        targComp = GetComponent<TargetingComputer>();

    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= FireRate && targComp.Target)
        {
            timer = 0f;
            GameObject newBullet = (GameObject)Instantiate(Bullet, BulletSpawner.transform.position, transform.rotation);
            Rigidbody2D bulletBody = newBullet.GetComponent<Rigidbody2D>();
            if (parentBody)
            {
                bulletBody.velocity = parentBody.velocity;
            }

            Seek seeker = newBullet.GetComponent<Seek>();
            if (seeker)
            {
                seeker.Target = GetComponent<TargetingComputer>().Target;
                seeker.Power = Power;
            }
            else
            {
                bulletBody.AddRelativeForce(Vector2.up * Power, ForceMode2D.Impulse);
            }
        }
    }
}
