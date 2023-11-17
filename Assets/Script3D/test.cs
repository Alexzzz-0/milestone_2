using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

public class test : MonoBehaviour
{
    private void Update()
    {

        transform.position += UnityEngine.Vector3.down * Time.deltaTime * 2f;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Debug.Log("hit");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Debug.Log("hit");
        }
    }
}
