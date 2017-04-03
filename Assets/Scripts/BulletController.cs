using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float lifetime = 2.5f;
    public GameObject mc;

    void Start()
    {
        Destroy(gameObject, lifetime);
        mc = GameObject.FindGameObjectWithTag("MotivationController");
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            Destroy(coll.gameObject);
            mc.GetComponent<MotivationController>().IncreaseActionScore(5);

        }
    }
}