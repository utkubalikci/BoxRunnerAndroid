using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueManager : MonoBehaviour
{
    int heigth = 0;
    public Material[] materials;
    GameObject[] cubes = {null,null,null,null,null};
    public Transform deleteParent;
    public GameObject cube;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        heigth = gameObject.transform.childCount;
        gameManager.UpdateHeightText(heigth);
    }


    private void OnCollisionEnter(Collision collision)
    {
        //print(collision.collider.tag);
        if (collision.collider.CompareTag("Cube"))
        {
            GameObject obj = collision.collider.gameObject;
            obj.transform.parent = gameObject.transform;
            Destroy(obj.GetComponent<CubeManager>());

            heigth++;
            Vector3 tempPosition = transform.position;
            tempPosition.y += 1;
            transform.position = tempPosition;

            obj.transform.localPosition = new Vector3(0, -2 * heigth, 0);
            Destroy(obj.GetComponent<BoxCollider>());
            gameObject.GetComponent<CapsuleCollider>().height += 4;

            QueueControl();
            gameManager.UpdateHeightText(heigth);
        }
    }

    public void SpawnCubeQueue(int number)
    {
        int colorIndex = Random.Range(0, 5);
        int i;
        GameObject temp;
        for (i = 0; i < gameObject.transform.childCount; i++)
        {
            temp = gameObject.transform.GetChild(i).gameObject;
            temp.transform.SetParent(deleteParent);
            Destroy(temp);
        }
        QueueEdit();


        for (i = 0; i < number; i++)
        {
            GameObject obj = Instantiate(cube);
            obj.transform.parent = gameObject.transform;
            obj.GetComponent<MeshRenderer>().material = materials[colorIndex];
            Destroy(obj.GetComponent<CubeManager>());

            Vector3 tempPosition = transform.position;
            tempPosition.y += 1;
            transform.position = tempPosition;

            Destroy(obj.GetComponent<BoxCollider>());
            heigth = gameObject.transform.childCount;
            obj.transform.localPosition = new Vector3(0, -2 * heigth, 0);
            gameObject.GetComponent<CapsuleCollider>().height += 4;

            QueueControl();
            gameManager.UpdateHeightText(heigth);
        }
    }

    void QueueControl()
    {
        int len = gameObject.transform.childCount;
        if (len < 5) return;
        string tempName;
        int i;
        for (i = 0; i < len; i++)
        {
            tempName = gameObject.transform.GetChild(i).GetComponent<MeshRenderer>().material.name;
            switch (tempName)
            {
                case ("cubeBlue (Instance)"):
                    cubes[0] = gameObject.transform.GetChild(i).gameObject;
                    break;

                case ("cubeRed (Instance)"):
                    cubes[1] = gameObject.transform.GetChild(i).gameObject;
                    break;

                case ("cubeGreen (Instance)"):
                    cubes[2] = gameObject.transform.GetChild(i).gameObject;
                    break;

                case ("cubeYellow (Instance)"):
                    cubes[3] = gameObject.transform.GetChild(i).gameObject;
                    break;

                case ("cubePurple (Instance)"):
                    cubes[4] = gameObject.transform.GetChild(i).gameObject;
                    break;
            }
        }
        bool isFull = true;
        for (i = 0; i < 5; i++)
        {
            if (cubes[i] == null)
            {
                isFull = false;
                break;
            }
        }
        if (isFull)
        {
            for (i = 0; i < 5; i++)
            {
                cubes[i].transform.SetParent(deleteParent);
                Destroy(cubes[i]);
                cubes[i] = null;
            }
            QueueEdit();
        }
    }

    void QueueEdit()
    {
        int len = gameObject.transform.childCount;

        //5 cubes are destroyed
        gameObject.GetComponent<CapsuleCollider>().height -= 20;
        //heigth -= 5;
        heigth = gameObject.transform.childCount;
        gameManager.UpdateHeightText(heigth);
        
        int i;
        Vector3 tempPosition;
        for (i = 0; i < len; i++)
        {
            tempPosition = gameObject.transform.GetChild(i).localPosition;
            tempPosition.y = (i+1) * -2 ;
            gameObject.transform.GetChild(i).localPosition = tempPosition;
        }


        //our stacks new position
        tempPosition = transform.position;
        tempPosition.y -= 5;
        transform.position = tempPosition;
    }
}
