using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement; // For scene loading
using UnityEngine;

public class MainGameTimer : MonoBehaviour
{

    public static GameObject TimerInstance;
    public TMP_Text timerText;
    private bool TimerActive;

    [Header("Timer Settings")]
    public float timeLimit = 300f;
    private float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        if (TimerInstance == null)
        {
            TimerInstance = gameObject;
            DontDestroyOnLoad(TimerInstance);
        }
        else
        {
            Destroy(gameObject);
        }
        currentTime = timeLimit;
        SetTimerActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        // Countdown timer
        if (TimerActive){
            currentTime -= Time.deltaTime;
            int timeLeft = Mathf.CeilToInt(currentTime);
            timerText.text = "" + timeLeft.ToString();

            if (currentTime <= 0f)
            {
                LoseMiniGame();
            }
        }
    }

    public void SetTimerActive(bool newActive)
    {
        TimerActive = newActive;
    }

    public void SetTimerVisibility(bool newVisibility)
    {
        timerText.enabled = newVisibility;
    }

    public void LoseMiniGame()
    {
        SetTimerActive(false);
        Debug.Log("Peli havitty!");
        SceneManager.LoadScene("LoseTooBuff");
    }
}
