using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public int speed;
    public int coinsRemain; //Coin Counter 
    public int ammo;
    public int currentScene;
    public GameObject Goal;
    public GameObject bullet;
    public Vector3 startPosition;
    public Transform bulletStartPosition;

    private Rigidbody rb;
    private Quaternion rotate = new Quaternion(0, 0, 0, 0);      //Keeps player straight from collisions and spawning 

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(h, 0, v);

        rb.AddForce(move * speed);

        if(transform.position.y <= -2)
        {
            transform.position = startPosition; 
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 300.0f);
        }

        transform.rotation = rotate;

        if(Input.GetKeyDown(KeyCode.Space) && ammo > 0)
        {
            Instantiate(bullet, bulletStartPosition.position, Quaternion.identity); //Identity keep from rotating
            ammo--;
        }
    }

    void OnTriggerEnter(Collider other) // Called when Is Trigger is selected
    {
        if (other.transform.tag == "Coins")
        {
            other.gameObject.SetActive(false);
            coinsRemain--; //Decreminent Coin Counter.
            if (coinsRemain == 0)
            {
                Goal.gameObject.SetActive(true);
            }
        }
        else if (other.transform.tag == "Goal")
        {
            if(currentScene < 4)
            {
                SceneManager.LoadScene(currentScene + 1); // Go to next Level Once Complete
            }
            
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag == "Enemy")
        {
            transform.position = startPosition; //remopve from scene when enemy hit
        }
    }
 
}
