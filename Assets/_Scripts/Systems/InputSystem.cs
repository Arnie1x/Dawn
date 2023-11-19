using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem : Singleton<InputSystem>
{
    [HideInInspector] public static bool isAttacking;
    [HideInInspector] public static bool isJumping;

    private PlayerInput _input;
    public InputAction moveAction;
    public InputAction sprintAction;
    public InputAction aimAction;
    public InputAction jumpAction;
    public InputAction attackAction;
    public InputAction reloadAction;
    public InputAction pauseAction;

    protected override void Awake()
    {
        base.Awake();
        _input = GetComponent<PlayerInput>();
        moveAction = _input.actions["Move"];
        sprintAction = _input.actions["Sprint"];
        aimAction = _input.actions["Aim"];
        jumpAction = _input.actions["Jump"];
        attackAction = _input.actions["Attack"];
        reloadAction = _input.actions["Reload"];
        pauseAction = _input.actions["Pause"];

        //if (controls == null)
        //{
        //    controls = new InputActions();
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}
    }

    private void OnEnable()
    {
        //controls.Enable();

        //controls.Player.Attack.started += Attack_started;
        //controls.Player.Attack.canceled += Attack_canceled;

        //controls.Player.Jump.performed += Jumped;
        //controls.Player.Crouch.performed += Crouched;
    }

    private void OnDisable()
    {
        //controls.Disable();
        //controls.Player.Attack.started -= Attack_started;
        //controls.Player.Attack.canceled -= Attack_canceled;

        //controls.Player.Jump.performed -= Jumped;
        //controls.Player.Crouch.performed -= Crouched;
    }

    private void Attack_canceled(InputAction.CallbackContext obj)
    {
        isAttacking = false;
    }

    private void Attack_started(InputAction.CallbackContext obj)
    {
        isAttacking = true;
    }
    private void Jumped(InputAction.CallbackContext obj)
    {
        isJumping = true;
    }
}
