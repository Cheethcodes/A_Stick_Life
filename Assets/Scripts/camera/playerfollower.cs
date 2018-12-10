/*
 * 
 *  Author:         Gabriel Hansley Chong Suarez
 *  Date Created:   November 30, 2018
 *  Notes:          Make the camera follow the player
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class playerfollower : MonoBehaviour {

    [SerializeField]
    public Transform target;
    public float smoother;
    public float posY;
    private Vector3 vel = Vector3.zero;

    public float minX, maxX, minY, maxY;

    void Update()
    {
        Vector3 targetPos = target.TransformPoint(new Vector3(0, posY, -10)); // This defines the position of the player
        Vector3 desurePos = Vector3.SmoothDamp(transform.position, targetPos, ref vel, smoother); // This defines the movement of the camera to its next position

        // The camera's movement can be limited within a specified screen position by using the Clamp() function.
        // If camera transform equals to the arguments passed to the variables defined as maximum and what is defined as the minimum
        // the camera will no longer move further any vector position greater than the maximum and any vector position less than the minimum.
        // Note that this is just a 2D game and the Z-axis is ppositioned as default (how the camera was placed.
        transform.position = new Vector3(Mathf.Clamp(desurePos.x, minX, maxX), Mathf.Clamp(desurePos.y, minY, maxY), desurePos.z); 
    }
}
