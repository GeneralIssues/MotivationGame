// This script should be an a empty gameobject somewhere in the scene
// DontDestroyOnLoad would be great (like for the most manager)

using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    // Assign the prefab in the inspector
    public GameObject BulletPrefab;
    public GameObject CoinPrefab;
    public GameObject EnemyPrefab;
    public GameObject NPCPrefab;

    //Arrays of placed items and enemies
    public GameObject[] enemies;
    public GameObject[] coins;
    public GameObject[] NPCs;
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
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        coins = GameObject.FindGameObjectsWithTag("Coin");
        NPCs = GameObject.FindGameObjectsWithTag("NPC");
        list.AddRange(GameObject.FindGameObjectsWithTag("NPC"));
    }

}