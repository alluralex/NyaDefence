using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Hero : MonoBehaviour
{
	public float moveSpeed = 3f;
	public float turnSpeed = 150f;
	public Item itemInRange;

	private Animator animator;
	private CharacterController controller;

	private List<Item> inventory = new List<Item>();

	void OnTriggerEnter(Collider other)
	{
		Debug.Log("я зашёл в колайдер с тегом:" + other.tag + " и с именем: " + other.name);
		if (other.CompareTag("Item"))
		{
			itemInRange = other.GetComponent<Item>();
			if (itemInRange != null)
			{

				inventory.Add(itemInRange);
				Debug.Log($"{itemInRange.name} был подобран!");
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
		if (Input.GetKeyDown(KeyCode.R))
		{
			foreach (var bebra in inventory)
			{
				Debug.Log($"Название = {bebra.name}");
			}
		}
	}
	void MoveHero()
	{
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");
		float mouseX = Input.GetAxis("Mouse X");

		Vector3 move = transform.forward * vertical + transform.right * horizontal;

		if (move.magnitude > 1f)
			move.Normalize();

		controller.SimpleMove(move * moveSpeed);

		transform.Rotate(Vector3.up * mouseX * turnSpeed * Time.deltaTime);

		animator.SetFloat("MoveX", horizontal);
		animator.SetFloat("MoveY", vertical);
	}


	void CursorManipulation()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}
}
