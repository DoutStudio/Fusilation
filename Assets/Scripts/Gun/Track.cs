using UnityEngine;
using System.Collections;
[RequireComponent(typeof(GunController))]
public class Track : MonoBehaviour
{

    public Transform Target;
    public float TurnSpeed = 5;

    Rigidbody2D targetBody;
    GunController gun;
    float bulletSpeed;

    // Use this for initialization
    void Start()
    {
        targetBody = Target.GetComponent<Rigidbody2D>();
        gun = GetComponent<GunController>();
        bulletSpeed = gun.Bullet.GetComponent<Rigidbody2D>().velocity.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        if (Target)
        { // enemy alive and at sight: aim at him!

            transform.Rotate(transform.forward, CalculateIntercourse(Target.position, targetBody.velocity, transform.position, gun.Power));

            /*
            Vector3 dir = CalculateIntercourse(Target.position, targetBody.velocity, transform.position, gun.Power);

            Quaternion rot = Quaternion.FromToRotation(Vector3.up, dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, TurnSpeed * Time.deltaTime);
            */
            // you may shoot here
        }
        else
        {
            // no enemy or enemy dead: find the nearest
            // victim and assign it to currentEnemy
        }
    }

    public static float CalculateIntercourse(Vector3 targetPos, Vector3 targetSpeed, Vector3 turretPos, float bulletSpeed)
    {
        Vector3 diff = Vector3.Normalize(targetPos - turretPos);
        Vector3 diffJ = diff * Vector3.Dot(diff, targetSpeed);
        Vector3 diffU = targetSpeed - diffJ;
        float magNorm = Mathf.Sqrt(Mathf.Pow(bulletSpeed, 2) - Mathf.Pow(diffU.magnitude, 2));
        Vector3 mag = diff * magNorm;
        Vector3 attackVector = diffU + mag;

        float angle = Mathf.Acos((Vector3.Dot(diff, attackVector) / (diff.magnitude * attackVector.magnitude)));

        return angle;
    }
}
