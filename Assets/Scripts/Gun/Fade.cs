using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class Fade : MonoBehaviour {

    public float FadeRate = 1f;
    public bool QuickEnd = false;

    SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(FadeRoutine());
    }

    IEnumerator FadeRoutine()
    {
        while (true)
        {
            spriteRenderer.color = Color.Lerp(spriteRenderer.color, Color.clear, FadeRate);
            yield return new WaitForSeconds(0.01f);
            if (QuickEnd && spriteRenderer.color.a < 230f / 255f)
            {
                FadeRate = 0.1f;
            }
            if (spriteRenderer.color.a < 0.1f)
            {
                Destroy(transform.gameObject);
            }
        }
    }
}
