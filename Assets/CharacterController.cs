using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    float characterSpeed = 0.03f; //value to divide speed
    int coinsAmount; //how many coins collected

    bool isHiding = false; //is our player hiding?
    Vector2 currentHidingVector; //at what position is they hiding
    GameObject currentHidingObject; //which object are they hiding in
    GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        MovementDir();
    }

    void MovementDir() //not using horizontal and vertical because arrow keys are reserved for shooting
    {
        // If we're hiding and decide to move, we have to move from object
        if (isHiding && Input.GetKey(KeyCode.F))
        {
            this.transform.position = currentHidingVector;
            currentHidingObject.GetComponent<SpriteRenderer>().color = Color.white;
            isHiding = false;
        }
        // Else, we move normally
        else
        {
            //Move up
            if (Input.GetKey(KeyCode.W))
            {
                this.transform.Translate(new Vector3(0, 1) * characterSpeed);
            }

            //Move left
            if (Input.GetKey(KeyCode.A))
            {
                this.GetComponent<Animator>().Play("WalkingSide");

                this.GetComponent<SpriteRenderer>().flipX = false;
                this.transform.Translate(new Vector3(-1, 0) * characterSpeed);
            }

            //Move down
            if (Input.GetKey(KeyCode.S))
            {
                this.transform.Translate(new Vector3(0, -1) * characterSpeed);
            }

            //Move right
            if (Input.GetKey(KeyCode.D))
            {
                this.GetComponent<Animator>().Play("WalkingSide");

                this.GetComponent<SpriteRenderer>().flipX = true;
                this.transform.Translate(new Vector3(1, 0) * characterSpeed);
            }

            this.GetComponent<Animator>().StopPlayback();
        }
    }

    /// <summary>
    /// Checking the object that we collide with so we know what to do
    /// </summary>
    /// <param name="coll"></param>
    void OnCollisionEnter2D (Collision2D coll)
    {
        //Coins are destroyed and score added
        if (coll.gameObject.tag == "Coin")
        {
            Destroy(coll.gameObject);
            coinsAmount = coinsAmount + 1;
            print(coinsAmount);
        }

        //Dead if touched by enemy
        if (coll.gameObject.tag == "Enemy")
        {
            print("You're Dead");
        }
    }

    /// <summary>
    /// Interacable objects that we stand near
    /// </summary>
    /// <param name="coll"></param>
    void OnTriggerStay2D (Collider2D coll)
    {
        if (coll.gameObject.tag == "HidingSpot")
        {
            print("Enter Spot");

            if (Input.GetKey(KeyCode.Space))
            {
                currentHidingVector = coll.gameObject.transform.position;
                isHiding = true;

                currentHidingObject = coll.gameObject;
                coll.GetComponent<SpriteRenderer>().color = Color.green;

                this.transform.Translate(100, 100, 0);
            }
        }
    }
}
