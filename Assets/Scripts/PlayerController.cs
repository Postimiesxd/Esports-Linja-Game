using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float mouseSensitivity = 100f;
    private float rotationY = 0f;
    public Camera topDownCamera;

    void Start()
    {
        if (topDownCamera != null)
        {
            topDownCamera.transform.position = new Vector3(-0.07f, 28.3f, 1.24f); // Fixed position
            topDownCamera.transform.rotation = Quaternion.Euler(90f, 0f, 0f); // Top-down angle
        }
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        MovePlayer();
        RotatePlayer();
        CheckInteraction();
    }

    void MovePlayer()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        transform.position += move * moveSpeed * Time.deltaTime;
    }

    void RotatePlayer()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        rotationY += mouseX;
        transform.rotation = Quaternion.Euler(0f, rotationY, 0f);
    }

    void CheckInteraction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 3f))
            {
                if (hit.collider.CompareTag("Computer"))
                {
                    Debug.Log("Interacted with Computer!");
                }
                else if (hit.collider.CompareTag("BenchPress"))
                {
                    Debug.Log("Interacted with BenchPress!");
                }
                else if (hit.collider.CompareTag("Fridge"))
                {
                    Debug.Log("Interacted with Fridge!");
                }
            }
        }
    }
}
