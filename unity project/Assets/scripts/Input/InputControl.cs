using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class InputControl : MonoBehaviour {

    [SerializeField] private PlayerInput playerInputAction;
    [SerializeField] private PlayerCamera playerCamera;
    public event EventHandler onJumpPressed;
    public event EventHandler onEPressed;
    public event EventHandler onShoot;


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
        if (playerInputAction.player.eInteract.WasPressedThisFrame()) {
            onEPressed?.Invoke(this, EventArgs.Empty);
        }
        if (playerInputAction.player.shoot.IsPressed()) {
            onShoot?.Invoke(this, EventArgs.Empty);
        }
        playerCamera.looking(playerInputAction.player.look.ReadValue<Vector2>());
    }
}
