using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour{

    //public GameObject cc;
    public GameObject pm;
    public GameObject puzzle;

    public bool doorOpen = false;

    // Use this for initialization
    void Start () {
        //cc = GameObject.Find("Main Camera");
        pm = GameObject.FindGameObjectWithTag("PrefabManager");

        if (this.tag == "Finish") {
            this.GetComponent<SpriteRenderer>().color = Color.green;
        }

        //Door is not a trigger at start
        this.GetComponent<BoxCollider2D>().isTrigger = false;

        this.GetComponent<Animator>().enabled = false;
    }

    // Update is called once per frame
    void Update () {
		
        /*
         * if door is touched and click Space, open puzzle
         * If puzzle is solved, play door open animation at and make collider a trigger
         * When trigger is triggered, move camera and player
         * 
         * */
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player") {
            GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>().PuzzleActive = true;
            if (!doorOpen) {
                //GameObject puzzle = Instantiate(pm.GetComponent<PrefabManager>().Puzzle1) as GameObject;
                GameObject tempPuzzle = Instantiate(puzzle) as GameObject;
                tempPuzzle.transform.parent = this.transform;
                Time.timeScale = 0;
                doorOpen = true;
            }
        }

        if (coll.gameObject.tag == "Bullet") {
            print("Bullet hit door");
        }
    }
}
