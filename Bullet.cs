using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int bulletSpeed = 1;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * bulletSpeed); //Lightweight way of using physics without RigidBody
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag == "Enemy")
        {
            other.gameObject.SetActive(false);
        }   
    }
}
