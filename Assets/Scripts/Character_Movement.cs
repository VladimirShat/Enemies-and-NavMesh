using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Movement : MonoBehaviour
{
    Vector3 moveDirection;
    float walkSpeed = 6.0f;
    float runSpeed = 18.0f;
    float jumpForce = 7.0f;
    float gravityForce = 20.0f;

    public GameObject weapon;

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();

        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            if (Input.GetButton("Run"))
                moveDirection *= runSpeed;
            else moveDirection *= walkSpeed;

            if (Input.GetButton("Jump"))
                moveDirection.y += jumpForce;
                
        }

        moveDirection.y -= gravityForce * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        if (Input.GetButtonDown("Fire"))
            weapon.transform.Rotate(new Vector3(50,0,0));
        if (Input.GetButtonUp("Fire"))
            weapon.transform.Rotate(new Vector3(-50, 0, 0));
    }
}
