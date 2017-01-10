using UnityEngine;
using System.Collections;

/// <summary>
/// Ryan Scopio
/// Fires a bullet from this object at a defined fire rate
/// IF projectile is a seeker, this requires a targeting computer; probably a safer way to do this
/// </summary>
[RequireComponent(typeof(TargetingComputer))]
public class GunController : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject BulletSpawner;
    public float FireRate = 1f;
    public float Delay = 0f;
    private float fireDelay;

    public float Power = 0.1f;
    float timer = 0f;
    TargetingComputer targComp;

    void Start()
    {
        targComp = GetComponent<TargetingComputer>();
    }

    void Update()
    {
        if (targComp.Target)
        {
            timer += Time.deltaTime;
            if (timer >= FireRate + fireDelay)
            {
                fireDelay = 0f;
                timer = 0f;
                GameObject newBullet = (GameObject)Instantiate(Bullet, BulletSpawner.transform.position, transform.rotation);

                BulletController newBullCon = newBullet.GetComponent<BulletController>();
                newBullCon.Target = targComp.Target;
                newBullCon.Creator = transform.root.gameObject;

                Seek seeker = newBullet.GetComponent<Seek>();
                if (seeker)
                {
                    seeker.Power = Power;
                }
                else
                {
                    Rigidbody2D bulletBody = newBullet.GetComponent<Rigidbody2D>();
                    bulletBody.AddRelativeForce(Vector2.up * Power, ForceMode2D.Impulse);
                }
            }
        }
        else
        {
            fireDelay = Delay;
        }
    }
}
