//This ENTIRE file is taken from https://github.com/trevermock/save-load-system, 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;

public class DataPersistenceManager : MonoBehaviour
{

    [SerializeField] private string fileName;

    //set true during debug
    [SerializeField] private bool initialiseDataIfNull;


    private FileDataHandler dataHandler;

    public GameData gameData;

    private List<IDataPersistence> dataPersistenceObjects;

    private string selectedProfileId = "";
    public static DataPersistenceManager instance { get; private set; }




   
    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("more than one DataPersistenceManagers present, deleting current one");

            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);

        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);

        this.selectedProfileId= dataHandler.GetMostRecentlyUpdatedProfileId();

    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    public static DataPersistenceManager GetInstance()
    {
        return instance;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("onsceneloaded");
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    public void OnSceneUnloaded(Scene scene)
    {
        SaveGame();

    }

    public void ChangeSelectedProfileId(string profileId)
    {
        this.selectedProfileId = profileId;

        LoadGame();
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {

        this.gameData = dataHandler.Load(selectedProfileId);

        if(this.gameData == null && initialiseDataIfNull)
        {   
            
            NewGame();
        }

        if(gameData == null)
        {
            Debug.Log("no game data, please create a new game");
            return;

        }

        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);

        }
    }

    public void SaveGame()
    {
        if (this.gameData == null)
        {
            Debug.Log("No data found, please create new game before saving");
            return;
        }
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref gameData);

        }

        gameData.lastUpdatedTimeString = System.DateTime.Now.ToString();
        gameData.lastUpdatedTimeLong = System.DateTime.Now.ToBinary();

        dataHandler.Save(gameData, selectedProfileId);

    }


    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }

    public bool HasGameData()
    {
        return gameData != null;
    }

    public Dictionary<string, GameData> GetAllProfiles()
    {
        return dataHandler.LoadAllProfiles();
    }
}
