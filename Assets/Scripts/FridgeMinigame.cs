using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class FridgeMinigame : MonoBehaviour
{
    [Header("UI Elements")]
    public TMP_Text scoreText;
    public TMP_Text feedbackText;

    [Header("Game Settings")]
    public int correctFoodCount = 5;
    private int currentScore = 0;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip correctSound;
    public AudioClip wrongSound;

    // Called when a food item is clicked
    public void SelectFood(Button foodButton, bool isHealthy)
    {
        // Disable the button after it's clicked
        foodButton.interactable = false;

        if (isHealthy)
        {
            currentScore++;
            feedbackText.text = "Healthy choice!";
            PlaySound(correctSound);
        }
        else
        {
            feedbackText.text = "Not so healthy...";
            PlaySound(wrongSound);
        }

        UpdateScore();
        CheckWinCondition();
    }

    void UpdateScore()
    {
        scoreText.text = "Healthy Foods: " + currentScore + " / " + correctFoodCount;
    }

    void CheckWinCondition()
    {
        if (currentScore >= correctFoodCount)
        {
            WinMiniGame();
        }
    }

    void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    void WinMiniGame()
    {
        Debug.Log("You picked all the healthy foods!");
        SceneManager.LoadScene("MainGameScene");
    }
}
