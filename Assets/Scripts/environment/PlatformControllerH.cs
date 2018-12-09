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
        moveR();
    }

    void moveR()
    {
        if (transform.position.x > maxX)
            moveRight = false;
        if (transform.position.x < minX)
            moveRight = true;

        if (moveRight)
            transform.position = new Vector2(transform.position.x + movespeed * Time.deltaTime, transform.position.y);
        else
            transform.position = new Vector2(transform.position.x - movespeed * Time.deltaTime, transform.position.y);
    }

}
