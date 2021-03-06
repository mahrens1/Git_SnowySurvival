﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] GameObject fallingRockPrefab;

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
        Invoke("SpawnFallingRock", 1.0f);
    }

    private void SpawnFallingRock()
    {
        Instantiate(fallingRockPrefab, new Vector3(12, 0, 225), Quaternion.identity);
    }
}
