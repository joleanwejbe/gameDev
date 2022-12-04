using System.Collection;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
	public CharacterController controller;
	public Transform cam;
	public float speed = 6.0f;

	public float turnSmoothTime = 0.1f;
	float turnSmoothTime = 0.1f;
	float turnSmoothVelocity;

	void Update()
	{
		float horizontal = Input.GetAxisRaw("Horizontal");
		float vertical = Input.GetAxisRaw("Vertical");
		Vector3 direction = new Vector3(horizontal, 0f, vertical)normalized;

		if(direction.magnitude >= 0.1f)
		{
			float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
			float angle = Mathf.SmoothDampAngle(Transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
			transform.rotation = Quaternion.Euler(0.0f, targetAngle, 0.0f);

			Vector3 MoveDir = Quanternion.Euler(of,targetAngle, 0f) * Vector3 forward;
			controller.move(moveDir.normalized * speed * Time.deltaTime);
		}
	}
}

