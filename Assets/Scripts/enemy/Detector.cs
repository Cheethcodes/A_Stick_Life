/*
 * 
 *  Author:         Gabriel Hansley Chong Suarez
 *  Date Created:   November 30, 2018
 *  Notes:          Detection of player by the enemy
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour {

    public static bool playerfound = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerfound = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerfound = false;
        }
    }
}
