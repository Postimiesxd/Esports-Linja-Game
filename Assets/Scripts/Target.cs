using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    private ComputerMinigame minigameManager;

    void Start()
    {
        minigameManager = FindObjectOfType<ComputerMinigame>();
    }

    public void HitTarget()
    {
        gameObject.SetActive(false); // Hide target when clicked
        minigameManager.OnTargetHit();
    }
}
