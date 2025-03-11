using UnityEngine;
using UnityEngine.SceneManagement; // For scene loading
using UnityEngine.UI; // For UI elements
using TMPro; // Add this line at the top for TextMeshPro

public class BenchPressMiniGame : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI pressCountText; // Change the Text type to TextMeshProUGUI
    public Slider progressBar;
    public Image benchPressImage;
    public Sprite image1; // Barbell down
    public Sprite image2; // Barbell up

    [Header("Audio")]
    public AudioSource audioSource; // For playing grunting sounds
    public AudioClip[] grunts; // Array to hold different grunt sounds

    [Header("Game Settings")]
    private int pressCount = 0;
    private int targetPressCount = 25;
    private bool isImage1Active = true;

    void Start()
    {
        UpdateUI();
        if (benchPressImage != null && image1 != null)
        {
            benchPressImage.sprite = image1;
        }
        else
        {
            Debug.LogError("BenchPressImage or Image1 not assigned!");
        }
    }

    void Update()
    {
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
            int randomIndex = Random.Range(0, grunts.Length); // Pick a random grunt sound
            audioSource.PlayOneShot(grunts[randomIndex]);
        }
        else
        {
            Debug.LogError("AudioSource or Grunt clips not assigned.");
        }
    }

    void UpdateUI()
    {
        if (pressCountText != null)
        {
            pressCountText.text = "Press Count: " + pressCount.ToString();
        }

        if (progressBar != null)
        {
            progressBar.value = (float)pressCount / targetPressCount;
        }
    }

    void WinMiniGame()
    {
        Debug.Log("Bench press completed!");
        SceneManager.LoadScene("MainGameScene");
    }
}

