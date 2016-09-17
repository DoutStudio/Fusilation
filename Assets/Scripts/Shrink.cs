using UnityEngine;
using System.Collections;

public class Shrink : MonoBehaviour
{

    public float ShrinkRate = 1;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(ShrinkRoutine());
    }

    IEnumerator ShrinkRoutine()
    {
        while (true)
        {
            transform.localScale *= ShrinkRate;
            yield return new WaitForSeconds(0.01f);
            if (transform.localScale.magnitude < 0.01f)
            {
                Destroy(transform.gameObject);
            }
        }
    }
}
