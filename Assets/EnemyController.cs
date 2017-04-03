using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public string state = "Alert";
    public float speed;
    public GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
	    if (state == "Chilling"){
	        Debug.Log("chillin");
            if (Vector3.Distance(transform.position, player.transform.position) < 3f)
                state = "Alert";
        }


        if (state == "Alert")
        {
            //transform.LookAt(player.transform);
            this.transform.position = Vector2.MoveTowards(this.transform.position,player.transform.position, 1 * Time.deltaTime);
            if (Vector3.Distance(transform.position, player.transform.position) < 2f)
                state = "Chase";
        }

        if (state == "Chase")
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, 1 * Time.deltaTime);
            if (Vector3.Distance(transform.position, player.transform.position) < 1.5f)
                state = "Attack";
        }

        if (state == "Attack")
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, 1 * Time.deltaTime);
            if (Vector3.Distance(transform.position, player.transform.position) > 2f)
                state = "Chase";
        }
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            print("Triggering enemy");

        }
    }
}
