using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour{

    //public GameObject cc;
    public GameObject pm;

    public bool doorOpen = false;

    // Use this for initialization
    void Start () {
        //cc = GameObject.Find("Main Camera");
        pm = GameObject.FindGameObjectWithTag("PrefabManager");

        if (this.tag == "Finish") {
            this.GetComponent<SpriteRenderer>().color = Color.green;
        }

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

    void OnTriggerEnter2D(Collider2D coll){
        if (coll.tag == "Player"){
            GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>().PuzzleActive = true;
            if (!doorOpen){
                GameObject puzzle = Instantiate(pm.GetComponent<PrefabManager>().Puzzle1) as GameObject;
                puzzle.transform.parent = this.transform;
                Time.timeScale = 0;
                doorOpen = true;
                //cc.GetComponent<CameraController>().MoveCamToRoom(GameObject.Find("1Cam"));
            }
            /*
            else if (this.name == "Door2"){


                //cc.GetComponent<CameraController>().MoveCamToRoom(GameObject.Find("2Cam"));
            }else if (this.name == "Door3"){


                //cc.GetComponent<CameraController>().MoveCamToRoom(GameObject.Find("3Cam"));
            }else if (this.name == "Door4"){


                //cc.GetComponent<CameraController>().MoveCamToRoom(GameObject.Find("4Cam"));
            }
            */
        }
    }
}
