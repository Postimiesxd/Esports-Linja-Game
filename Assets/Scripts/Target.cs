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

    public void Hit()
    {
        Debug.Log(gameObject.name + " was hit!");
        gameObject.SetActive(false); // Or add a fancier effect
    }
}
