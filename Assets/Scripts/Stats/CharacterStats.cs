using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth { get; private set; }

    public Stat damage;
    public Stat armour;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(5);
        }
    }

    public void TakeDamage(int damage, bool trueDamage = false)
    {
        if (!trueDamage)
            damage -= armour.GetValue();
        
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int healValue)
    {
        Debug.Log("Healing");
        currentHealth += healValue * -1;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
    }

    public virtual void Die()
    {

    }
}
