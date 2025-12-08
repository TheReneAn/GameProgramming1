using UnityEngine;

/// <summary>
/// Inherits from Weapon and implements Attack().
/// </summary>
public class Ex_Gun : Ex_Weapon
{
    public float MuzzleVelocity = 20f; // Muzzle velocity

    /// <summary>
    /// Abstract Method Implementation: Completes the 'body' for spawning and firing a bullet.
    /// </summary>
    public override void Attack()
    {
        if (CanAttack == false)
        {
            Debug.Log($"The gun is still on cooldown. ({Cooldown}s)");
            return;
        }

        // 1. Execute attack logic (e.g., instantiate and fire a projectile)
        Debug.Log($"[Gun Attack] Fired a {Damage} damage bullet at speed {MuzzleVelocity}!");

        // 2. Apply cooldown
        ApplyCooldown();
    }
}

