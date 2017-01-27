using UnityEngine;
using System.Collections;
using System.Linq;
/// <summary>
/// Ryan Scopio
/// Creates a cool laser effect via broken sin waves
/// </summary>
[RequireComponent(typeof(LineRenderer))]
public class RayGun : MonoBehaviour
{

    public bool Arc = false;
    public float ArcScale = 1f;
    public float DPS = 3f;

    private GameObject Target;
    private TargetingComputer targComp;
    private float min = 0.5f;
    private float max = 1.3f;
    private int vertexCount = 20;

    LineRenderer line;
    LineRenderer arcLine;

    // Use this for initialization
    void Start()
    {
        targComp = transform.parent.GetComponent<TargetingComputer>();
        Target = targComp.Target;

        line = GetComponent<LineRenderer>();
        arcLine = GetComponentsInChildren<LineRenderer>()[1];

        line.numPositions = 2;
        arcLine.numPositions = vertexCount;
        arcLine.enabled = false;

        line.sortingLayerName = "Projectiles";
        line.sortingOrder = 3;
        arcLine.sortingLayerName = "Projectiles";
        arcLine.sortingOrder = 3;

        StartCoroutine(DamageRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        Target = targComp.Target;
        if (Target)
        {
            //rotate
            Vector3 diff = Target.transform.position - transform.position;
            diff.Normalize();
            float rot = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rot);

            line.enabled = true;
            Ray2D ray = new Ray2D(transform.position, Target.transform.position);

            line.SetPosition(0, ray.origin);
            line.SetPosition(1, Target.transform.position);

            if (Arc)
            {
                arcLine.enabled = true;
                float distance = Vector2.Distance(transform.position, Target.transform.position);
                for (int i = 1; i < vertexCount; i++)
                {
                    float x = Mathf.Lerp(0, distance, (float)i / (float)(vertexCount - 1));
                    Vector2 pos = new Vector2(
                        x,
                        i == vertexCount ? pos.y = 0 : ArcScale * Mathf.Sin(i + Time.time * Random.Range(min, max) * 5f)
                    );
                    arcLine.SetPosition(i, pos);
                }
            }
        }
        else
        {
            line.enabled = false;
            arcLine.enabled = false;
        }
    }

    IEnumerator DamageRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (Target)
            {
                Health itemHealth = Target.transform.root.GetComponent<Health>();
                if (itemHealth)
                {
                    itemHealth.CurrentHealth -= DPS;
                }
                ((GameObject)Instantiate(Resources.Load("Prefabs/Hit FX"), Target.transform.position, Quaternion.Euler(Vector3.zero))).transform.parent = GameObject.Find("Comic FX Parent").transform;
            }
        }
    }
}
