using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComputerMinigame : MonoBehaviour
{
    private int targetsHit = 0;
    private int totalTargets = 3;
    public float celebrationDelay = 2f;
    public GameObject confettiPrefab; // Assign this in Unity

    public void OnTargetHit()
    {
        targetsHit++;
        if (targetsHit >= totalTargets)
        {
            StartCoroutine(CelebrateAndEnd());
        }
    }

    IEnumerator CelebrateAndEnd()
    {
        Debug.Log("Celebration started!");

        if (confettiPrefab != null)
        {
            GameObject confetti = Instantiate(confettiPrefab, Camera.main.transform.position + new Vector3(0, 3, 5), Quaternion.identity);
            confetti.SetActive(true);

            ParticleSystem confettiParticles = confetti.GetComponent<ParticleSystem>();
            if (confettiParticles != null)
            {
                confettiParticles.Play();
                Debug.Log("Confetti playing!");
            }
            else
            {
                Debug.LogError("No ParticleSystem found on confettiPrefab!");
            }
        }
        else
        {
            Debug.LogError("Confetti prefab is null!");
        }

        Vector3 confettiPosition = Camera.main.transform.position + Camera.main.transform.forward * 5 + new Vector3(0, 0, 100);
        Instantiate(confettiPrefab, confettiPosition, Quaternion.identity);

        yield return new WaitForSeconds(celebrationDelay);
        SceneManager.LoadScene("MainGameScene");
    }
}
