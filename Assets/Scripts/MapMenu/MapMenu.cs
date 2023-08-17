//this ENTIRE file is original work


using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MapMenu : MonoBehaviour, IDataPersistence
{

    private LocationSlot[] locationSlots;
    private ArrayList unlockedLocations;

    [SerializeField] private Button settingsButton;
    [SerializeField] private Button inventoryButton;
    [SerializeField] private GameObject meetingButton;

    [SerializeField] private InventoryMenu inventoryMenu;


    private int gameStage;
    private string currentLocation;
    private TextAsset currentScene;
    private Dictionary<int, (int, string)> stageLocations;
    private Dictionary<string, bool> roomUnlocked;
    private Dictionary<string, string> itemDescription;
    private Dictionary<string, bool> obtainedObjects;
    private string currentGameScence;



    [SerializeField] public GameObject settingsMenu;
    [SerializeField] public GameObject settingsPage1;
    [SerializeField] private SaveSlotsMenu saveSlotsMenu;



    public void LoadData(GameData data)
    {
        this.gameStage = data.gameStage;
        this.currentLocation = data.currentLocation;
        this.stageLocations = data.stageLocations;
        this.roomUnlocked = data.roomUnlocked;
        this.itemDescription = data.itemDescription;
        this.obtainedObjects    = data.obtainedObjects;
        this.currentGameScence = data.currentGameScence;
    }

    public void SaveData(ref GameData data)
    {   
        data.gameStage = this.gameStage;
        data.currentLocation = this.currentLocation;
        data.currentGameScence = this.currentGameScence;
    }

    private void Awake()
    {
        //initialise all location slots
        locationSlots = this.GetComponentsInChildren<LocationSlot>();

        

    }

    private void Start()
    {
        Debug.Log(gameStage);
        //get info of unlocked locations and 

        this.currentGameScence = "MapScene";

        unlockedLocations = new ArrayList();
        unlockedLocations = GetUnlockedLocations();
        foreach (LocationSlot slot in locationSlots)
        {
            int profileId = int.Parse(slot.GetProfileId());
            if (profileId < unlockedLocations.Count)
            {
                slot.SetData(unlockedLocations[profileId].ToString());
                slot.SetInteractable(true);
            }
            else
            {
                slot.SetInteractable(false);
            }
            
        }

        InitialiseMeetingButton();
    }

    private ArrayList GetUnlockedLocations()
    {

        foreach ( var item in this.roomUnlocked )
        {
            if (item.Value == true)
            {
                this.unlockedLocations.Add(item.Key);
            }
            
        }
        unlockedLocations.Reverse();
        return unlockedLocations;
    }
    public void OnLocationSlotClicked(LocationSlot slot)
    {
        DisableButtons();

        currentLocation = slot.GetLocation();

        SceneManager.LoadSceneAsync("DialogueScene");
    }
    private void InitialiseMeetingButton()
    {
        bool setting = true;
        foreach(var item in obtainedObjects)
        {
            if (item.Value == false) {
                setting = false;
                break;
            }
        }

        this.meetingButton.SetActive(setting);
    }

    private void DisableButtons()
    {
        foreach (LocationSlot locationSlot in locationSlots)
        {
            locationSlot.SetInteractable(false);
        }

        settingsButton.interactable = false;
        inventoryButton.interactable = false;
    }

    public void OnInventoryButtonClick()
    {
        inventoryMenu.OpenMenu(obtainedObjects, itemDescription);
    }

    public void OnMeetingButtonClick()
    {
        this.gameStage = 31;
        this.currentLocation = "meetingRoom";
        SceneManager.LoadSceneAsync("DialogueScene");
    }

    public void onSettingButtonClicked()
    {
        settingsMenu.SetActive(true);
    }
    public void onSettingsBackClicked()
    {
        settingsMenu.SetActive(false);
    }

    public void onSaveGameClicked()
    {
        DataPersistenceManager.GetInstance().SaveGame();
    }

    public void onMainMenuClicked()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void onLoadGameClicked()
    {
        settingsPage1.SetActive(false);
        saveSlotsMenu.ActivateMenu(true);
    }

    public void onLoadGameBackClicked()
    {
        settingsPage1.SetActive(true);
        saveSlotsMenu.DeactivateMenu();
    }

    private void OnDestroy()
    {
        DataPersistenceManager.GetInstance().SaveGame();
    }
}
