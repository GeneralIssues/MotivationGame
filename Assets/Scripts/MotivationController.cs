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

    void Awake()
    {
        DontDestroyOnLoad(this.transform.gameObject);
    }

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update ()
    {
        AcText.text = "Action: " + ActionScore  + " Achievement: " + AchievementScore  + " Mastery: " + MasteryScore  + " Immersion: " + ImmersionScore;
	}

    //Action Score Functions
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

    //Achievement Score Functions
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

    //Mastery Score Functions
    public void IncreaseMasteryScore(int inc)
    {
        MasteryScore += inc;
    }
    public int GetMasteryScore()
    {
        return MasteryScore;
    }
    public void DecreaseMasteryScore(int dec)
    {
        MasteryScore -= dec;
    }

    //Immersion Score Functions
    public void IncreaseImmersionScore(int inc)
    {
        ImmersionScore += inc;
    }
    public int GetImmersionScore()
    {
        return ImmersionScore;
    }
    public void DecreaseImmersionScore(int dec)
    {
        ImmersionScore -= dec;
    }
}
