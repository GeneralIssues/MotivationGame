using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour {
    public GameObject mc;
    public GameObject pm;
    // Use this for initialization
    void Start () {
        mc = GameObject.FindGameObjectWithTag("MotivationController");
        pm = GameObject.FindGameObjectWithTag("PrefabManager");
    }
	
	// Update is called once per frame
	void Update () {
	}

    /// <summary>
    /// Checks collision with 2D trigger colliders and ends the game
    /// </summary>
    /// <param name="other">The Collider2D on the object</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        //Coins are destroyed and score added
        if (other.gameObject.tag == "Player")
        {
            //Did the player gather all coins, if yes more Ach score, if no less Ach score
            if(pm.GetComponent<PrefabManager>().coins.Length == 0)
            {
                mc.GetComponent<MotivationController>().IncreaseAchievementScore(50);
            }
            else
            {
                mc.GetComponent<MotivationController>().DecreaseAchievementScore(pm.GetComponent<PrefabManager>().coins.Length * 2);
            }

            //Minus action score for every enemy left aline
            mc.GetComponent<MotivationController>().DecreaseActionScore(pm.GetComponent<PrefabManager>().enemies.Length * 5);
            mc.GetComponent<MotivationController>().DecreaseImmersionScore(pm.GetComponent<PrefabManager>().list.Count * 2);
            Application.Quit();
        }
    }

}
