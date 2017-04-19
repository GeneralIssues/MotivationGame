using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour {

    List<GameObject> walls = new List<GameObject>();

	// Use this for initialization
	void Start () {
        int i = 0;
        string nameObj = "Wall" + i;
        GameObject wallObj = GameObject.Find(nameObj);
        bool stillName = true;

        while (stillName) {
            walls.Add(wallObj);
            i++;
            nameObj = "Wall" + i;
            wallObj = GameObject.Find(nameObj);

            if (wallObj != null)
                stillName = false;
        }

        for (int listPos = 0; listPos < walls.Count; listPos++) {
            string nameTag = walls[listPos].tag;

            switch (nameTag) {
                case "WallTop":
                    walls[listPos].GetComponent<SpriteRenderer>().color = Color.white;
                    break;
                case "WallBottom":
                    walls[listPos].GetComponent<SpriteRenderer>().color = Color.white;
                    break;
                case "WallLeft":
                    walls[listPos].GetComponent<SpriteRenderer>().color = Color.white;
                    break;
                case "WallRight":
                    walls[listPos].GetComponent<SpriteRenderer>().color = Color.white;
                    break;
                case "WallCorner1":
                    walls[listPos].GetComponent<SpriteRenderer>().color = Color.red;
                    break;
                case "WallCorner2":
                    walls[listPos].GetComponent<SpriteRenderer>().color = Color.red;
                    break;
                case "WallCorner3":
                    walls[listPos].GetComponent<SpriteRenderer>().color = Color.red;
                    break;
                case "WallCorner4":
                    walls[listPos].GetComponent<SpriteRenderer>().color = Color.red;
                    break;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
