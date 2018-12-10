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

    // The following colliders added to the enemy as components for detection will detect if it is near a player or not - before and during
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerfound = true;
        }
    }

    // The following colliders added to the enemy as components for detection will detect if it is near a player or not - after
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerfound = false;
        }
    }
}
