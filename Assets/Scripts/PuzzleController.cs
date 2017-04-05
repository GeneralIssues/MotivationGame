using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleController : MonoBehaviour{

    string nameImg;
    public static int puzzleSize = 3;
    public GameObject[,] images = new GameObject[puzzleSize, puzzleSize];
    GameObject[,] currentPos;

	// Use this for initialization
	void Start (){
        //Fill images array with images at the correct location
        for (int i = 0; i < puzzleSize*puzzleSize; i++){
	        nameImg = "Image" + i;
            GameObject tempObj = GameObject.Find(nameImg);
            Debug.Log((int)tempObj.GetComponent<RectTransform>().localPosition.x + " " +(int)tempObj.GetComponent<RectTransform>().localPosition.y);
	        images[
	            (int) tempObj.GetComponent<RectTransform>().localPosition.x,
	            (int) tempObj.GetComponent<RectTransform>().localPosition.y] = tempObj;

	    }

        //Find block positions
        for (int y = 0; y < puzzleSize; y++) {
            for (int x = 0; x < puzzleSize; x++){
                if (images[x, y].GetComponent<Image>().color == Color.white) {
                    currentPos[x, y] = images[x, y];
                }
            }
        }


    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
		    for (int i = 0; i < puzzleSize; i++){
		        images[i, i].GetComponent<Image>().color = Color.gray;
		    }
		}

        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            currentPos = currentPos;
        }
	}
}
