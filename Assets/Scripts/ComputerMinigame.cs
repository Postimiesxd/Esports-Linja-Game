using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComputerMinigame : MonoBehaviour
{
    private int targetsHit = 0;
    private int totalTargets = 3;

    public void OnTargetHit()
    {
        targetsHit++;
        if (targetsHit >= totalTargets)
        {
            EndMinigame();
        }
    }

    void EndMinigame()
    {
        SceneManager.LoadScene("MainGameScene"); // Change to your main game scene name
    }
}
