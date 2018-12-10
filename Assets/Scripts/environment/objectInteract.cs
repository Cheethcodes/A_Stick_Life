/*
 * 
 *  Author:         Gabriel Hansley Chong Suarez
 *  Date Created:   December 1, 2018
 *  Notes:          Objects that contain the mechanics and instructions per level
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class objectInteract : MonoBehaviour {

    public Text obj;
    Scene scm;

    private string[] getLVL;
    private int numLVL;

    private string text;

    private void Start()
    {
        // Get level number by splitting the scene name in which the naming convention for the scene names was scenename_#
        scm = SceneManager.GetActiveScene(); // Get current active scene
        getLVL = (scm.name.ToString()).Split('_'); // Split the scene name 
        numLVL = Convert.ToInt32(getLVL[getLVL.Length - 1]); // Gets the last string from the array

        // Calls fillText method to know which description nad mechanics to show in the information text during the level through its argument value
        fillText(numLVL);
    }

    void fillText(int x)
    {

        // Instructions and mechanics per level are defined below
        if (x == 1)
        {
            obj.text = "Pressing  J  will  trigger  your  attack.  Some  mobs  spawned  during  the  game  play  may  take  more  than  1  attack  to  kill  and  some  may  not  be  killable  by  any  means." + 
                "\n" +
                "Please  also  beware  of  some  enemies  disguised  as  platforms  or  decorations  during  the  game  play." +
                "\n\n" +
                "MECHANICS:  To  get  to  the  next  level,  you  must  collect  at  least  40  coins.";
        }
        else if (x == 2)
        {
            obj.text = "There are points at this level wherein you will be pass by bouncing platforms on which you must jump on to move through the level. You will know where a bouncing platform is located as you progres through the level." +
                "\n\n" +
                "MECHANICS: To get to the next level, you must collect at least 20 coinds and defeat 10 enemies.";
        }
        else if (x == 3)
        {
            obj.text = "The concepts of level 1 and 2 are also applied in this level." +
                "\n\n" +
                "MECHANICS: To finish the current level, you must reach the star prize under 5 minutes." +
                "\n" +
                "When time runs out, it will still allow the game play to continue to let you familiarize the map, but will result in a game over."+
                "\n" + 
                "There is no required number of coins that should be collected nor is any number of mobs required to be killed as long as you reach the star prize under 5 minutes.";
        }
        else
        {
            // Default text
            obj.text = "Error! Level not found.";
        }
    }

}
