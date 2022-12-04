using System.Collection;
using System. Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
	public CharacterController controller;
	public Transform cam;
	public float speed = 6f;

	pubblic float turnSmoothTime = 0.1f;
	float turnSmoothTime = 0.1f;
	float turnSmoothVelocity;

	void Update()
	{
		float horizontal = Input.GetAxisRaw("Horizontal");
		float vertical = Input.GetAxisRaw("Vertical");
		Vector 3 direction = new Vector3(horizontal, 0f, vertical)normalized;

		if(direction.magnitude >= 0.1f)
		{
			float targetAngle = Mathf.Atan2(direction.x,direction.y) * Mathf.Rad2Deg + Cam.eulerAngles.y;
			float angle = Mathf.SmoothDampingAngle(Transform.eulerangles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
			tranform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

			Vector3 MoveDir = Quanternion.Euler(of,targetAngle, 0f) * Vector3 forward;
			controller.move(moveDir.normalized * speed * Time.deltaTime);
		}
	}
}

