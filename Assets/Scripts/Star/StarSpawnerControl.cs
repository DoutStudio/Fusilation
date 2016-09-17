using UnityEngine;
using System.Collections;

public class StarSpawnerControl : MonoBehaviour
{

    [Range(10f, 10000f)]
    public int StarCount = 7000;
    public float SpawnAreaRadius = 500;
    public float MinZ = 20;
    public float MaxZ = 80;
    public GameObject StarPrefab;
    public GameObject StarParent;
    public Vector3 StarSpawnCenter = Vector3.zero;

    [ColorUsage(false)]
    public Color[] Colors = { Color.white, Color.red, Color.blue };
    [Range(0f, 1f)]
    public float BrightnessVariant = 0;

    // Use this for initialization
    void Start()
    {
        if (Colors.Length == 0)
        {
            return;
        }
        for (int i = 0; i < StarCount; i++)
        {
            Vector2 spawnZone = Random.insideUnitCircle * SpawnAreaRadius;
            GameObject star = (GameObject)Instantiate(StarPrefab,
                new Vector3(spawnZone.x, spawnZone.y, Random.Range(MinZ, MaxZ)),
                Quaternion.identity);
            Flicker starScript = star.GetComponent<Flicker>();

            starScript.StartColor = Color.Lerp(Colors[Random.Range(0, Colors.Length)], Color.white, Random.Range(0, BrightnessVariant));
            starScript.EndColor = Color.Lerp(starScript.StartColor, Color.white, Random.Range(0f, 1f));
            star.transform.SetParent(StarParent.transform);
        }
    }
}
