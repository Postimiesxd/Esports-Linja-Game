using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // For scene loading
using UnityEngine.UI; // For UI elements
using TMPro; // Add this line at the top for TextMeshPro

public class BenchPressMiniGame : MonoBehaviour
{
    private MainGameTimer mainGameTimer;

    [Header("UI Elements")]
    public TMP_Text pressCountText;
    public Slider progressBar;
    public Image benchPressImage;
    public Sprite image1; // Barbell down
    public Sprite image2; // Barbell up
    public TMP_Text timerText;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip[] grunts;
    public AudioClip beepSound; // Beep for countdown

    [Header("Game Settings")]
    private int pressCount = 0;
    private int targetPressCount = 25;
    private bool isImage1Active = true;

    [Header("Timer Settings")]
    public float timeLimit = 10f;
    private float currentTime;
    private int lastBeepTime = -1;

    public Scorekeeper scorekeeper;

    void Start()
    {
        scorekeeper = FindObjectOfType<Scorekeeper>();

        currentTime = timeLimit;
        UpdateUI();
        if (benchPressImage != null && image1 != null)
        {
            benchPressImage.sprite = image1;
        }
        else
        {
            Debug.LogError("BenchPressImage or Image1 not assigned!");
        }
        mainGameTimer = FindObjectOfType<MainGameTimer>();
        mainGameTimer.SetTimerVisibility(false);
    }

    void Update()
    {
        // Countdown timer
        currentTime -= Time.deltaTime;
        int timeLeft = Mathf.CeilToInt(currentTime);
        timerText.text = "" + timeLeft.ToString();

        // Play beeping sound at each second
        if (timeLeft != lastBeepTime && timeLeft > 0)
        {
            PlayBeep(timeLeft);
            lastBeepTime = timeLeft;
        }

        if (currentTime <= 0f)
        {
            LoseMiniGame();
        }

        // Bench press mechanic
        if (Input.GetKeyDown(KeyCode.Space))
        {
            pressCount++;
            ToggleImage();
            PlayGruntSound();
            UpdateUI();

            if (pressCount >= targetPressCount)
            {
                WinMiniGame();
            }
        }
    }

    void ToggleImage()
    {
        if (benchPressImage != null && image1 != null && image2 != null)
        {
            benchPressImage.sprite = isImage1Active ? image2 : image1;
            isImage1Active = !isImage1Active;
        }
        else
        {
            Debug.LogError("Sprites or Image component are not properly assigned.");
        }
    }

    void PlayGruntSound()
    {
        if (audioSource != null && grunts.Length > 0)
        {
            int randomIndex = Random.Range(0, grunts.Length);
            audioSource.PlayOneShot(grunts[randomIndex]);
        }
        else
        {
            Debug.LogError("AudioSource or Grunt clips not assigned.");
        }
    }

    void PlayBeep(int timeLeft)
    {
        if (audioSource != null && beepSound != null)
        {
            if (timeLeft <= 3) // Faster beeps for last 3 seconds
            {
                audioSource.pitch = 1.5f; // Speed up the beep
            }
            else
            {
                audioSource.pitch = 1.0f; // Normal beep sound
            }
            audioSource.PlayOneShot(beepSound);
        }
    }

    void UpdateUI()
    {
        if (pressCountText != null)
        {
            pressCountText.text = "25/" + pressCount.ToString();
        }

        if (progressBar != null)
        {
            progressBar.value = (float)pressCount / targetPressCount;
        }
    }



    void WinMiniGame()
    {
        mainGameTimer.SetTimerVisibility(true);
        scorekeeper.CheckWhichTaskYouJustDidIDK(1);

        Debug.Log("Bench press completed!");
        //SceneManager.LoadScene("MainGameScene");
    }

    void LoseMiniGame()
    {
        Debug.Log("Time's up! You lost the minigame.");
        SceneManager.LoadScene("BenchPressMinigame");
    }

}

