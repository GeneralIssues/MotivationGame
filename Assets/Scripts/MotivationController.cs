using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    int[] level1 = new int[4];
    int[] level2 = new int[4];
    int[] level3 = new int[4];
    int[] level4 = new int[4];
    int[] level5 = new int[4];
    int[] level6 = new int[4];

    bool[] hasBeenToLevel = new bool[6];

    string currentScene;
    string lastScene;

    void Awake()
    {
        DontDestroyOnLoad(this.transform.gameObject);
    }

    // Use this for initialization
    void Start () {
        currentScene = SceneManager.GetActiveScene().name;
        lastScene = SceneManager.GetActiveScene().name;

        //Make us go from start to MainHub
        if (SceneManager.GetActiveScene().name == "Start") {
            SceneManager.LoadScene("MainHub");
        }
    }

    // Update is called once per frame
    void Update ()
    {
        AcText.text = "Action: " + ActionScore  + " Achievement: " + AchievementScore  + " Mastery: " + MasteryScore  + " Immersion: " + ImmersionScore;

        //Scene has changed if current scene is no longer the current one
        if (currentScene != SceneManager.GetActiveScene().name) {
            SceneChanged();
        }
    }

    void SceneChanged ()
    {
        lastScene = currentScene;
        currentScene = SceneManager.GetActiveScene().name;
        
        //print(lastScene + " and " + currentScene);

        if ((lastScene == "Level01" 
            || lastScene == "Level02"
            || lastScene == "Level03"
            || lastScene == "Level04"
            || lastScene == "Level05"
            || lastScene == "Level06") && currentScene == "MainHub") {
            print("Returned");

            string levelName = lastScene;
            switch (levelName) {
                case "Level01":
                    print("Level01");

                    level1[0] = ActionScore;
                    level1[1] = AchievementScore;
                    level1[2] = MasteryScore;
                    level1[3] = ImmersionScore;

                    ActionScore = 0;
                    AchievementScore = 0;
                    MasteryScore = 0;
                    ImmersionScore = 0;
                    break;
                case "Level02":
                    level2[0] = ActionScore;
                    level2[1] = AchievementScore;
                    level2[2] = MasteryScore;
                    level2[3] = ImmersionScore;

                    ActionScore = 0;
                    AchievementScore = 0;
                    MasteryScore = 0;
                    ImmersionScore = 0;
                    break;
                case "Level03":
                    level3[0] = ActionScore;
                    level3[1] = AchievementScore;
                    level3[2] = MasteryScore;
                    level3[3] = ImmersionScore;

                    ActionScore = 0;
                    AchievementScore = 0;
                    MasteryScore = 0;
                    ImmersionScore = 0;
                    break;
                case "Level04":
                    level4[0] = ActionScore;
                    level4[1] = AchievementScore;
                    level4[2] = MasteryScore;
                    level4[3] = ImmersionScore;

                    ActionScore = 0;
                    AchievementScore = 0;
                    MasteryScore = 0;
                    ImmersionScore = 0;
                    break;
                case "Level05":
                    level5[0] = ActionScore;
                    level5[1] = AchievementScore;
                    level5[2] = MasteryScore;
                    level5[3] = ImmersionScore;

                    ActionScore = 0;
                    AchievementScore = 0;
                    MasteryScore = 0;
                    ImmersionScore = 0;
                    break;
                case "Level06":
                    level6[0] = ActionScore;
                    level6[1] = AchievementScore;
                    level6[2] = MasteryScore;
                    level6[3] = ImmersionScore;

                    ActionScore = 0;
                    AchievementScore = 0;
                    MasteryScore = 0;
                    ImmersionScore = 0;
                    break;
            }
        }
        
        //If we return from Level01 to MainHub
        /*if (lastScene == "Level01" && currentScene == "MainHub") {
            level1[0] = ActionScore;
            level1[1] = AchievementScore;
            level1[2] = MasteryScore;
            level1[3] = ImmersionScore;

            ActionScore = 0;
            AchievementScore = 0;
            MasteryScore = 0;
            ImmersionScore = 0;
        }
        else if (lastScene == "Level02" && currentScene == "MainHub") {
            level1[0] = ActionScore;
            level1[1] = AchievementScore;
            level1[2] = MasteryScore;
            level1[3] = ImmersionScore;

            ActionScore = 0;
            AchievementScore = 0;
            MasteryScore = 0;
            ImmersionScore = 0;
        }
        else if (lastScene == "Level03" && currentScene == "MainHub") {
            level1[0] = ActionScore;
            level1[1] = AchievementScore;
            level1[2] = MasteryScore;
            level1[3] = ImmersionScore;

            ActionScore = 0;
            AchievementScore = 0;
            MasteryScore = 0;
            ImmersionScore = 0;
        }
        else if (lastScene == "Level04" && currentScene == "MainHub") {
            level1[0] = ActionScore;
            level1[1] = AchievementScore;
            level1[2] = MasteryScore;
            level1[3] = ImmersionScore;

            ActionScore = 0;
            AchievementScore = 0;
            MasteryScore = 0;
            ImmersionScore = 0;
        }
        else if (lastScene == "Level05" && currentScene == "MainHub") {
            level1[0] = ActionScore;
            level1[1] = AchievementScore;
            level1[2] = MasteryScore;
            level1[3] = ImmersionScore;

            ActionScore = 0;
            AchievementScore = 0;
            MasteryScore = 0;
            ImmersionScore = 0;
        }
        else if (lastScene == "Level06" && currentScene == "MainHub") {
            level1[0] = ActionScore;
            level1[1] = AchievementScore;
            level1[2] = MasteryScore;
            level1[3] = ImmersionScore;

            ActionScore = 0;
            AchievementScore = 0;
            MasteryScore = 0;
            ImmersionScore = 0;
        }*/
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
