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
using UnityEngine.UI;

public class mainmenu_background : MonoBehaviour {

    // Define 2 copies of the same background image and each image must be of the same dimension and resolution which should fit the camera 
    public Transform background1, background2, cam;

    private bool switchBackground = true;

    private float currentX = 21.57f; // Defined value for the current position of the camera on the x-axis

    void Update () {
        
        // Checks whether the camera is greater than its vector position in the x-axis
        // This means that it is moving to the right
        if (currentX < cam.position.x)
        {

            // The folllowing code shows the reset of current background image with another image of the same copy
            // If camera moves to the right and passes the first image, then the second image to the right of it will hold the transition
            // This time, the previous image will be displaced to a new vector position in which it will become the second image and the previous one becomes the first or the current image being viewed on the camera
            if (switchBackground)
                background1.localPosition = new Vector3(background1.localPosition.x + (21.57f * 2), 4.47f, 10);
            else
                background2.localPosition = new Vector3(background2.localPosition.x + (21.57f * 2), 4.47f, 10);

            currentX += 21.57f;
            switchBackground = !switchBackground;
        }

        // Checks whether the camera is less than its vector position in the x-axis
        // This means that it is moving to the left
        if (currentX > cam.position.x + 21.57f)
        {
            // The folllowing code shows the reset of current background image with another image of the same copy
            // If camera moves to the right and passes the first image, then the second image to the left of it will hold the transition
            // This time, the previous image will be displaced to a new vector position in which it will become the second image and the previous one becomes the first or the current image being viewed on the camera
            if (switchBackground)
                background2.localPosition = new Vector3(background2.localPosition.x - (21.57f * 2), 4.47f, 10);
            else
                background1.localPosition = new Vector3(background1.localPosition.x - (21.57f * 2), 4.47f, 10);

            currentX -= 21.57f;
            switchBackground = !switchBackground;
        }
    }
}
