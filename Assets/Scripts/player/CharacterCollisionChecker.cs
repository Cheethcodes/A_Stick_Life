/*
 * 
 *  Author:         Gabriel Hansley Chong Suarez
 *  Date Created:   December 1, 2018
 *  Notes:          Player colliders -> triggers and collisions with another game object
 * 
 */

using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterCollisionChecker : MonoBehaviour {

    public GameObject obj, vicotryMenu, retryMenu, prizeVictory;
    public Text score, coinCollected, enemyKilled;
    public GameObject fireworks;

    Scene scm;
    Animator anim;
    GameObject[] listofEnemies;

    public AudioClip[] audioClips;
    AudioSource audiosrc;

    private string[] getLVL;
    private int numLVL;

    private int scoreNum, coinCollectedNum, enemyKilledNum;

    float delayTime = float.PositiveInfinity;

    void Start()
    {
        audiosrc = GetComponent<AudioSource>();

        //Delaytime for death UI Menu
        delayTime = float.PositiveInfinity;

        // Intialize all player statistics to 0
        scoreNum = 0;
        coinCollectedNum = 0;
        enemyKilledNum = 0;

        // Get level number by splitting the scene name in which the naming convention for the scene names was scenename_#
        scm = SceneManager.GetActiveScene(); // Get current active scene
        getLVL = (scm.name.ToString()).Split('_'); // Split the scene name 
        numLVL = Convert.ToInt32(getLVL[getLVL.Length - 1]); // Gets the last string from the array

        // Get player component animator
        anim = GetComponent<Animator>();

        // Get all objects in the game tagged as "enemy"
        listofEnemies = GameObject.FindGameObjectsWithTag("enemy");
    }

    void Update()
    {
        // Keep all displayed statistics updated with corresponding increments and decrements
        score.text = scoreNum.ToString();
        coinCollected.text = coinCollectedNum.ToString();
        enemyKilled.text = enemyKilledNum.ToString();
    }

    #region Triggers

    // Defines trigger set on the player

    private void OnTriggerStay2D(Collider2D collision)
    {
        // Makes the player stay on the platform while it is moving by making it the child of the platform object
        if (collision.gameObject.CompareTag("platformMoving"))
            transform.parent = collision.transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("interactable objects"))
            obj.SetActive(true);

        // Creates a water effect on the object
        // Buoyancy, flow and drag can also be set manually in the unity editor
        if (collision.gameObject.CompareTag("water"))
        {
            collision.GetComponent<BuoyancyEffector2D>().linearDrag = 5.2f;
            collision.GetComponent<BuoyancyEffector2D>().flowMagnitude = -1.3f;
        }

        // The following mechanics are defined per level
        // How to win depends on the following conditions
        if (collision.gameObject.CompareTag("victory"))
        {
            // For level 1
            if (numLVL == 1)
            {
                // Coin collected must be greater than or equal to 30
                if (coinCollectedNum >= 30)
                {
                    // If condition met, set player win state to true
                    anim.SetBool("isWin", true);
                    playAudio(3);
                    fireworks.SetActive(true); // Activates the inactive fireworks particle object

                    // Destroys all ibjects tagged as "enemy"
                    // This is to prevent any enemy objects from coming near to the player and colliding with it resulting in a confused state of win and defeat
                    foreach (GameObject i in listofEnemies)
                    {
                        Destroy(i);
                    }

                    // Victory menu shows up after 1.2 seconds
                    if (float.IsPositiveInfinity(delayTime))
                    {
                        delayTime = Time.time + 1.2f;
                    }
                    if (Time.time > delayTime)
                    {
                        vicotryMenu.SetActive(true);
                    }
                }

                else { }
            }

            // Level 2
            else if (numLVL == 2)
            {
                // Coin collected must be greater than or equal to 25 and enemies killed must be greater than or equal to 10
                if (coinCollectedNum >= 25 && enemyKilledNum >= 10)
                {
                    // If condition met, set player win state to true
                    anim.SetBool("isWIn", true);
                    playAudio(3);
                    fireworks.SetActive(true); // Activates the inactive fireworks particle object

                    // Destroys all ibjects tagged as "enemy"
                    // This is to prevent any enemy objects from coming near to the player and colliding with it resulting in a confused state of win and defeat
                    foreach (GameObject i in listofEnemies)
                    {
                        Destroy(i);
                    }

                    // Victory menu shows up after 1.2 seconds
                    if (float.IsPositiveInfinity(delayTime))
                    {
                        delayTime = Time.time + 1.2f;
                    }if (Time.time > delayTime)
                    {
                        vicotryMenu.SetActive(true);
                    }
                }

                else { }
            }

            // Level 3
            else if (numLVL == 3)
            {
                // Win and defeat conditions are defined in the Timer.cs file

                // If condition met, set player win state to true
                anim.SetBool("isWIn", true);
                playAudio(3);
                fireworks.SetActive(true); // Activates the inactive fireworks particle object

                // Destroys all ibjects tagged as "enemy"
                // This is to prevent any enemy objects from coming near to the player and colliding with it resulting in a confused state of win and defeat
                foreach (GameObject i in listofEnemies)
                {
                    Destroy(i);
                }

                vicotryMenu.SetActive(true);
            }

            else { }
        }

        // If the plauer will collide with an enemy, or any projectiles fired by the enemy or fall to the death zone
        if (collision.gameObject.CompareTag("enemy") || collision.gameObject.CompareTag("enemy2") || collision.gameObject.CompareTag("deathzone"))
        {
            // Set the dead state of the player to true
            anim.SetBool("isDefeat", true);
            anim.SetBool("isDead", true);
            playAudio(1);

            // The defeat menu shows up after 1 second
            if (float.IsPositiveInfinity(delayTime))
            {
                delayTime = Time.time + 1f;
            }

            if (Time.time > delayTime)
            {
                retryMenu.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // The transform of the player is removed and will no longer follow the platfrom after leaving its trigger collider and collision collider
        if (collision.gameObject.CompareTag("platformMoving"))
            transform.parent = null;
    }

    #endregion Triggers

    #region Collisions

    // Defines collision colliders on the players

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("points"))
        {
            // If there will be any coins or prizes collected the player gains 5 points and the number of collected coins is incremented by 1
            Destroy(collision.gameObject);
            scoreNum += 5;
            coinCollectedNum += 1;
            playAudio(0);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }

    #endregion Collisions

    // Intitialize how audio is played
    void playAudio(int x)
    {
        audiosrc.clip = audioClips[x]; // play corresponding audio clip
        audiosrc.Play(); // Audio source attached to the player
    }
}
