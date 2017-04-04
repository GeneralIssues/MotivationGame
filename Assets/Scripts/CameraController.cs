using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour{
    private Vector2 velocity = Vector2.zero;


    // Use this for initialization
    void Start (){
	    transform.position = new Vector3(GameObject.Find("SpawnCam").transform.position.x, GameObject.Find("SpawnCam").transform.position.y,-10);
	}
	
	// Update is called once per frame
	void Update (){
	}

   public void MoveCamToRoom(GameObject place){
        transform.position = new Vector3(GameObject.Find(place.name).transform.position.x, GameObject.Find(place.name).transform.position.y, -10);
    }
}
