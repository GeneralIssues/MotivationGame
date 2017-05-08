﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour{

    //public GameObject cc;
    public GameObject pm;
    public GameObject puzzle;
    public GameObject MotivationController;

    public int doorHP = 100;
    int bulletDmg = 35;

    // Use this for initialization
    void Start () {
        //cc = GameObject.Find("Main Camera");
        //pm = GameObject.FindGameObjectWithTag("PrefabManager");

        MotivationController = GameObject.FindWithTag("MotivationController");

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
            if (puzzle != null) {
                GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>().PuzzleActive = true;
                //GameObject puzzle = Instantiate(pm.GetComponent<PrefabManager>().Puzzle1) as GameObject;
                GameObject tempPuzzle = Instantiate(puzzle) as GameObject;
                tempPuzzle.transform.parent = this.transform;
                //Time.timeScale = 0;
            }
            else
                NoPuzzleAttachedOpen();
        }

        if (coll.gameObject.tag == "Bullet") {
            doorHP -= bulletDmg;
            if (doorHP <= 0) {
                this.GetComponent<BoxCollider2D>().isTrigger = true;
                this.GetComponent<Animator>().enabled = true;
                MotivationController.GetComponent<MotivationController>().IncreaseActionScore(5); //Scorer
            }
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player") {
            Destroy(GameObject.FindGameObjectWithTag("Puzzle"));
        }
    }

    void NoPuzzleAttachedOpen()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>().PuzzleActive = false;
        this.GetComponent<BoxCollider2D>().isTrigger = true;
        this.GetComponent<Animator>().enabled = true;
        Time.timeScale = 1;
    }
}
