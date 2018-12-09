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
        fireRate = UnityEngine.Random.Range(1, 10.1f);
        nextFire = Time.time;

        obj = this.gameObject;
    }

    void Update()
    {
        attack();
    }

    void attack()
    {
        if (Time.time > nextFire)
        {
            spawnObject();
            nextFire = Time.time + fireRate;
        }
    }

    void spawnObject()
    {
        Rigidbody2D pj = Instantiate(projectileRB, projectileTransform.position, projectileTransform.rotation);
    }

}
