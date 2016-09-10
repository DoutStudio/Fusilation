using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class Flicker : MonoBehaviour
{

    public float minimumFlickerSpeed = 0.3f;
    public float maximumFlickerSpeed = 1f;
    private float flickerSpeed;
    public Color startColor = Color.white;
    public Color endColor = Color.black;
    private SpriteRenderer render;
    private float elapsedTime = 0f;

    // Use this for initialization
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        flickerSpeed = Random.Range(minimumFlickerSpeed, maximumFlickerSpeed);
    }

    IEnumerator Fade()
    {
        while(true)
        {
            if(elapsedTime >= flickerSpeed)
            {
                elapsedTime -= flickerSpeed;
                Color temp = startColor;
                startColor = endColor;
                endColor = temp;
            }
            render.color = Color.Lerp(startColor, endColor, elapsedTime / flickerSpeed);
            elapsedTime += 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void OnBecameInvisible()
    {
        StopCoroutine(Fade());
    }

    public void OnBecameVisible()
    {
        StartCoroutine(Fade());
    }
}
