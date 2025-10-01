using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Hero : MonoBehaviour
{
	public float moveSpeed;
	public float turnSpeed;

    private Animator animator;
	private CharacterController controller;

	private Inventory inventory;
	void OnTriggerEnter(Collider other)
	{
        Item itemInRange;
		Debug.Log("� ����� � �������� � �����:" + other.tag + " � � ������: " + other.name);
		if (other.CompareTag("Item"))
		{
			itemInRange = other.GetComponent<Item>();
			if (itemInRange != null)
			{
				inventory.AddToInventory(itemInRange);
				Debug.Log($"{itemInRange.name} ��� ��������!");
				Destroy(itemInRange.gameObject);
			}
		}
	}



	void Start()
	{
		CursorManipulation();
		animator = GetComponentInChildren<Animator>();
		controller = GetComponent<CharacterController>();
	}

	void Update()
	{
		MoveHero();
		
	}
	void MoveHero()
	{

	}


	void CursorManipulation()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}
}
