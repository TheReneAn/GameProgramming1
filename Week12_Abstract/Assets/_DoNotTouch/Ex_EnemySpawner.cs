using UnityEngine;
using System.Collections; // Required for using IEnumerator and Coroutines

/// <summary>
/// Manages continuous enemy spawning at a set interval.
/// </summary>
public class Ex_EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Assign your enemy Prefab in the Inspector
    public float spawnInterval = 2f; // Time in seconds between each spawn

    // A reference to the object that enemies will be spawned at.
    // Assign a child GameObject in the Inspector to act as the spawn point.
    public Transform spawnPoint; 

    public void Start()
    {
        // Start the routine that will continuously spawn enemies.
        StartCoroutine(SpawnEnemiesRoutine());
    }

    /// <summary>
    /// Coroutine to handle the repetitive spawning of enemies.
    /// </summary>
    private IEnumerator SpawnEnemiesRoutine()
    {
        // The while(true) loop makes this Coroutine run forever (or until the object is destroyed).
        while (true)
        {
            // 1. Wait for the specified interval before continuing.
            yield return new WaitForSeconds(spawnInterval);

            // 2. The code resumes here after the wait.
            // Instantiate (create a new copy of) the enemy Prefab.
            // It uses the position and rotation of the assigned spawnPoint Transform.
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            
            Debug.Log("Enemy spawned!");
        }
    }
}

