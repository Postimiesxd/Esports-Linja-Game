using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeDuration = 0.5f; // How long the shake lasts
    public float shakeMagnitude = 0.2f; // How strong the shake is

    private Vector3 originalPosition;

    private void Start()
    {
        originalPosition = transform.localPosition; // Store the initial position of the camera
    }

    // Call this function to shake the camera
    public void Shake()
    {
        StartCoroutine(ShakeCoroutine());
    }

    private IEnumerator ShakeCoroutine()
    {
        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            // Generate random shake offsets
            Vector3 shakeOffset = Random.insideUnitSphere * shakeMagnitude;

            // Apply the shake offset to the camera's position
            transform.localPosition = originalPosition + shakeOffset;

            elapsed += Time.deltaTime;
            yield return null;
        }

        // Reset the camera's position back to the original position after shaking
        transform.localPosition = originalPosition;
    }
}
