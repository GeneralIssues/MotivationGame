using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDoor : MonoBehaviour {

    public GameObject MotivationController;
    public GameObject endDoor;

    public int numRoomsDone;

    bool[] hasBeenToLevel = { false, false, false, false, false, false };

    // Use this for initialization
    void Start () {
        MotivationController = GameObject.FindGameObjectWithTag("MotivationController");

        endDoor.GetComponent<SpriteRenderer>().color = Color.red;
        endDoor.GetComponent<Animator>().enabled = false;
        endDoor.GetComponent<BoxCollider2D>().enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public void CheckEndDoor ()
    {
        hasBeenToLevel[0] = MotivationController.GetComponent<MotivationController>().hasBeenToLevel[0];
        hasBeenToLevel[1] = MotivationController.GetComponent<MotivationController>().hasBeenToLevel[1];
        hasBeenToLevel[2] = MotivationController.GetComponent<MotivationController>().hasBeenToLevel[2];
        hasBeenToLevel[3] = MotivationController.GetComponent<MotivationController>().hasBeenToLevel[3];
        hasBeenToLevel[4] = MotivationController.GetComponent<MotivationController>().hasBeenToLevel[4];
        hasBeenToLevel[5] = MotivationController.GetComponent<MotivationController>().hasBeenToLevel[5];

        for (int i = 0; i < hasBeenToLevel.Length; i++) {
            if (hasBeenToLevel[i])
                numRoomsDone++;
        }

        if (numRoomsDone >= 4) {
            endDoor.GetComponent<SpriteRenderer>().color = Color.green;
            endDoor.GetComponent<Animator>().enabled = true;
            endDoor.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    void OnTriggerEnter2D (Collider2D coll)
    {
        if (coll.tag == "Player") {
            MotivationController.GetComponent<MotivationController>().SaveStats();
        }
    }
}
