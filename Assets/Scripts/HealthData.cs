using UnityEngine;

[System.Serializable]
public class HealthData
{
    private readonly float minHealth = 0;
    private readonly float healModifier = 0.2f;

    private float health  = 0;
    private float maxHealth = 0;
    private float healAmount = 0;

    private bool wasSet = false;

    public float Health { 
        get { return health; }
        set {
            if (wasSet == false)
            {
                maxHealth = value;
                health = value;
                healAmount = value * healModifier;
                wasSet = true;
                return;
            }
            Debug.LogWarning("Use detract health for setting the health more than once.");
        } 
    }

    public float MaxHealth { get { return maxHealth; } }

    public float Absolute { get { return CodeLibrary.Remap(health, minHealth, maxHealth, 0, 1); } }

    /// <summary>
    /// Returns true if health is above zero.
    /// </summary>
    /// <param name="amount"></param>
    /// <returns></returns>
    public bool Damage(float amount)
    {
        if (amount <= 0) Debug.LogWarning("Damage numbers can't be equal to, or below 0.");
        if (health - amount <= minHealth)
        {
            health = 0;
            return false;
        }
        health -= amount;
        return true;
    }

    /// <summary>
    /// Returns true when done healing. Heals every time it's activated.
    /// </summary>
    /// <returns></returns>
    public bool Heal()
    {
        health = Mathf.Clamp(health + healAmount, minHealth, maxHealth);
        if (health == maxHealth) return true;
        return false;
    }
}
