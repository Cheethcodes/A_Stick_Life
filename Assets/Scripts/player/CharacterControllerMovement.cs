/*
 * 
 *  Author:         Gabriel Hansley Chong Suarez
 *  Date Created:   November 29, 2018
 *  Notes:          Player movements and other actions
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerMovement : MonoBehaviour {

    public CharacterController2D control;

    float moveH = 0f, moveSpeed;

    bool jump = false;

    Animator anim;

    void Start()
    {
        // Gets the animator component of the player
        // which will be used to check if the player meets victory or defeat (which includes checking if the player is killed)
        // also defines the movement animations of the player
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Calls move method --> makes the player move or not move
        Move();

        // Calls jump method --> makes the player jump or not jump
        Jump();
    }

    void FixedUpdate()
    {
        // Defines what jump is
        // The jump moves only upwards meaning that there should be a change in y-axis
        control.Move(moveH * Time.fixedDeltaTime, false, jump);
        jump = false;

        // Checks whether the player is in a defeat / killed state or in a win state
        if (anim.GetBool("isDead") != true || anim.GetBool("isWin") != true)
        {
            // movement speed change in x-axis is set to 20.00
            moveSpeed = 20f;

            if (moveH != 0 && jump == false)
            {
                anim.SetBool("isMoving", true);
            }
            else if (moveH != 0 && jump == true)
            {
                anim.SetBool("isMoving", false);
            }
            else if (moveH == 0 && (jump == false || jump == true))
            {
                anim.SetBool("isMoving", false);
            }
        }
        if (anim.GetBool("isDead") == true || anim.GetBool("isWin") == true)
        {
            // if player is in a defeat / killed or win state set the movement speed to 0 and moving animations to false to prevent any unnecessary movements
            moveSpeed = 0;
            anim.SetBool("isMoving", false);
            jump = false;
        }

    }

    #region Movements

    // Defines how player should move
    // This includes where the player is facing

    void Move()
    {
        moveH = Input.GetAxisRaw("Horizontal") * moveSpeed;
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
            jump = true;
        else if (Input.GetButtonUp("Jump"))
            jump = false;
    }

    #endregion Movements
}
