using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleController : MonoBehaviour{

    string nameImg;

    public static int puzzleSize = 3;

    public GameObject[,] images = new GameObject[puzzleSize, puzzleSize];

    Vector2 currentPos;
    Vector2 winningPos;

    int maxPointCount;
    int currentPointCount;

	// Use this for initialization
	void Start (){
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
    }
	
	// Update is called once per frame
	void Update () {
        if (currentPos == winningPos && currentPointCount == maxPointCount) {
            Destroy(GameObject.Find("Puzzle 1 1(Clone)"));
            Time.timeScale = 1;
            GameObject.Find("Door1").GetComponent<Animator>().enabled = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>().PuzzleActive = false;
        }

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
            return true;
        }
        else {
            return false;
        }
    }
}
