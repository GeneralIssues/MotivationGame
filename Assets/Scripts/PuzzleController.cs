using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleController : MonoBehaviour{

    public string name;
    public string nameY;
    public static int puzzleSize = 3;
    public GameObject[,] images = new GameObject[puzzleSize, puzzleSize];

	// Use this for initialization
	void Start (){
	    for (int i = 0; i < puzzleSize*puzzleSize; i++){
	        name = "Image" + i;
            GameObject tempObj = GameObject.Find(name);
            Debug.Log((int)tempObj.GetComponent<RectTransform>().localPosition.x + " " +(int)tempObj.GetComponent<RectTransform>().localPosition.y);
	        images[
	            (int) tempObj.GetComponent<RectTransform>().localPosition.x,
	            (int) tempObj.GetComponent<RectTransform>().localPosition.y] = tempObj;

	    }
       /*
        for (int y = 0; y < puzzleSize; y++) {
            for (int x = 0; x < puzzleSize; x++){
                name = GameObject.Find("Image" + x);
                images[x,y] = 
                //Debug.Log(name);
            }
        }
        */


    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
		    for (int i = 0; i < puzzleSize; i++){
		        images[i, i].GetComponent<Image>().color = Color.black;
		    }
		}
	}
}
