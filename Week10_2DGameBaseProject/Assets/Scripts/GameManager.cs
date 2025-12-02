using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Tooltip("UI Text to display the current score")]
    public TextMeshProUGUI ScoreText;
    
    // Current score value
    private int _currentScore;
    
    private void Start()
    {
        // Initialize score display
        UpdateScoreUI();
    }
    
    /// <summary>
    /// Called when player collects a gem
    /// </summary>
    /// <param name="scoreValue">Points to add (usually 10)</param>
    public void AddGem(int scoreValue)
    {
        // Add points to current score
        _currentScore += scoreValue;
        
        // Update the UI to show new score
        UpdateScoreUI();
        
        Debug.Log($"Gem collected! Score: {_currentScore}");
    }
    
    /// <summary>
    /// Updates the score text on screen
    /// </summary>
    private void UpdateScoreUI()
    {
        // Check if scoreText is assigned
        if (ScoreText != null)
        {
            // Update text to show current score
            ScoreText.text =  $"{_currentScore}";
        }
        else
        {
            Debug.LogWarning("Score Text is not assigned in Inspector!");
        }
    }
}