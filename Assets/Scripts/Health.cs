using UnityEngine;
using System.Collections;

/// <summary>
/// Ryan Scopio
/// [Not in use]
/// Dictates health of an object
/// Alpha value correlates to health %
/// Regenative health an option
/// </summary>
[RequireComponent(typeof(SpriteRenderer))]
public class Health : MonoBehaviour
{

    public float CurrentHealth;
    public float MaxHealth;
    public float RegenRate;
    public bool DoesRegen;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        CurrentHealth = MaxHealth;
        if(DoesRegen)
        {
            StartCoroutine(RegenHealth());
        }
    }

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
