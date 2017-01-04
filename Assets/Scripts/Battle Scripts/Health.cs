using UnityEngine;
using System.Collections;

/// <summary>
/// Ryan Scopio
/// Dictates health of an object
/// Regenative health an option
/// </summary>
public class Health : MonoBehaviour
{

    public float CurrentHealth;
    public float MaxHealth;
    public float RegenRate;
    public bool DoesRegen = false;
    public bool DisplayText = false;
    public bool DisplayDot = false;
    public GameObject HealthDot;

    private SpriteRenderer dot;
    private TextMesh textMesh;

    void Start()
    {
        CurrentHealth = MaxHealth;
        //CurrentHealth = Random.Range(0, MaxHealth);
        if (DisplayText)
        {
            MeshRenderer mesh = GetComponent<MeshRenderer>();
            mesh.sortingLayerName = "Text";
            textMesh = GetComponent<TextMesh>();
        }

        if (DisplayDot)
        {
            dot = HealthDot.GetComponent<SpriteRenderer>();
        }
        else if (HealthDot)
        {
            HealthDot.SetActive(false);
        }

        if (DoesRegen)
        {
            StartCoroutine(RegenHealth());
        }

    }

    void Update()
    {
        if (DisplayDot)
        {
            dot.color = Color.Lerp(Color.red, Color.green, CurrentHealth / MaxHealth);
        }
        if (DisplayText)
        {
            textMesh.text = (int)CurrentHealth + "/" + MaxHealth;
            textMesh.color = Color.Lerp(Color.red, Color.green, CurrentHealth / MaxHealth);
        }
        if (CurrentHealth <= 0)
        {
            transform.gameObject.SetActive(false);
        }
    }

    IEnumerator RegenHealth()
    {
        while (true)
        {
            CurrentHealth += 0.01f;
            yield return new WaitForSeconds(RegenRate);
        }
    }
}
