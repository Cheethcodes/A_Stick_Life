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

        scoreNum = 0;
        coinCollectedNum = 0;
        enemyKilledNum = 0;

        scm = SceneManager.GetActiveScene();
        getLVL = (scm.name.ToString()).Split('_');
        numLVL = Convert.ToInt32(getLVL[getLVL.Length - 1]);

        anim = GetComponent<Animator>();

        listofEnemies = GameObject.FindGameObjectsWithTag("enemy");
    }

    void Update()
    {
        score.text = scoreNum.ToString();
        coinCollected.text = coinCollectedNum.ToString();
        enemyKilled.text = enemyKilledNum.ToString();
    }

    #region Triggers

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("platformMoving"))
            transform.parent = collision.transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("interactable objects"))
            obj.SetActive(true);

        if (collision.gameObject.CompareTag("water"))
        {
            collision.GetComponent<BuoyancyEffector2D>().linearDrag = 5.2f;
            collision.GetComponent<BuoyancyEffector2D>().flowMagnitude = -1.3f;
        }

        if (collision.gameObject.CompareTag("victory"))
        {
            if (numLVL == 1)
            {
                if (coinCollectedNum >= 1)
                {
                    anim.SetBool("isWin", true);
                    playAudio(3);
                    fireworks.SetActive(true);

                    foreach (GameObject i in listofEnemies)
                    {
                        Destroy(i);
                    }

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

            else if (numLVL == 2)
            {
                if (coinCollectedNum >= 25 && enemyKilledNum >= 10)
                {
                    anim.SetBool("isWIn", true);
                    playAudio(3);
                    fireworks.SetActive(true);

                    foreach (GameObject i in listofEnemies)
                    {
                        Destroy(i);
                    }

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

            else if (numLVL == 3)
            {
                anim.SetBool("isWin", true);
                playAudio(3);
                fireworks.SetActive(true);

                foreach (GameObject i in listofEnemies)
                {
                    Destroy(i);
                }

                vicotryMenu.SetActive(true);
            }

            else { }
        }

        if (collision.gameObject.CompareTag("enemy") || collision.gameObject.CompareTag("enemy2") || collision.gameObject.CompareTag("deathzone"))
        {
            anim.SetBool("isDefeat", true);
            anim.SetBool("isDead", true);
            playAudio(1);

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
        if (collision.gameObject.CompareTag("platformMoving"))
            transform.parent = null;
    }

    #endregion Triggers

    #region Collisions

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("points"))
        {
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

    void playAudio(int x)
    {
        audiosrc.clip = audioClips[x];
        audiosrc.Play();
    }
}
