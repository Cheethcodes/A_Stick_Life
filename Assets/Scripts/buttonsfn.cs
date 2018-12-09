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
        scm = SceneManager.GetActiveScene();
        getLVL = (scm.name.ToString()).Split('_');
        numLVL = Convert.ToInt32(getLVL[getLVL.Length - 1]);
    }

	public void closeinfoScreen()
    {
        obj.SetActive(false);
    }

    public void retExxit()
    {
        SceneManager.LoadScene(0);
    }

    public void retLevel()
    {
        int sceneMan = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneMan, LoadSceneMode.Single);
    }

    public void nxtLevel()
    {
        SceneManager.LoadScene(numLVL + 2);
    }
}
