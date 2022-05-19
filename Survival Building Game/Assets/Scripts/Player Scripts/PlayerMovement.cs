using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController character_Controller;

    private Vector3 move_Direction;

    public float speed = 5f;
    public float gravity = 10f;

    public float jump_Force = 10f;
    private float vertical_Velocity;

    public Camera fpsCam;
    public float range;

    private void Awake()
    {
        character_Controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        MoveThePlayer();
        Door();
    }

    void MoveThePlayer()
    {
        move_Direction = new Vector3(Input.GetAxis(Axis.HORIZONTAL), 0f, Input.GetAxis(Axis.VERTICAL));

        move_Direction = transform.TransformDirection(move_Direction).normalized;
        move_Direction *= speed * Time.deltaTime;

        ApplyGravity();

        character_Controller.Move(move_Direction);
    }

    void ApplyGravity()
    {
        if (character_Controller.isGrounded)
        {
            vertical_Velocity -= gravity * Time.deltaTime;

            PlayerJump();
        } else
        {
            vertical_Velocity -= gravity * Time.deltaTime;
        }

        move_Direction.y = vertical_Velocity * Time.deltaTime;
    }

    void PlayerJump()
    {
        if(character_Controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            vertical_Velocity = jump_Force;
        }
    }

    public void Door()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            DoorScript enemy = hit.transform.GetComponent<DoorScript>();
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (enemy != null)
                {
                    if (enemy.isOpened == false)
                    {
                        enemy.isOpened = true;
                    } 
                    else if(enemy.isOpened == true)
                    {
                        enemy.isOpened = false;
                    }
                }
            }
        }
    }
}
