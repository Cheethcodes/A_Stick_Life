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
        moveSpeed = UnityEngine.Random.Range(2.1f, 4);
        //destroyTime = UnityEngine.Random.Range(2.1f, 3);

        projectileRB = GetComponent<Rigidbody2D>();
        ch = GameObject.FindObjectOfType<CharacterController2D>();
        playerPos = ch.transform.position;
        objPos = this.gameObject.transform.position;

        moveDirection  = moveDir(playerPos, objPos);
        projectileRB.velocity = new Vector2(moveDirection.x, moveDirection.y);

        Destroy(gameObject, /*destroyTime*/ 1.8f);
    }

    private void Update()
    {
        
    }

    private Vector2 moveDir(Vector2 playerPos, Vector2 objPos)
    {
        Vector2 moveDirection = (playerPos - objPos).normalized * moveSpeed;

        return moveDirection;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("platform") || collision.gameObject.CompareTag("platformMoving"))
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("platform") || collision.gameObject.CompareTag("platformMoving"))
            Destroy(gameObject);
    }
}
