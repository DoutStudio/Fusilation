using UnityEngine;
using System.Collections;

public class BoostSpawner : MonoBehaviour
{

    public GameObject Boost;
    public float SpawnRate = 1;
    public float SpawnVariation = 1;

    GameObject boostParent;

    // Use this for initialization
    void Start()
    {
        boostParent = GameObject.Find("BoostParent");
        StartCoroutine(SpawnBoost());
    }

    IEnumerator SpawnBoost()
    {
        while (true)
        {
            GameObject boost = (GameObject)Instantiate(Boost, transform.position + transform.right * Random.Range(-SpawnVariation, SpawnVariation), transform.rotation);
            if (boostParent)
            {
                boost.transform.parent = boostParent.transform;
            }
            yield return new WaitForSeconds(SpawnRate);
        }
    }

}
