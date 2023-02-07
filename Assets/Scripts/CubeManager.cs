using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    public PlayerController playerScript;
    public float destroyZ = -10f;
    public Material[] materials;
    public CubeSpawner cubeSpawner;
    void Start()
    {
        Colorize();
        //cubeSpawner.gameObject.transform = GameObject.Find("CubeSpawner").transform;
    }

    void Update()
    {
        transform.Translate(new Vector3(0, 0, playerScript.playerSpeedForward * Time.deltaTime * -1));

        if (transform.position.z < destroyZ)
        {
            Destroy(gameObject);
        }

    }

    void Colorize()
    {
        int colorIndex = Random.Range(0, 5);
        GetComponent<MeshRenderer>().material = materials[colorIndex];
    }
  

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "NewCube")
        {
            cubeSpawner.Spawn();
        }
    }
    public void DestroyScript()
    {
        Destroy(this);
    }

}
