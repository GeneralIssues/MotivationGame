﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour{

    public GameObject cc;

	// Use this for initialization
	void Start () {
		//cc = GameObject.Find("Main Camera");
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
            if (this.name == "Door1"){
                Instantiate(PrefabManager)

                //cc.GetComponent<CameraController>().MoveCamToRoom(GameObject.Find("1Cam"));
            }else if (this.name == "Door2"){


                //cc.GetComponent<CameraController>().MoveCamToRoom(GameObject.Find("2Cam"));
            }else if (this.name == "Door3"){


                //cc.GetComponent<CameraController>().MoveCamToRoom(GameObject.Find("3Cam"));
            }else if (this.name == "Door4"){


                //cc.GetComponent<CameraController>().MoveCamToRoom(GameObject.Find("4Cam"));
            }
        }
    }
}
