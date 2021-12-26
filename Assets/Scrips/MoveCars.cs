using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCars : MonoBehaviour
{
    private float speed = 20f;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
