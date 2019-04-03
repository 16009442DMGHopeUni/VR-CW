using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int speed;
    public Transform startPos;
    public Transform endPos;

    private Transform currentPos; // Current position or positions already visited
	
	void Start ()
    {
		if (currentPos == null)
        {
            currentPos = startPos;
        }
	}
	
	
	void Update ()
    {
		if (currentPos == startPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos.position, speed * Time.deltaTime);
        }
        else if (currentPos == endPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos.position, speed * Time.deltaTime);
        }

        if (transform.position.x <= -8.5f && transform.position.x >= -9.5f) //f = float value
        {
            currentPos = startPos;
        }
        else if (transform.position.x >= 8.5f && transform.position.x <= 9.5f)
        {
            currentPos = endPos;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player")
        {
            other.transform.position = other.gameObject.GetComponent<Player>().startPosition; //Gaining Access to player script 
        }
    }
}
