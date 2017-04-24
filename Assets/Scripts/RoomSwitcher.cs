using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSwitcher : MonoBehaviour
{
    public GameObject Cc;


    // Use this for initialization
    void Start()
    {
        Cc = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
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
        }
    }
}
