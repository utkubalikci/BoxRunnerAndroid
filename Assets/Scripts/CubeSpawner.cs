using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public float cubeSpawnDistance = 10f;
    public GameObject detector;
    public GameObject cube;
    
    void Start()
    {
        detector.transform.position = new Vector3(0, 0,transform.position.z - cubeSpawnDistance);
        Spawn();
    }


    public void Spawn()
    {
        Instantiate(cube, new Vector3(Random.Range(-4.5f, 4.51f), 0.5f, transform.position.z), Quaternion.identity);
    }


}
