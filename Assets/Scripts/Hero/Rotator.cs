using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.UIElements;

public class Rotator : MonoBehaviour
{
    private Rigidbody rb;
    public float rotateX;
    public float rotateY;

    public float rotatespeed = 1;

    private void OnLook(InputValue rotateValue)
    {
        Vector2 rotateVector = rotateValue.Get<Vector2>();
        rotateX = rotateVector.x;
        rotateY = rotateVector.y;
    }
    void Start()
    {
        CursosBlock();
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector2 rotate = new Vector2(rotateX, rotateY);
        rb.AddTorque(rotate * rotatespeed);
    }

    // Ещё большая проблема - так это кружение. Персонаж просто не хочет крутиться. А может я не понял как правильно
    // Это делать хд
    

    void CursosBlock()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;
    }
}
