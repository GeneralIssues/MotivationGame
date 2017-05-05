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

    public bool[] hasBeenToLevel = {false, false, false, false, false, false};

    string currentScene;
    string lastScene;

    float avAction, avAchievement, avMastery, avImmersion;
    int numberOfLevelsEntered;

    //public bool gameEnded;

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
        /*Made a method to solve this instead
        if (gameEnded){
            System.IO.File.WriteAllText("C:/Users/General/Desktop/variables.txt", "Action: " + ActionScore + " Achievement: " + AchievementScore + " Mastery: " + MasteryScore + " Immersion: " + ImmersionScore);
        }*/
    }

    /// <summary>
    /// When the scene has changed we want to save the data according to the room
    /// </summary>
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
                    hasBeenToLevel[0] = true;

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
                    hasBeenToLevel[1] = true;

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
                    hasBeenToLevel[2] = true;

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
                    hasBeenToLevel[3] = true;

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
                    hasBeenToLevel[4] = true;

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
                    hasBeenToLevel[5] = true;

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

            GameObject.FindGameObjectWithTag("End").GetComponent<EndDoor>().CheckEndDoor();
        }
    }

    /// <summary>
    /// Saving the stats from each room and average into a file
    /// </summary>
    void SaveStats ()
    {
        string path = @"C:/Users/Patrick/Desktop/variables.txt";

        string createText = "Motivation Scores";
        System.IO.File.WriteAllText(path, createText);
        
        //We check if the level has been entered at any point
        if (hasBeenToLevel[0]) {
            string level1Text = "Action: " +    level1[0]
                + " Achievement: " +            level1[1]
                + " Mastery: " +                level1[2]
                + " Immersion: " +              level1[3];
            System.IO.File.AppendAllText(path, level1Text);

            //An average score will be calculated from all scores of the rooms entered
            avAction += level1[0];
            avAchievement += level1[1];
            avMastery += level1[2];
            avImmersion += level1[3];

            //We track amount of levels entered
            numberOfLevelsEntered += 1;
        }
        if (hasBeenToLevel[1]) {
            string level2Text = "Action: " +    level2[0]
                + " Achievement: " +            level2[1]
                + " Mastery: " +                level2[2]
                + " Immersion: " +              level2[3];
            System.IO.File.AppendAllText(path, level2Text);

            avAction += level2[0];
            avAchievement += level2[1];
            avMastery += level2[2];
            avImmersion += level2[3];

            numberOfLevelsEntered += 1;
        }
        if (hasBeenToLevel[2]) {
            string level3Text = "Action: " +    level3[0]
                + " Achievement: " +            level3[1]
                + " Mastery: " +                level3[2]
                + " Immersion: " +              level3[3];
            System.IO.File.AppendAllText(path, level3Text);

            avAction += level3[0];
            avAchievement += level3[1];
            avMastery += level3[2];
            avImmersion += level3[3];

            numberOfLevelsEntered += 1;
        }
        if (hasBeenToLevel[3]) {
            string level4Text = "Action: " +    level4[0]
                + " Achievement: " +            level4[1]
                + " Mastery: " +                level4[2]
                + " Immersion: " +              level4[3];
            System.IO.File.AppendAllText(path, level4Text);

            avAction += level4[0];
            avAchievement += level4[1];
            avMastery += level4[2];
            avImmersion += level4[3];

            numberOfLevelsEntered += 1;
        }
        if (hasBeenToLevel[4]) {
            string level5Text = "Action: " +    level5[0]
                + " Achievement: " +            level5[1]
                + " Mastery: " +                level5[2]
                + " Immersion: " +              level5[3];
            System.IO.File.AppendAllText(path, level5Text);

            avAction += level5[0];
            avAchievement += level5[1];
            avMastery += level5[2];
            avImmersion += level5[3];

            numberOfLevelsEntered += 1;
        }
        if (hasBeenToLevel[5]) {
            string level6Text = "Action: " +    level6[0]
                + " Achievement: " +            level6[1]
                + " Mastery: " +                level6[2]
                + " Immersion: " +              level6[3];
            System.IO.File.AppendAllText(path, level6Text);

            avAction += level6[0];
            avAchievement += level6[1];
            avMastery += level6[2];
            avImmersion += level6[3];

            numberOfLevelsEntered += 1;
        }

        //Calculating the average
        avAction /= numberOfLevelsEntered;
        avAchievement /= numberOfLevelsEntered;
        avMastery /= numberOfLevelsEntered;
        avImmersion /= numberOfLevelsEntered;

        // We decrease achievement score my 10 for every room left
        while (numberOfLevelsEntered <= 6) {
            avAchievement -= 10;
        }

        string average = "Action: " + avAction 
            + " Achievement: " + avAchievement 
            + " Mastery: " + avMastery
            + " Immersion: " + avImmersion;
        System.IO.File.AppendAllText(path, average);
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
