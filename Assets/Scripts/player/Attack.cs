/*
 * 
 *  Author:         Gabriel Hansley Chong Suarez
 *  Date Created:   December 1, 2018
 *  Notes:          Player attack actions
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{[SerializeField]
    //Attach this script to the object with the collider for attack
    
    private void OnTriggerEnter2D(Collider2D collision)
    {   //Here is what to do when the attack hits an enemy

        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.SetActive(false);

        }
    }
}
