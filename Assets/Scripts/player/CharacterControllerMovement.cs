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

    void Start() {
        anim = GetComponent<Animator>();
    }

    void Update() {
        Move();
        Jump();
    }

    void FixedUpdate()
    {
        control.Move(moveH * Time.fixedDeltaTime, false, jump);
        jump = false;

        if (anim.GetBool("isDead") != true || anim.GetBool("isWin") != true)
        {
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
            moveSpeed = 0;
            anim.SetBool("isMoving", false);
        }

    }

    #region Movements

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
