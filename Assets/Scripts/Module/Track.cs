using UnityEngine;
using System.Collections;

/// <summary>
/// Ryan Scopio
/// Turns turret to track target
/// Uses predecive firing to lead target
/// </summary>
[RequireComponent(typeof(GunController), typeof(TargetingComputer))]
public class Track : MonoBehaviour
{


    private float TurnSpeed = 0;
    Vector3 interceptionPoint;

    Rigidbody2D targetBody;
    GunController gun;
    float bulletSpeed;

    private TargetingComputer TargetComputer;
    private GameObject Target;

    void Start()
    {
        TargetComputer = GetComponent<TargetingComputer>();
        Target = TargetComputer.Target;
        targetBody = TargetComputer.TargetBody;
        TurnSpeed = TargetComputer.TurnSpeed;

        gun = GetComponent<GunController>();
        bulletSpeed = gun.Bullet.GetComponent<Rigidbody2D>().velocity.magnitude;
    }

    void Update()
    {
        Target = TargetComputer.Target;
        targetBody = TargetComputer.TargetBody;
        if (Target)
        { // enemy alive and at sight: aim at him!

            //Calculate intercept point
            Vector3 IC = CalculateInterceptCourse(Target.transform.position, targetBody.velocity, transform.position, gun.Power);
            if (IC != Vector3.zero)
            {
                IC.Normalize();
                float interceptionTime = FindClosestPointOfApproach(Target.transform.position, targetBody.velocity, transform.position, IC * gun.Power);
                interceptionPoint = (Vector2)Target.transform.position + targetBody.velocity * interceptionTime;
            }

            //Slerp turn isntead of snap
            Vector3 aimTarget = interceptionPoint;

            Vector3 diff = aimTarget - transform.position;
            diff.Normalize();
            float rot = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            //transform.rotation = Quaternion.Euler(0, 0, rot - 90);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, rot - 90), TurnSpeed * Time.deltaTime);

            // you may shoot here
        }
        else
        {
            // no enemy or enemy dead: find the nearest
            // victim and assign it to currentEnemy
        }
    }

    /// <summary>
    /// This makes children cry at night
    /// </summary>
    /// <param name="aTargetPos"></param>
    /// <param name="aTargetSpeed"></param>
    /// <param name="aInterceptorPos"></param>
    /// <param name="aInterceptorSpeed"></param>
    /// <returns></returns>
    public static Vector3 CalculateInterceptCourse(Vector3 aTargetPos, Vector3 aTargetSpeed, Vector3 aInterceptorPos, float aInterceptorSpeed)
    {
        Vector3 targetDir = aTargetPos - aInterceptorPos;

        float iSpeed2 = aInterceptorSpeed * aInterceptorSpeed;
        float tSpeed2 = aTargetSpeed.sqrMagnitude;
        float fDot1 = Vector3.Dot(targetDir, aTargetSpeed);
        float targetDist2 = targetDir.sqrMagnitude;
        float d = (fDot1 * fDot1) - targetDist2 * (tSpeed2 - iSpeed2);
        if (d < 0.1f)  // negative == no possible course because the interceptor isn't fast enough
            return Vector3.zero;
        float sqrt = Mathf.Sqrt(d);
        float S1 = (-fDot1 - sqrt) / targetDist2;
        float S2 = (-fDot1 + sqrt) / targetDist2;

        if (S1 < 0.0001f)
        {
            if (S2 < 0.0001f)
                return Vector3.zero;
            else
                return (S2) * targetDir + aTargetSpeed;
        }
        else if (S2 < 0.0001f)
            return (S1) * targetDir + aTargetSpeed;
        else if (S1 < S2)
            return (S2) * targetDir + aTargetSpeed;
        else
            return (S1) * targetDir + aTargetSpeed;
    }


    /// <summary>
    /// Calculates the time when the two given objects reach their closest point of approach
    /// </summary>
    /// <param name="aPos1">the position of object1</param>
    /// <param name="aSpeed1">the velocity vector of object1 in u/s</param>
    /// <param name="aPos2">the position of object2</param>
    /// <param name="aSpeed2">the velocity vector of object2 in u/s</param>
    /// <returns>the time in seconds when the two objects come closest</returns>
    public static float FindClosestPointOfApproach(Vector3 aPos1, Vector3 aSpeed1, Vector3 aPos2, Vector3 aSpeed2)
    {
        Vector3 PVec = aPos1 - aPos2;
        Vector3 SVec = aSpeed1 - aSpeed2;
        float d = SVec.sqrMagnitude;
        // if d is 0 then the distance between Pos1 and Pos2 is never changing
        // so there is no point of closest approach... return 0
        // 0 means the closest approach is now!
        if (d >= -0.0001f && d <= 0.0002f)
            return 0.0f;
        return (-Vector3.Dot(PVec, SVec) / d);
    }
}
