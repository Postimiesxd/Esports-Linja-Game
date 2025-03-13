using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scorekeeper2 : MonoBehaviour
{
    public static Scorekeeper2 Instance;

    public int yellow;
    public int purple;
    public int green;

    private int previous;

    void Start()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Use gameObject instead of "this" to destroy the entire object
        }
    }

    public void CheckWhichTaskYouJustDidIDK(int tasknumber)
    {
        if (previous == tasknumber)
        {
            // Subtract if the same task is repeated
            if (tasknumber == 1) yellow--;
            else if (tasknumber == 2) purple--;
            else if (tasknumber == 3) green--;
        }
        else
        {
            // Add if it's a new task
            if (tasknumber == 1) yellow++;
            else if (tasknumber == 2) purple++;
            else if (tasknumber == 3) green++;
        }

        previous = tasknumber;

        CheckForVictory();
    }

    private void CheckForVictory()
    {
        if (yellow >= 3 || purple >= 3 || green >= 3)
        {
            SceneManager.LoadScene("VictoryScene"); // Make sure the scene name matches exactly
        }
    }
}