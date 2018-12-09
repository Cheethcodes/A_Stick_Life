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
        moveU();
    }

    void moveU()
    {
        if (transform.position.y > maxY)
            moveUp = false;
        if (transform.position.y < minY)
            moveUp = true;

        if (moveUp)
            transform.position = new Vector2(transform.position.x, transform.position.y + movespeed * Time.deltaTime);
        else
            transform.position = new Vector2(transform.position.x, transform.position.y - movespeed * Time.deltaTime);
    }
}
