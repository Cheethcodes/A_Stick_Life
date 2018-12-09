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
        transform.Translate(new Vector3(1, 0, 0) * 2 * Time.deltaTime);
    }
}
