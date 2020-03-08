using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collector : MonoBehaviour
{
    public bool hasCollectable = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Wood"))
        {
            Destroy(other.gameObject);
            hasCollectable = true;
        }
        if (other.gameObject.CompareTag("HomeBase") && hasCollectable == true)
        {
            SceneManager.LoadScene("MainMenu");
        }
        
    }
}
