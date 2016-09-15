using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class Flicker : MonoBehaviour
{

    public float MinimumFlickerSpeed = 1f;
    public float MaximumFlickerSpeed = 3f;
    private float flickerSpeed;
    public Color StartColor = Color.white;
    public Color EndColor = Color.black;
    private SpriteRenderer render;
    private float elapsedTime = 0f;

    // Use this for initialization
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        flickerSpeed = Random.Range(MinimumFlickerSpeed, MaximumFlickerSpeed);
    }

    IEnumerator Fade()
    {
        while(true)
        {
            if(elapsedTime >= flickerSpeed)
            {
                elapsedTime -= flickerSpeed;
                Color temp = StartColor;
                StartColor = EndColor;
                EndColor = temp;
            }
            render.color = Color.Lerp(StartColor, EndColor, elapsedTime / flickerSpeed);
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
