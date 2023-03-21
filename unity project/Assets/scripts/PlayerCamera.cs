using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
     [SerializeField] private Camera cam;
     [SerializeField]private float xSen=10f;
     [SerializeField] private float ySen= 10f;
     [SerializeField] private float xRotation = 0f;
     [SerializeField] private float yRotation = 0f;
     [SerializeField] private Transform playerBody;
    public void looking(Vector2 input) {

        xRotation -= input.y * Time.deltaTime * ySen;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        yRotation = input.x * Time.deltaTime * xSen;
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * yRotation);
    }

}
