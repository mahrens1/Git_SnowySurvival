using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collector : MonoBehaviour
{
    public bool hasCollectable = false;
    Scene currentScene;
    string sceneName;


    void Start()
    {
        //Getting the current scene
        //Taking the name of the current scene and saving its name
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
    }


    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        //Player grabbing the wood
        if (other.gameObject.CompareTag("Wood"))
        {
            Destroy(other.gameObject);
            hasCollectable = true;
        }



    }

    private void OnCollisionEnter(Collision collision)
    {
        //Scene changers
        if (collision.gameObject.CompareTag("HomeBase") && hasCollectable == true && sceneName == "Tutorial")
        {
            SceneManager.LoadScene("Level2");
        }
        if (collision.gameObject.CompareTag("HomeBase") && hasCollectable == true && sceneName == "Level2")
        {
            SceneManager.LoadScene("Level3");
        }
        if (collision.gameObject.CompareTag("HomeBase") && hasCollectable == true && sceneName == "Level3")
        {
            SceneManager.LoadScene("MainMenu");
        } 
    }
}
