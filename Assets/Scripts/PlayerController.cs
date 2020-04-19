﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        bool wasHitNorth = Physics.Raycast(transform.position, new Vector3(0, 0, -1), 2);
        bool wasHitEast = Physics.Raycast(transform.position, new Vector3(-1, 0, 0), 2);
        bool wasHitWest = Physics.Raycast(transform.position, new Vector3(1, 0, 0), 2);
        bool wasHitSouth = Physics.Raycast(transform.position, new Vector3(0, 0, 1), 2);

        //Color rayColor = (wasHitNorth) ? Color.red : Color.blue; 
        //Debug.DrawRay(transform.position, new Vector3(0, 0, -2), rayColor, 1f);

        if (Input.GetKeyDown(KeyCode.S) && wasHitSouth == false)
        {
            playerRB.AddForce(Vector3.forward * speed, ForceMode.Impulse);
        }
        else if(Input.GetKeyDown(KeyCode.A) && wasHitWest == false)
        {
            playerRB.AddForce(Vector3.right * speed, ForceMode.Impulse);
        }
        else if (Input.GetKeyDown(KeyCode.W) && wasHitNorth == false)
        {
            playerRB.AddForce(Vector3.back * speed, ForceMode.Impulse);
        }
        else if (Input.GetKeyDown(KeyCode.D) && wasHitEast == false)
        {
            playerRB.AddForce(Vector3.left * speed, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            playerRB.velocity = Vector3.zero;
        }
    }
}
