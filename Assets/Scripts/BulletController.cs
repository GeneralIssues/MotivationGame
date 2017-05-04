using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float lifetime = 2.5f;
    public GameObject mc;

    void Start()
    {
        this.GetComponent<Animator>().Play("Fireball");
        Destroy(gameObject, lifetime);
        mc = GameObject.FindGameObjectWithTag("MotivationController");
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy") {
            Destroy(this.gameObject);
            mc.GetComponent<MotivationController>().IncreaseActionScore(5);
        }

        this.transform.eulerAngles = coll.transform.eulerAngles + new Vector3(0, 0, 180);
        this.GetComponent<Animator>().Play("fireballSplash");
        this.GetComponent<CircleCollider2D>().isTrigger = true;
    }
}