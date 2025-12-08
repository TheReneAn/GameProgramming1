using UnityEngine;

public class Player_Inheritance : MonoBehaviour  // Player "is a" MonoBehaviour
{
    // Player inherits Start(), Update(), OnTriggerEnter2D(), etc.
    // Player can be attached to GameObjects
    // Player has access to transform, gameObject, etc.
    
    private void Start()  // Overriding MonoBehaviour's virtual Start method
    {
        Debug.Log("Player started");
    }
}


