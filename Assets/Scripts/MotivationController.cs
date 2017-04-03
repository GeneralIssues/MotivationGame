using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotivationController : MonoBehaviour {

   public int ActionScore;
   public int MasteryScore;
   public int AchievementScore;
   public int ImmersionScore;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void IncreaseActionScore(int inc)
    {
        ActionScore =+ inc;
    }
    public int GetActionScore()
    {
        return ActionScore;
    }
    public void DecreaseActionScore(int dec)
    {
        ActionScore = +dec;
    }
}
