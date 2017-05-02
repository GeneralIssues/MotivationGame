using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    float characterSpeed = 0.03f; //value to divide speed
    int coinsAmount; //how many coins collected
    int bulletSpeed;

    public bool PuzzleActive;

    //Hiding variables
    bool isHiding = false; //is our player hiding?
    Vector2 currentHidingVector; //at what position is they hiding
    GameObject currentHidingObject; //which object are they hiding in

    //The player itself
    GameObject player;

    //The MotivationController
    public GameObject mc;

    //Variables related to shooting
    public Rigidbody2D bullet;
    float timeToFire = 0;
    float fireRate = 4;

    //Points for spawning bullets
    Transform firePointLeft;
    Transform firePointRight;
    Transform firePointDown;
    Transform firePointUp;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
        firePointLeft = transform.FindChild("FirePointLeft");
        firePointRight = transform.FindChild("FirePointRight");
        firePointDown = transform.FindChild("FirePointDown");
        firePointUp = transform.FindChild("FirePointUp");
        mc = GameObject.FindGameObjectWithTag("MotivationController");
    }
	
	// Update is called once per frame
	void Update () {
        //if (!PuzzleActive)
            MovementDir();
        if (fireRate == 0 && !PuzzleActive)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Shoot(Vector3.left,firePointLeft);
            }else if (Input.GetKey(KeyCode.RightArrow))
            {
                Shoot(Vector3.right,firePointRight);
                //bullet.GetComponent<SpriteRenderer>().flipX = true;
            }else if (Input.GetKey(KeyCode.DownArrow))
            {
                Shoot(Vector3.down, firePointDown);
            }else if (Input.GetKey(KeyCode.UpArrow))
            {
                Shoot(Vector3.up, firePointUp);
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && Time.time > timeToFire)
        {
            timeToFire = Time.time + 1 / fireRate;
            Shoot(Vector3.left, firePointLeft);
        }else if (Input.GetKey(KeyCode.RightArrow) && Time.time > timeToFire)
        {
            timeToFire = Time.time + 1 / fireRate;
            Shoot(Vector3.right,firePointRight);
        }else if (Input.GetKey(KeyCode.DownArrow) && Time.time > timeToFire)
        {
            timeToFire = Time.time + 1 / fireRate;
            Shoot(Vector3.down, firePointDown);
        }else if (Input.GetKey(KeyCode.UpArrow) && Time.time > timeToFire)
        {
            timeToFire = Time.time + 1 / fireRate;
            Shoot(Vector3.up, firePointUp);
        }
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
        //Dead if touched by enemy
        if (coll.gameObject.tag == "Enemy")
        {
            print("You're Dead");
        }
    }

    /// <summary>
    /// Checks collision with 2D trigger colliders
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter2D(Collider2D other)
    {
        //Coins are destroyed and score added
        if (other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
            coinsAmount += 1;
            mc.GetComponent<MotivationController>().IncreaseAchievementScore(2);
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

    /// <summary>
    /// Shooting a bullet in the direction specified
    /// </summary>
    void Shoot(Vector3 dir, Transform fp)
    {
        Rigidbody2D shot;
        shot = Instantiate(bullet, fp.transform.position, Quaternion.Euler(new Vector3(0, 0, 1))) as Rigidbody2D;
        shot.velocity = transform.TransformDirection(dir * 10);
        if (fp == firePointRight){
            shot.transform.eulerAngles = new Vector3(0, 0, 180);
        }else if (fp == firePointDown){
            shot.transform.eulerAngles = new Vector3(0, 0, 90);
        }else if (fp == firePointUp){
            shot.transform.eulerAngles = new Vector3(0, 0, -90);
        }

    }
}
