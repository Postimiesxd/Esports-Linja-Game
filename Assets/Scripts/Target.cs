using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    private ComputerMinigame minigameManager;
    private Image targetImage;

    public Sprite hitSprite; // Assign in the Inspector

    void Start()
    {
        minigameManager = FindObjectOfType<ComputerMinigame>();
        targetImage = GetComponent<Image>();
    }

    public void HitTarget()
    {
        if (hitSprite != null)
        {
            targetImage.sprite = hitSprite; // Change the sprite
        }
        GetComponent<Button>().interactable = false; // Disable further clicks
        minigameManager.OnTargetHit();
    }
}
