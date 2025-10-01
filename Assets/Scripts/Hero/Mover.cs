using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using System.Runtime.CompilerServices;

public class HeroMover : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementY;

    public float speed = 1;

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    //Хрень какая-то с character controller и capsule collider. С Character controller у меня персонаж падает сквозь пол
    // а с capsule collider у меня персонаж приковывается к земле и не может двигаться. Я уменьшил вес с 1 до 0.5,
    // персонаж начал ходить, но я не знаю, правильное ли это решение.

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }
}
