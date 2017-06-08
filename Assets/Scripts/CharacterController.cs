using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour {

    float characterSpeed = 0.05f; //value to divide speed - higher is faster
    int coinsAmount; //how many coins collected
    int bulletSpeed;

    public bool PuzzleActive;
    bool dead = false;

    

    //Hiding variables
    bool isHiding = false; //is our player hiding?
    Vector2 currentHidingVector; //at what position is they hiding
    GameObject currentHidingObject; //which object are they hiding in

    //The player itself
    GameObject player;

    //The MotivationController
    public GameObject mc;
    public GameObject pm;

    //Variables related to shooting
    public Rigidbody2D bullet;
    float timeToFire = 0;
    float fireRate = 2; //Higher is faster

    //Points for spawning bullets
    Transform firePointLeft;
    Transform firePointRight;
    Transform firePointDown;
    Transform firePointUp;

    //Gets currently active scene
    Scene scene;
    
    private IEnumerator coroutine;

    void Awake()
    {
        scene = SceneManager.GetActiveScene();
    }

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
        firePointLeft = transform.FindChild("FirePointLeft");
        firePointRight = transform.FindChild("FirePointRight");
        firePointDown = transform.FindChild("FirePointDown");
        firePointUp = transform.FindChild("FirePointUp");
        mc = GameObject.FindGameObjectWithTag("MotivationController");
        pm = GameObject.FindGameObjectWithTag("PrefabManager");
    }

    //For moving away from puzzle
    Transform doorPos;
	
	// Update is called once per frame
	void FixedUpdate () {
        if (!PuzzleActive && !dead)
            MovementDir();

        if (scene.name != "MainHub" && !PuzzleActive && !dead) {
            if (Input.GetKey(KeyCode.LeftArrow) && Time.time > timeToFire) {
                timeToFire = Time.time + 1 / fireRate;
                Shoot(Vector3.left, firePointLeft);
            }
            else if (Input.GetKey(KeyCode.RightArrow) && Time.time > timeToFire) {
                timeToFire = Time.time + 1 / fireRate;
                Shoot(Vector3.right, firePointRight);
            }
            else if (Input.GetKey(KeyCode.DownArrow) && Time.time > timeToFire) {
                timeToFire = Time.time + 1 / fireRate;
                Shoot(Vector3.down, firePointDown);
            }
            else if (Input.GetKey(KeyCode.UpArrow) && Time.time > timeToFire) {
                timeToFire = Time.time + 1 / fireRate;
                Shoot(Vector3.up, firePointUp);
            }
        }
        else { 
            MoveAwayFromPuzzle();
        }
    }

    void MovementDir() //not using horizontal and vertical because arrow keys are reserved for shooting
    {
        //Move left
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.D)) {
            this.GetComponent<Animator>().Play("WalkingSide");

            this.GetComponent<SpriteRenderer>().flipX = false;
            this.transform.Translate(new Vector3(-0.8f, 0.8f) * characterSpeed);
        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S)) {
            this.GetComponent<Animator>().Play("WalkingSide");

            this.GetComponent<SpriteRenderer>().flipX = false;
            this.transform.Translate(new Vector3(-0.8f, -0.8f) * characterSpeed);
        }
        else if (Input.GetKey(KeyCode.A)) {
            this.GetComponent<Animator>().Play("WalkingSide");

            this.GetComponent<SpriteRenderer>().flipX = false;
            this.transform.Translate(new Vector3(-1, 0) * characterSpeed);
        }

        //Move right
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A)) {
            this.GetComponent<Animator>().Play("WalkingSide");

            this.GetComponent<SpriteRenderer>().flipX = true;
            this.transform.Translate(new Vector3(0.8f, 0.8f) * characterSpeed);
        }
        else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S)) {
            this.GetComponent<Animator>().Play("WalkingSide");

            this.GetComponent<SpriteRenderer>().flipX = true;
            this.transform.Translate(new Vector3(0.8f, -0.8f) * characterSpeed);
        }
        else if (Input.GetKey(KeyCode.D)) {
            this.GetComponent<Animator>().Play("WalkingSide");

            this.GetComponent<SpriteRenderer>().flipX = true;
            this.transform.Translate(new Vector3(1, 0) * characterSpeed);
        }
        
        //Move up 
        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) {
            this.GetComponent<Animator>().Play("WalkingUp");

            this.transform.Translate(new Vector3(0, 1) * characterSpeed);
        }

        //Move down
        if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) {
            this.GetComponent<Animator>().Play("WalkingDown");

            this.transform.Translate(new Vector3(0, -1) * characterSpeed);
        }

        this.GetComponent<Animator>().StopPlayback();
    }

    /// <summary>
    /// When we're in a puzzle and move away from it we remove the puzzle
    /// </summary>
    void MoveAwayFromPuzzle()
    {
        //print("Method ran");

        //Move away down
        if (Input.GetKey(KeyCode.W) && this.transform.position.y > doorPos.position.y) {
            this.transform.Translate(new Vector3(-1, 0) * characterSpeed);
            Destroy(GameObject.FindGameObjectWithTag("Puzzle"));
            Time.timeScale = 1;
            PuzzleActive = false;
        }

        //Move away left
        if (Input.GetKey(KeyCode.A) && this.transform.position.x < doorPos.position.x) {
            print("Move away");
            this.transform.Translate(new Vector3(-1, 0) * characterSpeed);
            Destroy(GameObject.FindGameObjectWithTag("Puzzle"));
            Time.timeScale = 1;
            PuzzleActive = false;
        }

        //Move away down
        if (Input.GetKey(KeyCode.S) && this.transform.position.y < doorPos.position.y) {
            this.transform.Translate(new Vector3(-1, 0) * characterSpeed);
            Destroy(GameObject.FindGameObjectWithTag("Puzzle"));
            Time.timeScale = 1;
            PuzzleActive = false;
        }

        //Move away right
        if (Input.GetKey(KeyCode.D) && this.transform.position.x > doorPos.position.x) {
            this.transform.Translate(new Vector3(-1, 0) * characterSpeed);
            Destroy(GameObject.FindGameObjectWithTag("Puzzle"));
            Time.timeScale = 1;
            PuzzleActive = false;
        }
    }


    /// <summary>
    /// Checking the object that we collide with so we know what to do
    /// </summary>
    /// <param name="coll"></param>
    void OnCollisionEnter2D (Collision2D coll)
    {
        //Dead if touched by enemy
        if (coll.gameObject.tag == "Enemy") {
            dead = true;
            //this.GetComponent<BoxCollider2D>().isTrigger = true;
            this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            this.GetComponent<Animator>().Play("Dead");
            mc.GetComponent<MotivationController>().ResetScores();
            StartCoroutine(RestartScene());
        }

        //Door touched
        if (coll.gameObject.tag == "Door" && coll.gameObject.GetComponent<DoorController>().puzzle != null) {
            doorPos = coll.gameObject.transform;
            print(doorPos);
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
            mc.GetComponent<MotivationController>().IncreaseAchievementScore(100/pm.GetComponent<PrefabManager>().coinsMax.Length);
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

    private IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
