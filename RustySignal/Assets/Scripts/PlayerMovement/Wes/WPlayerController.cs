using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WPlayerController : MonoBehaviour
{
    public static WPlayerController instance;

    public float moveSpeed = 11f;
    public float jumpForce = 22.5f;
    public float gravityScale = 5f;
    public float sprintAcceleration = 1.28f;

    //Vector three is three vectors (X,Y,Z)
    private Vector3 moveDirection;

    public CharacterController charController;

    //Storing where the camera is facing
    private Camera theCam;

    public GameObject playerModel;
    public float rotateSpeed;

    //Knocking the player back when they take damage
    public bool isKnocking;
    public float knockBackLength = 0.5f;
    private float knockBackCounter;
    public Vector2 knockBackPower;

    // Start is called before the first frame update
    void Start()
    {
        theCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        if (!isKnocking)
        {

            float yStore = moveDirection.y;
            // moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            moveDirection = (transform.forward * Input.GetAxisRaw("Vertical")) + (transform.right * Input.GetAxisRaw("Horizontal"));
            moveDirection.Normalize();
            moveDirection = moveDirection * moveSpeed;
            moveDirection.y = yStore;

            //checking for jumping input
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }

            moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityScale;

            //transform.position = transform.position + (moveDirection * Time.deltaTime * moveSpeed);

            //moving the player through a character controller instead of a transform function
            charController.Move(moveDirection * Time.deltaTime);

            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                //rotating character model to reflect where the camera is facing
                transform.rotation = Quaternion.Euler(0f, theCam.transform.rotation.eulerAngles.y, 0f);
                Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));

                //player model will rotate with directional input with no interframe division
                // playerModel.transform.rotation = newRotation;

                //Smoother player model rotation with directional input (wasd)
                playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
            }

            if (Input.GetAxisRaw("Vertical") != 0)
            {
                //rotating character model to reflect where the camera is facing
                transform.rotation = Quaternion.Euler(0f, theCam.transform.rotation.eulerAngles.y, 0f);
                Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));

                //player model will rotate with directional input with no interframe division
                // playerModel.transform.rotation = newRotation;

                //Smoother player model rotation with directional input (wasd)
                playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);

            }

            //Sprint
            //If the shift key is held down the movedirection will be increased by the Spring Acceleration
            //This not only affects the running speed but will also affect jump hight (Currently set to sprintAcceleration = 1.28)
            if (Input.GetKey(KeyCode.LeftShift))
            {
                charController.Move(moveDirection * sprintAcceleration * Time.deltaTime);
            }
        }

        if(isKnocking) 
        { 
            knockBackCounter -= Time.deltaTime;

            float yStore = moveDirection.y;
            moveDirection = (playerModel.transform.forward * -knockBackPower.x);
            moveDirection.y = yStore;

            moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityScale;

            charController.Move(moveDirection * Time.deltaTime);

            if (knockBackCounter <= 0)
            {
                isKnocking = false;
            }
        }
    }

    public void Knockback()
    {
        isKnocking = true;
        knockBackCounter = knockBackLength;
        Debug.Log("Knocked Back");
        moveDirection.y = knockBackPower.y;
    }
}
