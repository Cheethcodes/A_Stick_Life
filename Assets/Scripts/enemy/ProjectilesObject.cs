/*
 * 
 *  Author:         Gabriel Hansley Chong Suarez
 *  Date Created:   December 3, 2018
 *  Notes:          Projectiles motion and interaction
 * 
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ProjectilesObject : MonoBehaviour {
    
    CharacterController2D ch;

    public Rigidbody2D projectileRB;
    Vector2 moveDirection;

    private Vector2 playerPos, objPos;

    private float moveSpeed, destroyTime;

    void Start()
    {
        // Defines the travel speed of the projectile
        moveSpeed = UnityEngine.Random.Range(2.1f, 4);

        // Projectiles and characters will be defined and differentiated by getting:
        // the RigidBody2D component of the projectile object and
        // the CharacterController of the player ---- this is so that we can know where the player currently is (may also be useful when determining a detection distance from object that throws the projectile and the player)
        projectileRB = GetComponent<Rigidbody2D>();
        ch = GameObject.FindObjectOfType<CharacterController2D>();

        // Gets the position of the projectile object and the player
        playerPos = ch.transform.position;
        objPos = this.gameObject.transform.position;

        // The following defines first the two arguments the projectile object must meet
        // Next we define the travel speed of the projectile moving towards the player's current position
        moveDirection  = moveDir(playerPos, objPos);
        projectileRB.velocity = new Vector2(moveDirection.x, moveDirection.y);

        // Destroy the projectile object after 1.8 seconds
        Destroy(gameObject, 1.8f);
    }

    private void Update()
    {
        
    }
    
    // Tells the projectile to target the player
    private Vector2 moveDir(Vector2 playerPos, Vector2 objPos)
    {
        // Defines where the rojectile should move with respect to the current player position
        Vector2 moveDirection = (playerPos - objPos).normalized * moveSpeed;

        return moveDirection;
    }

    // Defines what is platform so if the projectile collides with such objects, it will automatically be destroyed
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("platform") || collision.gameObject.CompareTag("platformMoving"))
            Destroy(gameObject);
    }

    // Defines what is platform so if the projectile is triggered with such objects, it will automatically be destroyed
    // The trigger was made just in case there will be any bugs that will occur in the game since the projectile uses two colliders -> one for collisions and one for triggers
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("platform") || collision.gameObject.CompareTag("platformMoving"))
            Destroy(gameObject);
    }
}
