using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class MotivationController : MonoBehaviour {

    //UI variables
    public Text AcText;

    //Motivation Variables
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
	void Update (){
	    AcText.text = "Action: " + ActionScore  + " Achievement: " + AchievementScore  + " Mastery: " + MasteryScore  + " Immersion: " + ImmersionScore;
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
    public void IncreaseAchievementScore(int inc)
    {
        AchievementScore += inc;
    }
    public int GetAchievementScore()
    {
        return AchievementScore;
    }
    public void DecreaseAchievementScore(int dec)
    {
        AchievementScore -= dec;
    }
}
