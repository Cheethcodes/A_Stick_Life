/*
 * 
 *  Author:         Gabriel Hansley Chong Suarez
 *  Date Created:   November 30, 2018
 *  Notes:          Modified enemy patrol and seek
 *  Credits:        Cennedy Jerome Anchores - creator of original script
 * 
 */

using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public Transform player;
    public float speed = 0f;
    public Detector dscript;
    private bool movingRight = true;
    public Transform groundDetection;

    private Animator anim, animPlayer;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        animPlayer = player.gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (!Detector.playerfound)
        {
            moveLeft();

            RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f, 1 <<LayerMask.NameToLayer("platform"));

            if (groundInfo.collider == false)
            {
                if (speed > 0) {
                    if (movingRight == true)
                    {
                        transform.eulerAngles = new Vector3(0, -180, 0);
                        movingRight = false;
                    }
                    else
                    {
                        transform.eulerAngles = new Vector3(0, 0, 0);
                        movingRight = true;
                    }
                }
            }
        }
        else if (Detector.playerfound && animPlayer.GetBool("isDead") == false && animPlayer.GetBool("isDefeat") == false)
        {

            RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f, 1 << LayerMask.NameToLayer("platform"));

            //rotate to look at the player
            //transform.LookAt(new Vector3(player.position.x, 0, 0 ));
            //transform.Rotate(new Vector3(0, -90, 0), Space.Self); //correcting the original rotation
            
            //move towards the player
            if (Vector3.Distance(transform.position, player.position) > 500f)
            {
                //move if distance from target is greater than 1
                if (groundInfo.collider == false)
                {
                    moveLeft();
                }
                else
                {
                    if (transform.position.x > player.position.x)
                    {
                        transform.eulerAngles = new Vector3(0, -180, 0);
                    }
                    else if (transform.position.x < player.position.x)
                    {
                        transform.eulerAngles = new Vector3(0, 0, 0);
                    }

                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
                    transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.position.x, transform.position.y), speed * Time.deltaTime);
                }
            }
        }

        if (speed > 0 && !Detector.playerfound)
        {
            anim.SetBool("isWalking", true);
            anim.SetBool("isWalkingPlayerDetected", false);
        }
        else if (speed > 0 && Detector.playerfound)
        {
            anim.SetBool("isWalkingPlayerDetected", true);
            //anim.SetBool("isStandingPlayerDetected", false);
            anim.SetBool("isWalking", false);
        }
        else if (speed == 0 && Detector.playerfound)
        {
            anim.SetBool("isWalkingPlayerDetected", false);
            //anim.SetBool("isStandingPlayerDetected", true);
        }
        else { }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "platform") {
            speed = 6;
        }

        if (collision.gameObject.tag == "enemy") {
            if (transform.eulerAngles.y == -180)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else if (transform.eulerAngles.y == 0)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
            }
            else { }
        }

        if (collision.gameObject.CompareTag("Player"))
            addTags(collision.gameObject.transform, "enemy");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "platform")
        {
            speed = 0;
        }
    }

    void moveRight()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void moveLeft()
    {
        transform.Translate(Vector2.right * (-1 *speed) * Time.deltaTime);
    }

    void addTags(Transform tr, string tagName)
    {
        tr.gameObject.tag = tagName;
        if (tr.childCount > 0)
        {
            foreach(Transform t in tr)
            {
                addTags(t, tagName);
            }
        }
    }
}