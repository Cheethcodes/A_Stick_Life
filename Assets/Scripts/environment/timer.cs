using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour {

    public GameObject retryMenu, player;
    Animator anim;
    public Text displayTime;

    float timeBase = 120.00f; // Set time to 2 minuts in seconds

    void Start()
    {
        // Gets the animator component of the player
        anim = player.GetComponent<Animator>();
    }

	void Update ()
    {

        // Checks if the player is already in a win state
        if (anim.GetBool("isWin") == false)
        {

            // If not yet in the win state, the time will continue decreasing real time
            timeBase -= Time.deltaTime;

            // When time reaches 0, defeat state is automatically called
            if (timeBase <= 0)
            {
                timeBase += 0; // Stops the timer
                retryMenu.SetActive(true);
            }
        }
        else
        {
            // If already in the win state, the timer is stopped
            timeBase += 0;
        }

        // Displays the current timer value
        displayTime.text = timeBase.ToString();
	}
}
