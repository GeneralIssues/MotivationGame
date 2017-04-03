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
    /// <param name="other"></param>
    void OnTriggerEnter2D(Collider2D other)
    {
        //Coins are destroyed and score added
        if (other.gameObject.tag == "Player")
        {
            mc.GetComponent<MotivationController>().DecreaseActionScore(pm.GetComponent<PrefabManager>().enemies.Length * 5);
            Application.Quit();
        }
    }

}
