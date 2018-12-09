/*
 * 
 *  Author:         Gabriel Hansley Chong Suarez
 *  Date Created:   November 30, 2018
 *  Notes:          Set notification to enemy when a player is detected
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bounds : MonoBehaviour {

    [SerializeField]
    //public Collider2D targetCollision;
    public GameObject player;

    Animator animPlayer;

    void Start()
    {
        animPlayer = player.GetComponent<Animator>();
    }

    //this is attached to everything that can kill the player
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Destroy(collision.gameObject);
            animPlayer.SetBool("isDefeat", true);
            animPlayer.SetBool("isDead", true);
        }
    }
}
