using UnityEngine;
using System.Collections;

public class StarSpawnerControl : MonoBehaviour
{

    [Range(10f, 10000f)]
    public int starCount = 100;
    public float spawnAreaRadius = 100;
    public float minZ = 20;
    public float maxZ = 50;
    public GameObject starPrefab;
    public GameObject starParent;
    public Vector3 starSpawnCenter = Vector3.zero;

    [ColorUsage(false)]
    public Color[] colors;
    [Range(0f, 1f)]
    public float DarkenVariant = 0;

    // Use this for initialization
    void Start()
    {
        if (colors.Length == 0)
        {
            return;
        }
        for (int i = 0; i < starCount; i++)
        {
            Vector2 spawnZone = Random.insideUnitCircle * spawnAreaRadius;
            GameObject star = (GameObject)Instantiate(starPrefab,
                new Vector3(spawnZone.x, spawnZone.y, Random.Range(minZ, maxZ)),
                Quaternion.identity);
            Flicker starScript = star.GetComponent<Flicker>();

            starScript.startColor = Color.Lerp(colors[Random.Range(0, colors.Length)], Color.white, Random.Range(0, DarkenVariant));
            starScript.endColor = Color.Lerp(starScript.startColor, Color.white, Random.Range(0f, 1f));
            star.transform.SetParent(starParent.transform);
        }
    }
}
