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
        Vector3 targetPos = target.TransformPoint(new Vector3(0, posY, -10));
        Vector3 desurePos = Vector3.SmoothDamp(transform.position, targetPos, ref vel, smoother);
        transform.position = new Vector3(Mathf.Clamp(desurePos.x, minX, maxX), Mathf.Clamp(desurePos.y, minY, maxY), desurePos.z);
    }
}
