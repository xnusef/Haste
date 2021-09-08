using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class PlayerManager : MonoBehaviour
{
    [System.NonSerialized]public static PlayerManager pM;
    [System.NonSerialized]public Player playerScript;
    [SerializeField]private GameObject playerPrefab;
    [SerializeField] public int maxPlayerHealth = 100;
    [System.NonSerialized] public int currentPlayerHealth;
    [System.NonSerialized] public GameObject playerObject;
    [System.NonSerialized] public int abilityCount = 0;
    [System.NonSerialized] public Dictionary<string, bool> abilities = new Dictionary<string, bool>();

    #region Getters & Setters
    public void SetAbilities(string name, bool value)
    {
        this.abilities[name] = value;
        if (name != "Dash")
            SetAbilityCount();
        GameManager.gM.SaveGame();
    }
    private void SetAbilityCount()
    {
        this.abilityCount++;
    }
    public bool GetAbilities(string name)
    {
        if (this.abilities.ContainsKey(name))
            return this.abilities[name];
        else
            return false;
    }
    public bool GetAbilityAt(int pos)
    {
        return this.abilities.Values.ElementAt(pos);
    }
    public void SetMaxHealth()
    {
        this.currentPlayerHealth = this.maxPlayerHealth;
    }
    #endregion

    void Awake()
    {
        if (pM != null)
            Destroy(this.gameObject);
        else
            pM = this;
        DontDestroyOnLoad(this);
    }
    void OnSceneLoaded()
    {
        DestroyPlayer();
    }
    void Start()
    {
        SetMaxHealth();
    }
    void Update()
    {
        if (playerObject != null && playerObject.transform.position.y <= -15)
            LevelManager.lM.RestartLevel();
        if (playerObject == null && SceneManager.GetActiveScene().buildIndex > 1)
            SpawnPlayer();
    }
    public void SpawnPlayer()
    {
        CinemachineVirtualCamera vcam = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
        Transform spawnLocation = GameObject.Find("PlayerSpawner").GetComponent<Transform>();

        this.playerObject = Instantiate(playerPrefab, spawnLocation.position, Quaternion.identity);
        this.playerObject.transform.parent = GameObject.Find("Player").transform;
        this.playerScript = playerObject.GetComponent<Player>();
        vcam.m_Follow = playerObject.transform;
    }
    public void InstantiateAbilities()
    {
        abilities.Add("Dash", false);
        abilities.Add("Vodka", false);
        abilities.Add("Saber", false);
        abilities.Add("Arquebus", false);
    }
    public void DestroyPlayer()
    {
        Destroy(this.playerObject);
    }
}
