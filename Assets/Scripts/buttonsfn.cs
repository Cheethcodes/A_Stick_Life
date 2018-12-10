/*
 * 
 *  Author:         Gabriel Hansley Chong Suarez
 *  Date Created:   December 2, 2018
 *  Notes:          Some useless script for button actions
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class buttonsfn : MonoBehaviour {

    public GameObject obj;
    Scene scm;

    private string[] getLVL;
    private int numLVL, nextLVL;
    private string nextScene;

    void start()
    {
        // Get level number by splitting the scene name in which the naming convention for the scene names was scenename_#
        scm = SceneManager.GetActiveScene(); // Get current active scene
        getLVL = (scm.name.ToString()).Split('_'); // Split the scene name 
        numLVL = Convert.ToInt32(getLVL[getLVL.Length - 1]); // Gets the last string from the array
    }

    // Closes the information screen
	public void closeinfoScreen()
    {
        obj.SetActive(false);
    }

    // Returns the game to main menu
    // The number 0 is an argument which represents the index of the scene in the build settings
    public void retExxit()
    {
        SceneManager.LoadScene(0);
    }

    // Resets current scene
    public void retLevel()
    {
        int sceneMan = SceneManager.GetActiveScene().buildIndex; // Get current scene build index which can be found in the build settings for reference
        SceneManager.LoadScene(sceneMan, LoadSceneMode.Single); // Load single is used since the player explore the scenes or levels one at a time
    }

    // Load next scene
    public void nxtLevel()
    {
        SceneManager.LoadScene(numLVL + 2);
    }
}
