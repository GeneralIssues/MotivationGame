using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCController : MonoBehaviour{

    public Text npctext;
    public GameObject mc;
    public GameObject pm;

    //Bools for checks
    private bool one;
    private bool two;
    private bool three;
    private bool four;
    private bool five;

    //Lore strings
    private string lore1 = "This is lore";
    private string lore11 = "lore11";
    private string lore2 = "Some more lore";
    private string lore3 = "Fred should write some lore";
    private string lore4 = "and he will at some point";
    private string lore5 = "lalala";

    // Use this for initialization
    void Start(){
        npctext = GameObject.Find("NPCText").GetComponent<Text>();
        mc = GameObject.FindWithTag("MotivationController");
        pm = GameObject.FindWithTag("PrefabManager");
    }

    // Update is called once per frame
    void Update(){
    }

    void OnTriggerStay2D(Collider2D coll){
        //Debug.Log("1");
        if (coll.tag == "Player" && Input.GetKey(KeyCode.Space)){
            if (this.name == "NPC1" && !one){
                StartCoroutine(showTextEnumerator(lore1,lore11));
                StartCoroutine(checkForSkip());
                mc.GetComponent<MotivationController>().IncreaseImmersionScore(5);
                pm.GetComponent<PrefabManager>().list.RemoveAt(0);
                one = true;

            }
            else if (this.name == "NPC2" && !two)
            {
                StartCoroutine(showTextEnumerator(lore2,lore11));
                StartCoroutine(checkForSkip());
                mc.GetComponent<MotivationController>().IncreaseImmersionScore(5);
                pm.GetComponent<PrefabManager>().list.RemoveAt(1);
                two = true;
            }
            else if (this.name == "NPC3" && !three)
            {
                StartCoroutine(showTextEnumerator(lore3,lore11));
                StartCoroutine(checkForSkip());
                mc.GetComponent<MotivationController>().IncreaseImmersionScore(5);
                pm.GetComponent<PrefabManager>().list.RemoveAt(2);
                three = true;
            }
            else if (this.name == "NPC4" && !four)
            {
                StartCoroutine(showTextEnumerator(lore4,lore11));
                StartCoroutine(checkForSkip());
                mc.GetComponent<MotivationController>().IncreaseImmersionScore(5);
                pm.GetComponent<PrefabManager>().list.RemoveAt(3);
                four = true;
            }
            else if (this.name == "NPC5" && !five)
            {
                StartCoroutine(showTextEnumerator(lore5,lore11));
                StartCoroutine(checkForSkip());
                mc.GetComponent<MotivationController>().IncreaseImmersionScore(5);
                pm.GetComponent<PrefabManager>().list.RemoveAt(4);
                five = true;

            }
        }
    }
    IEnumerator showTextEnumerator(string stuff, string stuff2){
        npctext.text = stuff;
        yield return new WaitForSeconds(3);
        npctext.text = stuff2;
        yield return new WaitForSeconds(3);
        npctext.text = "";

    }

    IEnumerator checkForSkip(){
        if (Input.GetKey(KeyCode.A)){
            StopCoroutine(showTextEnumerator("", ""));
            npctext.text = "";
            yield return new WaitForSeconds(0);
        }
    }
}
