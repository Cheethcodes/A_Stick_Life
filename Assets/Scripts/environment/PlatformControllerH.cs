/*
 * 
 *  Author:         Gabriel Hansley Chong Suarez
 *  Date Created:   December 1, 2018
 *  Notes:          Make a platform move horizontally
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformControllerH : MonoBehaviour {

    public float movespeed;
    public float maxX, minX;
    bool moveRight = true;

    void Update()
    {
        // The platform is initialized to move to thr right
        moveR();
    }

    void moveR()
    {
        // These are dfeind values that can be initialized in the unity editor
        // Since the platform moves horizontally, the position in the x-axes are taken into account
        // The following checks whether the position of the platform object is current at its min or max
        if (transform.position.x > maxX)
            moveRight = false; // before reaching the max
        if (transform.position.x < minX)
            moveRight = true; // before reaching the min

        if (moveRight)
            transform.position = new Vector2(transform.position.x + movespeed * Time.deltaTime, transform.position.y); // Tells the platform to move to the right until its defined maximum X-axis value
        else
            transform.position = new Vector2(transform.position.x - movespeed * Time.deltaTime, transform.position.y); // Tells the platform to move to the left until its defined maximum X-axis value
    }

}
