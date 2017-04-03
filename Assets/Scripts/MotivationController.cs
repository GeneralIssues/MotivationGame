using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotivationController : MonoBehaviour {

   [Range(0, 100)]
   public int ActionScore;
   [Range(0, 100)]
   public int MasteryScore;
   [Range(0, 100)]
   public int AchievementScore;
   [Range(0, 100)]
   public int ImmersionScore;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void IncreaseActionScore(int inc)
    {
        ActionScore += inc;
    }
    public int GetActionScore()
    {
        return ActionScore;
    }
    public void DecreaseActionScore(int dec)
    {
        ActionScore -= dec;
    }
}
