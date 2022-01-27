using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerInputBehaviour playerInputBehaviour;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Rigidbody rigidbody;

    [SerializeField] private float speed = 1f;

    private void Awake()
    {
        if (playerInputBehaviour == null)
        {
            playerInputBehaviour = GetComponent<PlayerInputBehaviour>();
        }
        if (playerCamera == null)
        {
            playerCamera = Camera.current;
        }
        if (rigidbody == null)
        {
            rigidbody = GetComponent<Rigidbody>();
        }
    }

    private void Reset()
    {
        if (playerInputBehaviour == null)
        {
            playerInputBehaviour = GetComponent<PlayerInputBehaviour>();
        }
        if (playerCamera == null)
        {
            playerCamera = Camera.current;
        }
        if (rigidbody == null)
        {
            rigidbody = GetComponent<Rigidbody>();
        }
    }

    private void FixedUpdate()
    {
        Move(playerInputBehaviour.Movement);
    }

    private void Move(Vector2 movement)
    {
        // todo - change the movement to be with target speed. i.e. when the vector is zero it should calculate the force to add to get to zero velocity.
        if (movement.sqrMagnitude > 1)
        {
            movement.Normalize();
        }

        var movement3D = new Vector3(movement.x, 0, movement.y);
        var cameraYAngle = playerCamera.transform.rotation.eulerAngles.y;
        movement3D = Quaternion.Euler(0, cameraYAngle, 0) * movement3D;

        rigidbody.AddForce(movement3D * speed);
    }
}
