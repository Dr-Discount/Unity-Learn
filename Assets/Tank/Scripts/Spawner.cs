using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;

public class Spawner : MonoBehaviour
{
    [SerializeField] float time = 1.0f;
    [SerializeField] GameObject spawnObject;

    private void Awake()
    {
        
    }

    void Start()
    {
        Instantiate(spawnObject, transform.position, transform.rotation);
    }
    
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            Instantiate(spawnObject, transform.position, transform.rotation);
            time = 1.0f;
        }
    }
}
