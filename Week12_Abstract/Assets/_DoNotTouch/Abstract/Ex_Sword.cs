using UnityEngine;

/// <summary>
/// Inherits from Weapon and implements the abstract Attack() method.
/// </summary>
public class Ex_Sword : Ex_Weapon
{
    public float Range = 1.5f;

    /// <summary>
    /// Abstract Method Implementation:
    /// Completes the 'body' of the Attack() method required by the parent.
    /// </summary>
    public override void Attack()
    {
        if (CanAttack == false)
        {
            Debug.Log($"The sword is still on cooldown. ({Cooldown}s)");
            return;
        }

        // 1. Execute attack logic (e.g., detect nearby enemies, play animation)
        Debug.Log($"[Sword Attack] Slashed a {Range}m radius for {Damage} damage.");
        
        // 2. Apply cooldown
        ApplyCooldown();
    }
}

