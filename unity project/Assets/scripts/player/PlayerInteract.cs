using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float distance = 3f;
    [SerializeField] private LayerMask mask;
    [SerializeField] private InputControl inputControl;

    void Start()
    {
        inputControl.onEPressed += onEFunc;
    }

    void Update()
    {

    }
    public void onEFunc(object obj, EventArgs e) {
        Debug.Log("e");
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, distance, mask)) {
            if (hit.collider.GetComponent<Interact>() != null) {
                if(hit.transform.TryGetComponent(out BallIntetact ball)) {
                    ball.interact();
                }
                if (hit.transform.TryGetComponent(out CubeInteract cube)) {
                    cube.interact();
                }
            }
        }
    }
}
