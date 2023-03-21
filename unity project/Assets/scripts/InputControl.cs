using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InputControl : MonoBehaviour {

    [SerializeField] private PlayerInput playerInputAction;
    [SerializeField] private PlayerCamera playerCamera;
    public event EventHandler onJumpPressed;


    private void Start() {
    }
    private void Awake() {
        playerInputAction=new PlayerInput();
        playerCamera = GetComponent<PlayerCamera>();
        playerInputAction.player.Enable();
    }
    public Vector2 getPlayerMovVec2Norm() {
        Vector2 input = playerInputAction.player.move.ReadValue<Vector2>();
        return input.normalized;
    }
    private void Update() {
        if (playerInputAction.player.jump.WasPressedThisFrame()) {
            onJumpPressed?.Invoke(this, EventArgs.Empty);
        }
        playerCamera.looking(playerInputAction.player.look.ReadValue<Vector2>());
    }
}
