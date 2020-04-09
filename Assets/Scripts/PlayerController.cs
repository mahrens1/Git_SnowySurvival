using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    public float speed;
    private bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        bool wasHitNorth = Physics.Raycast(transform.position, new Vector3(0, 0, -1), 2);
        Color rayColor = (wasHitNorth) ? Color.red : Color.blue; 
        Debug.DrawRay(transform.position, new Vector3(0, 0, -2), rayColor, 1f);

        if (Input.GetKeyDown(KeyCode.S) && isMoving == false)
        {
            playerRB.AddForce(Vector3.forward * speed, ForceMode.Impulse);
            isMoving = true;
        }
        else if(Input.GetKeyDown(KeyCode.A) && isMoving == false)
        {
            playerRB.AddForce(Vector3.right * speed, ForceMode.Impulse);
            isMoving = true;
        }
        else if (Input.GetKeyDown(KeyCode.W) && isMoving == false)
        {
            playerRB.AddForce(Vector3.back * speed, ForceMode.Impulse);
            isMoving = true;
        }
        else if (Input.GetKeyDown(KeyCode.D) && isMoving == false)
        {
            playerRB.AddForce(Vector3.left * speed, ForceMode.Impulse);
            isMoving = true;
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
            isMoving = false;
        }
    }
}
