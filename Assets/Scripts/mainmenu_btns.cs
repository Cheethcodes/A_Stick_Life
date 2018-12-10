/*
 * 
 *  Author:         Gabriel Hansley Chong Suarez
 *  Date Created:   November 29, 2018
 *  Notes:          Some useless script for opening and closing UI
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainmenu_btns : MonoBehaviour {

    public GameObject optionsMenu, helpMenu;

    public Button btn_optionMenu, btn_helpMenu;

	void Start () {
        // Initialize the following UI to the center of the canvas
        optionsMenu.GetComponent<Transform>().localPosition = new Vector3(1.5f, -7, 0);
        helpMenu.GetComponent<Transform>().localPosition = new Vector3(1.5f, -7, 0);

        // Set the UI defined above to false which means they are hidden at the start of the game
        optionsMenu.SetActive(false);
        helpMenu.SetActive(false);
	}
	
	// Show options menu
	public void showOptions()
    {
        optionsMenu.SetActive(true);
    }

    // Show help menu
    public void showHelp()
    {
        helpMenu.SetActive(true);
    }

    // Close options menu
    public void closeOptions()
    {
        optionsMenu.SetActive(false);
    }

    // Close help menu
    public void closeHelp()
    {
        helpMenu.SetActive(false);
    }

    // Starts the game by loading a scene with build index 1 from build settings
    public void startGame()
    {
        SceneManager.LoadScene(1);
    }
}
