using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float rotateSpeed = 5f;
    [SerializeField] private GameObject camera;

    private void Update() {
        // Move the camera using the WASD keys
        float x = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        camera.transform.Translate(x, 0, z);

        // Rotate the camera using the right mouse button and mouse movement
        if (Input.GetMouseButton(1)) {
            float mouseX = Input.GetAxis("Mouse X") * rotateSpeed;
            float mouseY = Input.GetAxis("Mouse Y") * rotateSpeed;
            camera.transform.eulerAngles += new Vector3(-mouseY, mouseX, 0);
        }
    }
}