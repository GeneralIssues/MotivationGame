using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public string state = "Chilling";
    public float speed;
    public GameObject player;
    public float range = 5;

    float enemyHP = 100;
    float bulletDmg = 40;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
	    if (state == "Chilling"){
            GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            if (Vector3.Distance(transform.position, player.transform.position) < range)
                state = "Attack";
        }
        if (state == "Attack")
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, 1 * Time.deltaTime);
            if (Vector3.Distance(transform.position, player.transform.position) > range)
                state = "Chilling";
        }

        //Death of enemy
        if (enemyHP <= 0) {
            this.GetComponent<Animator>().Play("enemyDead");
        }
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            print("Triggering enemy");

        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Bullet") {
            enemyHP -= bulletDmg;
        }
    }
}
