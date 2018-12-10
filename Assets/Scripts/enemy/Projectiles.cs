/*
 * 
 *  Author:         Gabriel Hansley Chong Suarez
 *  Date Created:   December 3, 2018
 *  Notes:          Projectiles motion and interaction
 * 
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Projectiles : MonoBehaviour {

    float nextFire;
    float fireRate;

    GameObject obj;

    public Transform projectileTransform;

    public Rigidbody2D projectileRB;

    float force;

    private void Start()
    {
        fireRate = UnityEngine.Random.Range(1, 10.1f); // This is defined to set the fire rate of an object
        nextFire = Time.time; // A variable that will define when the next projectile object will be thrown or fired

        obj = this.gameObject;
    }

    void Update()
    {
        // Call attack method every frame
        attack();
    }

    void attack()
    {
        // Get current time and checks if it equals the defined time in which the next copy of projectile should be thrown or fired
        if (Time.time > nextFire)
        {
            // Call spawnobjects method to create another copy if condition met
            spawnObject();
            nextFire = Time.time + fireRate;
        }
    }

    void spawnObject()
    {
        // Creates a copy of the object by its RigidBody2D component
        // Other methods for creating a copy of the objects can also be used but for this game, a prefab was used
        Rigidbody2D pj = Instantiate(projectileRB, projectileTransform.position, projectileTransform.rotation);
    }

}
