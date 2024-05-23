using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;

    [Header("Hareket ve Fizik")]
    [SerializeField] private float walkSpeed = 4f, xSpeed = 6f, _gravity = -9.8f, _jump = 1f;

    [Header("Zemin Kontrol")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.3f;
    [SerializeField] private LayerMask groundMask;

    [Header("Yön ve Yerçekimi")]
    Vector3 Velocity;
    private bool isOnGround;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        isOnGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isOnGround && Velocity.y < 0)
        {
            Velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        characterController.Move(move * walkSpeed * Time.deltaTime);

        if(Input.GetKey(KeyCode.LeftShift))
        {
            characterController.Move(move * xSpeed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.Space) && isOnGround)
        {
            Velocity.y = Mathf.Sqrt(_jump * -2f * _gravity);
        }

        Velocity.y += _gravity * Time.deltaTime;

        characterController.Move(Velocity * Time.deltaTime);
    }
}
