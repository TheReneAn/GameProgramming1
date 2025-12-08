using UnityEngine;
using System.Collections; 

/// <summary>
/// It makes the player invincible for a certain period of time, and after the time passes,
/// it returns the player to their original state.
/// </summary>
public class Ex_PlayerBuffManager : MonoBehaviour
{
    public float invincibilityDuration = 3f; // Duration the invincibility state lasts

    public void Start()
    {
        // Start the invincibility Coroutine!
        StartCoroutine(InvincibilityCoroutine());
    }
    
    private IEnumerator InvincibilityCoroutine()
    {
        Debug.Log("Invincibility effect started! Will last for " + invincibilityDuration + " seconds.");
        
        // Stops execution here and waits for the specified time
        yield return new WaitForSeconds(invincibilityDuration);
        
        // After 3 seconds, the Coroutine resumes and the code below executes.
        Debug.Log("Invincibility effect ended! The player can now take damage again.");
    }
}

