using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplayCautionText : MonoBehaviour
{

    [SerializeField] GameObject cautionCanvas;
    private float waitTime = 10f;
    Scene currentScene;
    string currentSceneName;
    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        currentSceneName = currentScene.name;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentSceneName == "Level2")
        {
            Invoke("DisableCanvas", waitTime);
        }
    }

    void DisableCanvas()
    {
        cautionCanvas.SetActive(false);
    }
}
