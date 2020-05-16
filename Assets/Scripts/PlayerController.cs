using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    public float speed;
    private Animator playerAnim;


    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
    }


    void Update()
    {
        //Creates a raycast in each direction
        bool wasHitNorth = Physics.Raycast(transform.position, new Vector3(0, 0, -1), 2);
        bool wasHitEast = Physics.Raycast(transform.position, new Vector3(-1, 0, 0), 2);
        bool wasHitWest = Physics.Raycast(transform.position, new Vector3(1, 0, 0), 2);
        bool wasHitSouth = Physics.Raycast(transform.position, new Vector3(0, 0, 1), 2);


        //Character controls
        if (Input.GetKeyDown(KeyCode.S) && wasHitSouth == false)
        {
            playerRB.AddForce(Vector3.forward * speed, ForceMode.Impulse);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if(Input.GetKeyDown(KeyCode.A) && wasHitWest == false)
        {
            playerRB.AddForce(Vector3.right * speed, ForceMode.Impulse);
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else if (Input.GetKeyDown(KeyCode.W) && wasHitNorth == false)
        {
            playerRB.AddForce(Vector3.back * speed, ForceMode.Impulse);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (Input.GetKeyDown(KeyCode.D) && wasHitEast == false)
        {
            playerRB.AddForce(Vector3.left * speed, ForceMode.Impulse);
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }


        //Escape button
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    //Slows the player down when hitting a wall
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            playerRB.velocity = Vector3.zero;
        }
    }
}
