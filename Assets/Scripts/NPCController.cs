using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCController : MonoBehaviour {

    public Text npctext;
    public GameObject mc;
    public GameObject pm;

    //Bools for checks
    private bool one;
    private bool two;
    private bool three;
    private bool four;
    private bool five;
    private bool currentlyTalking;

    //Lore strings
    private string[] lore1 = { "loreeee", "ormeoie" };
    private string[] lore2 = { "Some more lore", "Stupid poopie", "placeholder" };
    private string[] lore3 = { "lalalala", "Stupid poopie", "placeholder" };
    private string[] lore4 = { "askmdks", "Stupid poopie", "placeholder" };
    private string[] lore5 = { "Soasdasdsaade", "Stupiasdasdopie", "asdasdlder" }; 


    // Use this for initialization
    void Start() {
        npctext = GameObject.Find("NPCText").GetComponent<Text>();
        mc = GameObject.FindWithTag("MotivationController");
        pm = GameObject.FindWithTag("PrefabManager");
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.L))
        {
            StopAllCoroutines();
            npctext.text = "";
        }
    }

    void OnTriggerStay2D(Collider2D coll) {
        if (coll.tag == "Player" && Input.GetKey(KeyCode.Space)) {
            if (this.name == "NPC1" && !one) {
                StartCoroutine(DialogueStart(lore1));
                mc.GetComponent<MotivationController>().IncreaseImmersionScore(5);
                pm.GetComponent<PrefabManager>().list.RemoveAt(0);
                one = true;

            }
            else if (this.name == "NPC2" && !two)
            {
                StartCoroutine(DialogueStart(lore2));
                mc.GetComponent<MotivationController>().IncreaseImmersionScore(5);
                pm.GetComponent<PrefabManager>().list.RemoveAt(1);
                two = true;
            }
            else if (this.name == "NPC3" && !three)
            {
                StartCoroutine(DialogueStart(lore3));
                mc.GetComponent<MotivationController>().IncreaseImmersionScore(5);
                pm.GetComponent<PrefabManager>().list.RemoveAt(2);
                three = true;
            }
            else if (this.name == "NPC4" && !four)
            {
                StartCoroutine(DialogueStart(lore4));
                mc.GetComponent<MotivationController>().IncreaseImmersionScore(5);
                pm.GetComponent<PrefabManager>().list.RemoveAt(3);
                four = true;
            }
            else if (this.name == "NPC5" && !five)
            {
                StartCoroutine(DialogueStart(lore5));
                mc.GetComponent<MotivationController>().IncreaseImmersionScore(5);
                pm.GetComponent<PrefabManager>().list.RemoveAt(4);
                five = true;

            }
        }
    }

    IEnumerator DialogueStart(string[] texts)
    {

        foreach (string text in texts)
        {

            yield return StartCoroutine(Dialogue(text));

        }
        npctext.text = "";
        currentlyTalking = false;

    }

    IEnumerator Dialogue(string text)
    {
        npctext.text = text;
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Z));
    }
    IEnumerator WaitForKeyDown(KeyCode keyCode)
    {
        while (!Input.GetKeyDown(keyCode))
            yield return null;
        yield return new WaitForFixedUpdate();
    }
}
