/*
 * 
 *  Author:         Gabriel Hansley Chong Suarez
 *  Date Created:   December 1, 2018
 *  Notes:          Make a platform move vertically
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformControllerV : MonoBehaviour {

    public float movespeed;
    public float maxY, minY;
    bool moveUp = true;

    void Update()
    {
        // The platform is initialized to move up
        moveU();
    }

    void moveU()
    {
        // These are dfeind values that can be initialized in the unity editor
        // Since the platform moves vertically, the position in the y-axes are taken into account
        // The following checks whether the position of the platform object is current at its floor or ceiling
        if (transform.position.y > maxY)
            moveUp = false; // Before reaching its ceiling
        if (transform.position.y < minY)
            moveUp = true; // before reaching the floor

        if (moveUp)
            transform.position = new Vector2(transform.position.x, transform.position.y + movespeed * Time.deltaTime); // Tells the platform to move up until its defined maximum Y-axis value
        else
            transform.position = new Vector2(transform.position.x, transform.position.y - movespeed * Time.deltaTime); // Tells the platform to move down until its defined minimum Y-axis value
    }
}
