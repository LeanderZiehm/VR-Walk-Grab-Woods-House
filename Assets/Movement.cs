using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[SelectionBase]
// [RequireComponent(typeof(CharacterController))]
 [RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    
      [SerializeField] private Transform playerCamera;
    [SerializeField] private float moveSpeed = 1.0f;
   // [SerializeField] private float rotateSpeed = 1.0f;

  //  private CharacterController controller;
    
    private Rigidbody rb;

  //  public float snapAngle = 45f;
    
private void Awake()
{
    rb = GetComponent<Rigidbody>();
   // controller = GetComponent<CharacterController>();
}

private void FixedUpdate()
{
    // Get the input axes from the VR controller
    float horizontalAxis = Input.GetAxis("Horizontal");
    float verticalAxis = Input.GetAxis("Vertical");

    // Calculate the movement direction based on the player's camera orientation
    Vector3 moveDirection = playerCamera.forward * verticalAxis + playerCamera.right * horizontalAxis;
    moveDirection.y = 0.0f;

    // Move the player using Rigidbody
   // rb.MovePosition(transform.position + moveDirection.normalized * (moveSpeed * Time.fixedDeltaTime));
   
   
   var moveVelocity = moveDirection.normalized * (moveSpeed * Time.fixedDeltaTime *10);
   if (Input.GetKey(KeyCode.JoystickButton14))
   {
       moveVelocity *= 2;//sprint
   }
   
   moveVelocity.y = rb.velocity.y;
   rb.velocity = moveVelocity;



   //controller.Move(moveDirection);


   // float rotateInput = Input.GetAxis("HorizontalRotate");
   // if (rotateInput != 0)
   // {
   //     Debug.Log(rotateInput);
   //     // Calculate the amount to rotate by, snapping to the nearest snapAngle
   //     float rotateAmount = Mathf.Round(rotateInput / snapAngle) * snapAngle;
   //     transform.Rotate(Vector3.right, rotateAmount);
   // }
}
}
