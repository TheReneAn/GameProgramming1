using UnityEngine;

/// <summary>
/// Utilizes Polymorphism to equip and attack with any weapon.
/// </summary>
public class Ex_PlayerController : MonoBehaviour
{
    // The type is the abstract class 'Weapon'! (Polymorphism)
    private Ex_Weapon _currentExWeapon;

    private void Update()
    {
        // 1. Attempt attack on Left Mouse Button click
        if (Input.GetMouseButtonDown(0))
        {
            TryAttack();
        }
        
        // 2. Change weapon with number keys (Optional)
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // Find and equip the Sword component on the current GameObject
            EquipWeapon(GetComponentInChildren<Ex_Sword>());
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            // Find and equip the Gun component on the current GameObject
            EquipWeapon(GetComponentInChildren<Ex_Gun>());
        }
    }

    private void EquipWeapon(Ex_Weapon newExWeapon)
    {
        if (newExWeapon != null)
        {
            _currentExWeapon = newExWeapon;
            Debug.Log($"Weapon Equipped! (Damage: {_currentExWeapon.Damage})");
        }
        else
        {
            Debug.LogWarning("That weapon component is not on this object!");
        }
    }

    private void TryAttack()
    {
        if (_currentExWeapon != null)
        {
            // Polymorphism Core: Whether currentWeapon is a Sword or a Gun,
            // calling Attack() on the 'Weapon' type executes the 'overridden' Attack()
            // of the actual object type.
            _currentExWeapon.Attack();
        }
        else
        {
            Debug.LogWarning("No weapon equipped!");
        }
    }
}

