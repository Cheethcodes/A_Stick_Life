/*
 * 
 *  Author:         Gabriel Hansley Chong Suarez
 *  Date Created:   November 29, 2018
 *  Notes:          Auto-scrolling background with camera movements
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainmenu_camera : MonoBehaviour
{
    void Update()
    {
        // This creates an infinited update per frame in which the camera moves by itself to its new position on the x-axis.
        // The code below shows how fast the camera should be moving on the x-axis.
        transform.Translate(new Vector3(1, 0, 0) * 2 * Time.deltaTime);
    }
}
