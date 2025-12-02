using UnityEngine;

public class Collectible : MonoBehaviour
{
    // Points awarded when collected
    private readonly int _scoreValue = 10;
    
    private void Awake()
    {
        // Try to get the CircleCollider2D component attached to this GameObject
        var circleCollider2D = GetComponent<CircleCollider2D>();
        if (circleCollider2D == null)
        {
            // If no CircleCollider2D exists, add one automatically
            gameObject.AddComponent<CircleCollider2D>();
        }
        
        // Set as trigger so player can pass through while detecting collision
        // Is Trigger ON = Can pass through but still detect
        // Is Trigger OFF = Blocks the player (not what we want for collectibles)
        circleCollider2D.isTrigger = true;
    }
    
    // OnTriggerEnter2D: Called when another collider ENTERS this trigger
    // Only works when "Is Trigger" is checked on the collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object that touched us is the Player
        // CompareTag is more efficient than using == "Player"
        if (other.CompareTag("Player") == false)
        {
            return;
        }
        
        // Award points
        var gameManager = FindObjectOfType<GameManager>();
        if (gameManager == null)
        {
            Debug.Log("GameManager is null", gameObject);
            return;
        }
        gameManager.AddGem(_scoreValue);
        
        // Remove collectible
        Destroy(gameObject);
    }
}
