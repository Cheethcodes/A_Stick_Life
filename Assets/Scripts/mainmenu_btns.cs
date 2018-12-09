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
        optionsMenu.GetComponent<Transform>().localPosition = new Vector3(1.5f, -7, 0);
        helpMenu.GetComponent<Transform>().localPosition = new Vector3(1.5f, -7, 0);
        optionsMenu.SetActive(false);
        helpMenu.SetActive(false);
	}
	
	
	public void showOptions()
    {
        optionsMenu.SetActive(true);
    }

    public void showHelp()
    {
        helpMenu.SetActive(true);
    }

    public void closeOptions()
    {
        optionsMenu.SetActive(false);
    }

    public void closeHelp()
    {
        helpMenu.SetActive(false);
    }

    public void startGame()
    {
        SceneManager.LoadScene(1);
    }
}
