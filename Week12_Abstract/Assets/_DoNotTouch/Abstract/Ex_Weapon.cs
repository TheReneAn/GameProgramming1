using UnityEngine;

/// <summary>
/// Defines the common properties and behaviors for all weapons.
/// As an abstract class, it cannot be attached to a GameObject by itself.
/// </summary>
public abstract class Ex_Weapon : MonoBehaviour
{
    public int Damage = 10;
    public float Cooldown = 1f;
    
    private float _lastAttackTime;
    
    // CanAttack is true if the current time (Time.time) is greater than or equal
    protected bool CanAttack => Time.time >= _lastAttackTime + Cooldown;

    // Abstract Method: All weapons MUST define an 'Attack' method.
    // Child classes must 'override' this method. (Enforces implementation)
    public abstract void Attack();
    
    /// <summary>
    /// Common Method: The logic for applying cooldown is the same for all weapons.
    /// </summary>
    protected void ApplyCooldown()
    {
        _lastAttackTime = Time.time;
        Debug.Log($"[{gameObject.name}] Cooldown started.");
    }
}

