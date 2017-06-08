using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomSwitcher : MonoBehaviour
{
    public GameObject CamController;
    public GameObject DoorLink;
    public GameObject CamPos;

    public GameObject MotivationController;

    GameObject parentDoor;
    int doorNum;

    // Use this for initialization
    void Start()
    {
        CamController = GameObject.FindGameObjectWithTag("MainCamera");
        MotivationController = GameObject.FindGameObjectWithTag("MotivationController");

        parentDoor = this.transform.parent.gameObject;

        //The parent object is painted green of this is finish
        if (this.gameObject.tag == "Finish")
            parentDoor.GetComponent<SpriteRenderer>().color = Color.green;

        //The parent object is painted grey of there is no puzzle
        if (parentDoor.GetComponent<DoorController>().puzzle == null
            && this.tag != "ChangeLevel")
            //parentDoor.GetComponent<SpriteRenderer>().color = Color.grey;
            //this.GetComponent<Animator>().enabled = true; //enable to open instead

        //Switcher a trigger at start
        this.GetComponent<BoxCollider2D>().isTrigger = true;

        //Return of this door is open
        if (this.tag == "ChangeLevel") {
            doorNum = int.Parse(parentDoor.name.Substring(6)) - 1;
            print(doorNum);
            print(MotivationController.GetComponent<MotivationController>().hasBeenToLevel[doorNum]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (this.tag != "ChangeLevel") {
            if (DoorLink.GetComponent<Animator>().enabled == true) {
                parentDoor.GetComponent<Animator>().enabled = true;
                parentDoor.GetComponent<BoxCollider2D>().enabled = false;
            }
        }

        if (this.tag != "ChangeLevel") {
            //We draw the door in another value according to damage
            if (this.gameObject.tag != "Finish" && parentDoor.GetComponent<DoorController>().puzzle == null) {
                parentDoor.GetComponent<SpriteRenderer>().color
                    = Color.HSVToRGB(1f, 0f, parentDoor.GetComponent<DoorController>().doorHP / 230f);
            }
            else if (this.gameObject.tag != "Finish" && parentDoor.GetComponent<DoorController>().puzzle != null) {
                parentDoor.GetComponent<SpriteRenderer>().color
                    = Color.HSVToRGB(1f, 0f, parentDoor.GetComponent<DoorController>().doorHP / 100f);
            }
            else if (this.gameObject.tag == "Finish") {
                parentDoor.GetComponent<SpriteRenderer>().color
                    = Color.HSVToRGB(0.3f, 1f, parentDoor.GetComponent<DoorController>().doorHP / 100f);
            }

            //The linked door is the same color
            //The doors won't paint at all if this is activated. Or at least some wont
            //DoorLink.GetComponent<SpriteRenderer>().color = parentDoor.GetComponent<SpriteRenderer>().color;
        }
        
        //We keep the door open in mainhub
        if (this.tag == "ChangeLevel"
            && MotivationController.GetComponent<MotivationController>()
                .hasBeenToLevel[doorNum] == true) {
            parentDoor.GetComponent<Animator>().enabled = true;
            parentDoor.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            if (this.tag != "Finish" && this.tag != "ChangeLevel") {
                GameObject.FindGameObjectWithTag("Player").transform.position =
                    DoorLink.transform.position;
                CamController.GetComponent<CameraController>().transform.position =
                    CamPos.transform.position - new Vector3(0, 0, 20);
            }
            else if (this.tag == "Finish") {
                SceneManager.LoadScene("MainHub");
            }
            else if (this.tag == "ChangeLevel") {
                string doorName = this.transform.parent.name;
                SceneManager.LoadScene(doorName);
            }

            /*
            if (this.name == "1up")
            {
                Cc.GetComponent<CameraController>().MoveCamToRoom("1Cam");
                GameObject.Find("Door2 2").GetComponent<Animator>().enabled = true;
                GameObject.Find("Door2 2").GetComponent<Animator>().speed = 5;
                GameObject.FindGameObjectWithTag("Player").transform.position =
                    GameObject.Find("Spawn").transform.position;
            }
            else if (this.name == "1left")
            {
                Cc.GetComponent<CameraController>().MoveCamToRoom("2Cam");
            }
            else if (this.name == "1right")
            {
                Cc.GetComponent<CameraController>().MoveCamToRoom("3Cam");
            }
            else if (this.name == "1down")
            {
               Cc.GetComponent<CameraController>().MoveCamToRoom("4Cam");
            }
            */
        }
    }
}
