using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleController : MonoBehaviour{

    string nameImg;

    public int puzzleSize = 3;

    public GameObject[,] images;

    GameObject[,] imagesOrg;
    Color[] imagesColor;

    Vector2 currentPos;
    Vector2 winningPos;

    int maxPointCount;
    int currentPointCount;

    GameObject current;

    // Use this for initialization
    void Start (){
        //Create the needed arrays
        images = new GameObject[puzzleSize, puzzleSize];
        imagesOrg = new GameObject[puzzleSize, puzzleSize];
        imagesColor = new Color[puzzleSize * puzzleSize];

        current = this.transform.gameObject;

        //Fill images array with images at the correct location
        for (int i = 0; i < puzzleSize*puzzleSize; i++){
	        nameImg = "Image" + i;
            GameObject tempObj = GameObject.Find(nameImg);
            //Debug.Log((int)tempObj.GetComponent<RectTransform>().localPosition.x + " " +(int)tempObj.GetComponent<RectTransform>().localPosition.y);
	        images[
	            (int) tempObj.GetComponent<RectTransform>().localPosition.x,
	            (int) tempObj.GetComponent<RectTransform>().localPosition.y] = tempObj;
	    }
        
        //Find block positions
        for (int y = 0; y < puzzleSize; y++) {
            for (int x = 0; x < puzzleSize; x++){
                if (images[x, y].GetComponent<Image>().color == Color.white) {
                    currentPos.x = images[x, y].transform.localPosition.x;
                    currentPos.y = images[x, y].transform.localPosition.y;
                    //Debug.Log(currentPos);
                }

                if (images[x, y].GetComponent<Image>().color == Color.green) {
                    winningPos.x = images[x, y].transform.localPosition.x;
                    winningPos.y = images[x, y].transform.localPosition.y;
                    //Debug.Log(winningPos);
                }

                if (images[x, y].GetComponent<Image>().color == Color.red) {
                    maxPointCount++;
                }
            }
        }

        //Save a copy of puzzle
        int tempPos = 0;
        for (int y = 0; y < puzzleSize; y++) {
            for (int x = 0; x < puzzleSize; x++) {
                imagesColor[tempPos] = images[x, y].GetComponent<Image>().color;
                tempPos++;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        PuzzleMovement();

        //For getting out of a failed puzzle
        if (Input.GetKey(KeyCode.Space)) {
            SetOriginalPuzzle();
        }

        //Winning position
        if (currentPos == winningPos && currentPointCount == maxPointCount) {
            //Destroy(GameObject.Find("Puzzle 1(Clone)"));
            Destroy(GameObject.FindGameObjectWithTag("Puzzle"));
            Time.timeScale = 1;

            //We find the root door object
            while (current.tag != "Door") {
                current = current.transform.parent.gameObject;
            }

            //When the correct door is found, we open it
            if (current.tag == "Door") {
                current.GetComponent<Animator>().enabled = true;
                GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>().PuzzleActive = false;
            }
        }
        else if (currentPos == winningPos && currentPointCount != maxPointCount) {
            SetOriginalPuzzle();
        }
    }

    void PuzzleMovement ()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && currentPos.y < puzzleSize - 1 && ValidMove(new Vector2(currentPos.x, currentPos.y + 1))) {
            images[(int)currentPos.x, (int)currentPos.y].GetComponent<Image>().color = Color.white;
            currentPos.y = currentPos.y + 1;
            images[(int)currentPos.x, (int)currentPos.y].GetComponent<Image>().color = Color.blue;

        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentPos.x > 0 && ValidMove(new Vector2(currentPos.x - 1, currentPos.y))) {
            images[(int)currentPos.x, (int)currentPos.y].GetComponent<Image>().color = Color.white;
            currentPos.x = currentPos.x - 1;
            images[(int)currentPos.x, (int)currentPos.y].GetComponent<Image>().color = Color.blue;

        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && currentPos.y > 0 && ValidMove(new Vector2(currentPos.x, currentPos.y - 1))) {
            images[(int)currentPos.x, (int)currentPos.y].GetComponent<Image>().color = Color.white;
            currentPos.y = currentPos.y - 1;
            images[(int)currentPos.x, (int)currentPos.y].GetComponent<Image>().color = Color.blue;

        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && currentPos.x < puzzleSize - 1 && ValidMove(new Vector2(currentPos.x + 1, currentPos.y))) {
            images[(int)currentPos.x, (int)currentPos.y].GetComponent<Image>().color = Color.white;
            currentPos.x = currentPos.x + 1;
            images[(int)currentPos.x, (int)currentPos.y].GetComponent<Image>().color = Color.blue;

        }
    }

    bool ValidMove (Vector2 nextMove) {
        //Debug.Log(currentPos + " vs " + nextMove);

        if (images[(int)nextMove.x, (int)nextMove.y].GetComponent<Image>().color != Color.white &&
            images[(int)nextMove.x, (int)nextMove.y].GetComponent<Image>().color != Color.black) {
            if (images[(int)nextMove.x, (int)nextMove.y].GetComponent<Image>().color == Color.red)
                currentPointCount++;
            print(maxPointCount + " : " + currentPointCount);
            return true;
        }
        else {
            return false;
        }
    }

    void SetOriginalPuzzle()
    {
        maxPointCount = 0;
        currentPointCount = 0;

        //Set the images the original colour
        int tempPos = 0;
        for (int y = 0; y < puzzleSize; y++) {
            for (int x = 0; x < puzzleSize; x++) {
                images[x, y].GetComponent<Image>().color = imagesColor[tempPos];
                tempPos++;
            }
        }

        //Find block positions again
        for (int y = 0; y < puzzleSize; y++) {
            for (int x = 0; x < puzzleSize; x++) {
                if (images[x, y].GetComponent<Image>().color == Color.white) {
                    currentPos.x = images[x, y].transform.localPosition.x;
                    currentPos.y = images[x, y].transform.localPosition.y;
                    //Debug.Log(currentPos);
                }

                if (images[x, y].GetComponent<Image>().color == Color.green) {
                    winningPos.x = images[x, y].transform.localPosition.x;
                    winningPos.y = images[x, y].transform.localPosition.y;
                    //Debug.Log(winningPos);
                }

                if (images[x, y].GetComponent<Image>().color == Color.red) {
                    maxPointCount++;
                }
            }
        }
    }
}
