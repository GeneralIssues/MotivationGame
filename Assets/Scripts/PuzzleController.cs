using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleController : MonoBehaviour {

    public static int puzzleSize = 1;
    public Image[,] images = new Image[puzzleSize, puzzleSize];

	// Use this for initialization
	void Start () {
        
        for (int y = 0; y < puzzleSize; y++) {
            for (int x = 0; x < puzzleSize; x++) {
                
            }
        }


    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
            images[0, 0].GetComponent<Image>().color = Color.black;
        }
	}
}
