using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomSwitcher : MonoBehaviour
{
    public GameObject CamController;
    public GameObject DoorLink;
    public GameObject CamPos;

    // Use this for initialization
    void Start()
    {
        CamController = GameObject.FindGameObjectWithTag("MainCamera");

        //The parent object is painted green of this is finish
        if (this.gameObject.tag == "Finish")
            this.transform.parent.gameObject.GetComponent<SpriteRenderer>().color = Color.green;

        //The parent object is painted grey of there is no puzzle
        if (this.transform.parent.gameObject.GetComponent<DoorController>().puzzle == null
            && this.tag != "ChangeLevel")
            this.transform.parent.gameObject.GetComponent<SpriteRenderer>().color = Color.grey;
            //this.GetComponent<Animator>().enabled = true; //enable to open instead

        //Switcher a trigger at start
        this.GetComponent<BoxCollider2D>().isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.tag != "ChangeLevel")
            if (DoorLink.GetComponent<Animator>().enabled == true) {
                this.transform.parent.GetComponent<Animator>().enabled = true;
                this.transform.parent.GetComponent<BoxCollider2D>().enabled = false;
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
