using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ComputerMinigame : MonoBehaviour
{
    private int targetsHit = 0;
    private int totalTargets = 3;
    public float celebrationDelay = 2f;
    public GameObject confettiPrefab;
    public Texture2D crosshairTexture;
    public GraphicRaycaster raycaster; // Assign the Canvas's GraphicRaycaster
    public AudioSource audioSource; // Assign this in Unity
    public AudioClip hitSound; // Assign your hit sound in Unity
    public AudioClip victorySound; // Assign the victory sound in Unity
    public CameraShake cameraShake; // Reference to the CameraShake script

    private void Start()
    {
        // Ensure the cursor is visible and the crosshair is set
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;  // Unlock the cursor so it can move freely

        if (crosshairTexture != null)
        {
            Cursor.SetCursor(crosshairTexture, new Vector2(crosshairTexture.width / 2, crosshairTexture.height / 2), CursorMode.Auto);
        }
        else
        {
            Debug.LogError("Crosshair texture not assigned!");
        }

        // Ensure cameraShake is assigned (if not, log an error)
        if (cameraShake == null)
        {
            Debug.LogError("CameraShake script is not assigned!");
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left-click to shoot
        {
            Shoot();
        }
    }

    void Shoot()
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };

        List<RaycastResult> results = new List<RaycastResult>();
        raycaster.Raycast(pointerData, results);

        foreach (var result in results)
        {
            Button button = result.gameObject.GetComponent<Button>();
            if (button != null && result.gameObject.CompareTag("Target"))
            {
                Debug.Log("Target hit: " + result.gameObject.name);
                result.gameObject.SetActive(false); // Hides the button

                // Play hit sound
                if (audioSource != null && hitSound != null)
                {
                    audioSource.PlayOneShot(hitSound);
                }

                // Trigger camera shake
                if (cameraShake != null)
                {
                    cameraShake.Shake();
                }

                OnTargetHit();
                break;
            }
        }
    }

    public void OnTargetHit()
    {
        targetsHit++;
        if (targetsHit >= totalTargets)
        {
            // Play the victory sound when all targets are hit
            if (audioSource != null && victorySound != null)
            {
                audioSource.PlayOneShot(victorySound);
            }

            StartCoroutine(CelebrateAndEnd());
        }
    }

    IEnumerator CelebrateAndEnd()
    {
        Debug.Log("Celebration started!");

        if (confettiPrefab != null)
        {
            Vector3 confettiPosition = Camera.main.transform.position + Camera.main.transform.forward * 5 + new Vector3(0, 3, 0);
            GameObject confetti = Instantiate(confettiPrefab, confettiPosition, Quaternion.identity);
            confetti.SetActive(true);

            ParticleSystem confettiParticles = confetti.GetComponent<ParticleSystem>();
            if (confettiParticles != null)
            {
                confettiParticles.Play();
            }
        }

        yield return new WaitForSeconds(celebrationDelay);
        SceneManager.LoadScene("MainGameScene");
    }
}
