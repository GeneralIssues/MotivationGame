// This script should be an a empty gameobject somewhere in the scene
// DontDestroyOnLoad would be great (like for the most manager)

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrefabManager : MonoBehaviour
{
    // Assign the prefab in the inspector
    public GameObject BulletPrefab;
    public GameObject CoinPrefab;
    public GameObject EnemyPrefab;
    public GameObject NPCPrefab;
    public GameObject Puzzle1;

    public Text text1;

    //Arrays of placed items and enemies
    public GameObject[] enemies;
    public GameObject[] coins;
    public GameObject[] coinsMax;
    public GameObject[] NPCs;
    public GameObject[] doors;
    public int numOfPuzzles;
    public List<GameObject> list = new List<GameObject>();
    //Singleton
    private static PrefabManager m_Instance = null;
    public static PrefabManager Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = (PrefabManager)FindObjectOfType(typeof(PrefabManager));
            }
            return m_Instance;
        }
    }
    void Start()
    {
        list.AddRange(GameObject.FindGameObjectsWithTag("NPC"));
        text1 = GameObject.Find("AmountOfCoins").GetComponent<Text>();
        coinsMax = GameObject.FindGameObjectsWithTag("Coin");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        doors = GameObject.FindGameObjectsWithTag("Door");
        for (int i = 0; i < doors.Length; i++){
            if (doors[i].GetComponent<DoorController>().puzzle != null){
                numOfPuzzles += 1;
            }
        }
    }
    void Update()
    {
        NPCs = GameObject.FindGameObjectsWithTag("NPC");
        coins = GameObject.FindGameObjectsWithTag("Coin");
        text1.text = "Amount of coins left in level: " + (coins.Length.ToString());
        
    }

}