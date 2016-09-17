using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class Health : MonoBehaviour
{

    public float CurrentHealth;
    public float MaxHealth;
    public float RegenRate;
    public bool DoesRegen;

    SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        CurrentHealth = MaxHealth;
        if(DoesRegen)
        {
            StartCoroutine(RegenHealth());
        }
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.color = new Color(spriteRenderer.color.a, spriteRenderer.color.g, spriteRenderer.color.b, CurrentHealth / MaxHealth);
    }

    IEnumerator RegenHealth()
    {
        while(true)
        {
            CurrentHealth += 0.01f;
            yield return new WaitForSeconds(RegenRate);
        }
    }
}
