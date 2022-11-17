using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 5.0f;
	public float jumpForce = 5.0f;
	public bool isOnGround = true;
	private float horizontalInput;
	private float forwardInput;
	private Rigidbody playerRb;


	void Start()
	{
		
		playerRb = GetComponent<Rigidbody>();
	}


	void Update()
	{
		//get player Input
		horizontalInput = Input.GetAxis("Horizontal");
		forwardInput = Input.GetAxis("Vertical");

		//move the player forward
		transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
		transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

		//let the player jump
		if(Input.GetKeyDown(KeyCode.Space) && isOnGround)
		{
			playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
			isOnGround = false;
		}

	}

	private void OnCollisionEnter(Collision collision)
	{

		if(collision.gameObject.CompareTag("Ground"))
		{
			isOnGround = true;
		}
	}
}