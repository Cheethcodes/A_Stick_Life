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

public class mainmenu_background : MonoBehaviour {

    public Transform background1, background2, cam;

    private bool switchBackground = true;

    private float currentX = 21.57f;

    void Update () {
        
        if (currentX < cam.position.x)
        {
            if (switchBackground)
                background1.localPosition = new Vector3(background1.localPosition.x + (21.57f * 2), 4.47f, 10);
            else
                background2.localPosition = new Vector3(background2.localPosition.x + (21.57f * 2), 4.47f, 10);

            currentX += 21.57f;
            switchBackground = !switchBackground;
        }
        if(currentX > cam.position.x + 21.57f)
        {
            if (switchBackground)
                background2.localPosition = new Vector3(background2.localPosition.x - (21.57f * 2), 4.47f, 10);
            else
                background1.localPosition = new Vector3(background1.localPosition.x - (21.57f * 2), 4.47f, 10);

            currentX -= 21.57f;
            switchBackground = !switchBackground;
        }
    }
}
