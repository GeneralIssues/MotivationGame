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
    private bool six;
    private bool seven;
    private bool eight;
    private bool nine;
    private bool ten;
    private bool currentlyTalking;

    //Lore strings
    private string[] lore1 = { "Log 1, Stardate 237:..","..The reactor shut down…", "… our systems powered down, one by one…", "...most of the crew ejected…", "..but the rest are stranded here!" };
    private string[] lore2 = { "Log 2, Stardate 238:..","..The crew consisted of over 100 people…", "...the lifepods only had room for 65 of them…", "...there was a panic, people stampeded…", "...those who made it escaped…", "...we few others were left here to die!" };
    private string[] lore3 = { "Log 3, Stardate 239:..","..Our life support is failing…", "...the oxygen levels are slowly degrading…", "...we sit watching, praying…", "...huddled together for warmth…", "...space is a silent and cold killer!" };
    private string[] lore4 = { "Log 4, Stardate 240:..","..Diane went crazy…", "...said she couldn’t stand the waiting…", "...went out the airlock without a suit…", "...microgravity is making her corpse stick to the ship!" };
    private string[] lore5 = { "Log 5, Stardate 240:..","..Diane’s husband Morty…", "...he’s gone, and so is our last exo-suit…", "...we think he might have gone to get Diane…", "...who knows if he’ll be back!" };
    private string[] lore6 = { "Log 6, Stardate 241:..","..We found some more chlorite candles…", "...they should give us a few more days…", "...Rick didn’t want us to use them…", "...says it’s pointless to try…", "...we’re all losing hope!" };
    private string[] lore7 = { "Log 7, Stardate 241:..","..Rick had to be subdued…", "...he refused to let us light the candles…", "...he’s locked in the brig now…", "...his screams are echoing the ship!" };
    private string[] lore8 = { "Log 8, Stardate 242:..","..We’re down to our last litre of water…", "...seems lack of oxygen might not be our death after all…", "...we’re all so thirsty, but we have to ration it…", "...Tricia keeps talking about “the rescue soon to come”...", "...as if anyone will come for us!" };
    private string[] lore9 = { "Log 9, Stardate 244:..","..Rick hung himself in the brig…", "...we’re out of water, and food too...", "...maybe he is the lucky one!" };
    private string[] lore10 = { "Log 10: stardate 247:..","..The oxygen is almost gone…", "...so is everyone else…", "...but at least I have plenty of food and drink now…", "...my mouth constantly tastes like iron…", "...if anyone finds this log…", "...pray for my soul!" };



    // Use this for initialization
    void Start() {
        npctext = GameObject.Find("NPCText").GetComponent<Text>();
        mc = GameObject.FindWithTag("MotivationController");
        pm = GameObject.FindWithTag("PrefabManager");
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StopAllCoroutines();
            npctext.text = "";
        }
    }

    void OnTriggerStay2D(Collider2D coll) {
        if (coll.tag == "Player" && Input.GetKeyUp(KeyCode.E)) {
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
            else if (this.name == "NPC6" && !six)
            {
                StartCoroutine(DialogueStart(lore6));
                mc.GetComponent<MotivationController>().IncreaseImmersionScore(5);
                pm.GetComponent<PrefabManager>().list.RemoveAt(5);
                six = true;

            }
            else if (this.name == "NPC7" && !seven)
            {
                StartCoroutine(DialogueStart(lore7));
                mc.GetComponent<MotivationController>().IncreaseImmersionScore(5);
                pm.GetComponent<PrefabManager>().list.RemoveAt(6);
                seven = true;

            }
            else if (this.name == "NPC8" && !eight)
            {
                StartCoroutine(DialogueStart(lore8));
                mc.GetComponent<MotivationController>().IncreaseImmersionScore(5);
                pm.GetComponent<PrefabManager>().list.RemoveAt(7);
                eight = true;

            }
            else if (this.name == "NPC9" && !nine)
            {
                StartCoroutine(DialogueStart(lore9));
                mc.GetComponent<MotivationController>().IncreaseImmersionScore(5);
                pm.GetComponent<PrefabManager>().list.RemoveAt(8);
                nine = true;

            }
            else if (this.name == "NPC10" && !ten)
            {
                StartCoroutine(DialogueStart(lore10));
                mc.GetComponent<MotivationController>().IncreaseImmersionScore(5);
                pm.GetComponent<PrefabManager>().list.RemoveAt(9);
                ten = true;

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
        yield return StartCoroutine(WaitForKeyDown(KeyCode.F));
    }
    IEnumerator WaitForKeyDown(KeyCode keyCode)
    {
        while (!Input.GetKeyDown(keyCode))
            yield return null;
        yield return new WaitForFixedUpdate();
    }
}
