using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeedForward = 10f;
    public float playerSpeedHorizontal = 2f;
    public GameObject[] environments;

    void Update()
    {
        //HorizontalMove();
        HorizontalMoveAndroid();
        EnvironmentsMove();
    }


    void EnvironmentsMove()
    {
        foreach (var env in environments)
        {
            env.transform.Translate(new Vector3(0, 0, playerSpeedForward * Time.deltaTime * -1));
            if (env.transform.position.z < -200)
            {
                env.transform.position = new Vector3(0, 0, 400);
            }
        }
    }
    /*
    void HorizontalMove()
    {
        float x = transform.position.x;
        x += playerSpeedHorizontal * Input.GetAxis("Horizontal") * Time.deltaTime;
        if (Mathf.Abs(x) < 4.5f)
        {
            transform.position = new Vector3(x, transform.position.y, transform.position.z);
        }
    }
    */
    void HorizontalMoveAndroid()
    {
        if (Input.touchCount > 0)
        {
            Touch finger = Input.GetTouch(0);

            if (finger.phase == TouchPhase.Stationary)
            {
                if (finger.position.x < 270)
                {
                    Move(-1);
                }
                else if (finger.position.x > 910)
                {
                    Move(1);
                }
            }
        }
    }

    void Move(int direction) // 1 for right - -1 for left
    {
        float x = transform.position.x;
        x += playerSpeedHorizontal * Time.deltaTime * direction;
        if (Mathf.Abs(x) < 4.5f)
        {
            transform.position = new Vector3(x, transform.position.y, transform.position.z);
        }
    }
}
