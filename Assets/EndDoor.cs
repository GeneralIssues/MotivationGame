using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDoor : MonoBehaviour {

    public GameObject MotivationController;
    int numRoomsDone;

    // Use this for initialization
    void Start () {
        MotivationController = GameObject.FindGameObjectWithTag("MotivationController");

        this.GetComponent<SpriteRenderer>().color = Color.red;
        this.GetComponent<Animator>().enabled = false;
        this.GetComponent<BoxCollider2D>().enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < 6; i++) {
            if (MotivationController.GetComponent<MotivationController>().hasBeenToLevel[i - 1] == true) {
                numRoomsDone++;
            }
        }
        print(numRoomsDone);
        if (numRoomsDone >= 4) {
            this.GetComponent<SpriteRenderer>().color = Color.green;
            this.GetComponent<Animator>().enabled = true;
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
	}
}
