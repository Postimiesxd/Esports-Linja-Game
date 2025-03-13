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
            Debug.Log("Repeating the same task, score adjusted down.");
            if (tasknumber == 1) yellow = Mathf.Max(0, yellow - 1);
            else if (tasknumber == 2) purple = Mathf.Max(0, purple - 1);
            else if (tasknumber == 3) green = Mathf.Max(0, green - 1);
        }
        else
        {
            Debug.Log("New task, score adjusted up.");
            if (tasknumber == 1) yellow++;
            else if (tasknumber == 2) purple++;
            else if (tasknumber == 3) green++;
        }

        previous = tasknumber;

        CheckForVictory();
    }

    private void CheckForVictory()
    {
        if (yellow == 1 || purple == 1 || green == 1)
        {
            SceneManager.LoadScene("VictoryScene"); // Make sure the scene name matches exactly
        }
    }
}