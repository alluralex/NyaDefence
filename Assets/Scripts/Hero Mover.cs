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

    //����� �����-�� � character controller � capsule collider. � Character controller � ���� �������� ������ ������ ���
    // � � capsule collider � ���� �������� ������������� � ����� � �� ����� ���������. � �������� ��� � 1 �� 0.5,
    // �������� ����� ������, �� � �� ����, ���������� �� ��� �������.

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
