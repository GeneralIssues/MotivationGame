using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float lifetime = 10f;
    public GameObject mc;

    private IEnumerator coroutine;

    void Start()
    {
        this.GetComponent<Animator>().Play("Fireball");
        Destroy(gameObject, lifetime);
        mc = GameObject.FindGameObjectWithTag("MotivationController");
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy") {
            coroutine = Explosion(4.0f);
            StartCoroutine(coroutine);
        }

        if (coll.gameObject.tag != "Bullet") {
            this.transform.eulerAngles = coll.transform.eulerAngles + new Vector3(0, 0, 180);
            this.GetComponent<Animator>().Play("fireballSplash");
            this.GetComponent<CircleCollider2D>().isTrigger = true;
        }
    }

    void OnTriggerEnter2D (Collider2D coll)
    {
        if (coll.gameObject.tag != "Coin")
            Destroy(this.gameObject);
    }

    private IEnumerator Explosion(float aniTime)
    {
        this.GetComponent<Animator>().Play("fireballSplash");
        yield return new WaitForSeconds(aniTime);
        Destroy(this.gameObject);
    }
}
