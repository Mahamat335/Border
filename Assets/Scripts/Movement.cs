using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public GameObject car;


    // Update is called once per frame
    void FixedUpdate()
    {
        if (car.GetComponent<CarShake>().isDriving)
            foreach (Transform child in transform)
            {
                Move(child);
            }
    }

    private void Move(Transform t)
    {
        if (car.transform.position.x - t.position.x > 60)
        {
            t.position += new Vector3(240f, 0f, 0f);
        }
        t.position += new Vector3(-Time.fixedDeltaTime * movementSpeed, 0f, 0f);
    }

}
