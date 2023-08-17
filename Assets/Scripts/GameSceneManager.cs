//this ENTIRE file is original work


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using System;
using UnityEngine.SceneManagement;
using Ink.Runtime;


public class GameSceneManager : MonoBehaviour, IDataPersistence
{
    private int gameStage;
    private string currentLocation;
    private TextAsset currentScene;
    private Dictionary<int, (int, string)> stageLocations;
    private Dictionary<string, bool> roomUnlocked;
    private Dictionary<string, bool> obtainedObjects;
    private string currentGameScence;
    public int chancesRemaining;


    [SerializeField] private TextAsset Act11;
    [SerializeField] private TextAsset Act12;
    [SerializeField] private TextAsset Act13;
    [SerializeField] private TextAsset Act14;
    [SerializeField] private TextAsset Act21;
    [SerializeField] private TextAsset Act22;
    [SerializeField] private TextAsset Act23;
    [SerializeField] private TextAsset Act24;
    [SerializeField] private TextAsset Act25;
    [SerializeField] private TextAsset Act26;
    [SerializeField] private TextAsset Act27;
    [SerializeField] private TextAsset Act28;
    [SerializeField] private TextAsset Act29;
    [SerializeField] private TextAsset Act31;
    [SerializeField] private TextAsset Act32;
    [SerializeField] private TextAsset Act33;
    [SerializeField] private TextAsset Act34;
    [SerializeField] private TextAsset Act35;
    [SerializeField] private TextAsset Act36;
    [SerializeField] private TextAsset Act37;
    [SerializeField] private TextAsset Act38;

    [SerializeField] private TextAsset Act39;



    [SerializeField] private TextMeshProUGUI chancesText;
    [SerializeField] private GameObject chancesTextWrapper;
    [SerializeField] public GameObject gameOverPopup;
    [SerializeField] public GameObject gameWinPopup;
    [SerializeField] public GameObject settingsMenu;
    [SerializeField] public GameObject settingsPage1;
    [SerializeField] public GameObject settingsPage2;
    [SerializeField] private SaveSlotsMenu saveSlotsMenu;
    [SerializeField] private GameObject SkipButton;
    [SerializeField] private GameObject inventoryMenu;
    [SerializeField] private TextMeshProUGUI selectedItem;


    [SerializeField] private Animator backgroundAnimator;


    private Dictionary<(int, string), TextAsset> sceneList;


    private TextMeshProUGUI displayedData;

    private static GameSceneManager instance;


    public void LoadData(GameData data)
    {
        this.gameStage = data.gameStage;
        this.currentLocation  = data.currentLocation;
        this.stageLocations = data.stageLocations;
        this.roomUnlocked = data.roomUnlocked;
        this.obtainedObjects = data.obtainedObjects;
        this.currentGameScence = data.currentGameScence;
        this.chancesRemaining = data.chanceRemaining;
    }

    public void SaveData(ref GameData data)
    {
        data.gameStage = this.gameStage;
        data.currentLocation = this.currentLocation;
        data.roomUnlocked = (SerializableDictionary<string, bool>)this.roomUnlocked;
        data.obtainedObjects = (SerializableDictionary<string, bool>)this.obtainedObjects;
        data.currentGameScence = this.currentGameScence;
        data.chanceRemaining = this.chancesRemaining;
    }

    private void Awake()
    {

        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Dialogue mananger class");
        }
        instance = this;


        displayedData = GetComponent<TextMeshProUGUI>();

        sceneList = new Dictionary<(int, string), TextAsset>()
        {
            {(11, "myRoom"), Act11},
            { (12, "stairs"), Act12 },
            { (13, "merchantRoom"), Act13 },
            { (14, "kitchen"),Act14 },
            { (21, "myRoom"), Act21 },
            { (22, "chefRoom"),Act22 },
            { (22, "brig"),Act23 },
            { (22, "assistantRoom"),Act24 },
            { (22, "merchantRoom"),Act25},
            { (22, "maidRoom"),Act26 },
            { (22, "pub"),Act27 },
            { (22, "youngerSonRoom"), Act28 },
            { (22, "doctorOffice"),Act29 },
            { (31, "meetingRoom"), Act31 },
            { (32, "meetingRoom"), Act32 },
            { (33, "meetingRoom"), Act33 },
            { (34, "meetingRoom"), Act34 },
            { (35, "meetingRoom"), Act35 },
            { (36, "meetingRoom"), Act36 },
            { (37, "meetingRoom"), Act37 },
            { (38, "meetingRoom"), Act38 },
            { (39, "meetingRoom"), Act39 },
        };

    }

    public static GameSceneManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        inventoryMenu.SetActive(false);
        UpdateChancesText(chancesRemaining);
        Debug.Log(gameStage);
        Debug.Log(currentGameScence);

        gameOverPopup.SetActive(false);
        chancesTextWrapper.SetActive(false);

        if(gameStage >= 31)
        {
            chancesTextWrapper.SetActive(true);
            SkipButton.SetActive(false);
        } else if(gameStage > 37){
            TriggerWinGame();
        }
        
        InitiateScene();
        currentGameScence = "DialogueScene";
        
        
        
    }

    private void OnDestroy()
    {
    }

    public void OnDialogueEnd()
    {
        //return to the map scene or go to next scene, give player any item they have obtained
        EndScene();
    }

    public void StartListening(Story story)
    {
        
        story.variablesState.variableChangedEvent += VariableChanged;

    }

    public void StopListening(Story story)
    {
        story.variablesState.variableChangedEvent -= VariableChanged;

    }

    public void VariableChanged(string name, Ink.Runtime.Object value)
    {
        if (name == "gameOver")
        {

           TriggerEndGame();
        }
        if(name == "chanceMinus" && value == true )
        {
            int val = GameSceneManager.GetInstance().chancesRemaining - 1;
            Debug.Log(val);
            UpdateChancesText(val);
            

        }
        if (name == "openInventory" )
        {
            Debug.Log("openinv is set to "+value.ToString());
            if (value == true)
            {   
                Debug.Log("open inv true");
                inventoryMenu = GameSceneManager.GetInstance().inventoryMenu;
                inventoryMenu.SetActive(true);
                DialogueManager.GetInstance().dialoguePlaying = false;
            }
        }
            
    }

    public void onGameOverConfirm()
    {
        gameOverPopup.SetActive(false);
        DialogueManager.GetInstance().dialoguePlaying = true;
        InitiateScene();
    }

    public void onGameWinConfirm()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
    public void onSettingButtonClicked()
    {
        settingsMenu.SetActive(true);
    }
    public void onSettingsBackClicked()
    {
        settingsMenu.SetActive(false);
    }

    public void onMainMenuClicked()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void onSaveGameClicked()
    {
        DataPersistenceManager.GetInstance().SaveGame();
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


    public void onInventoryConfirm()
    {

        switch (gameStage)
        {
            case 32:
                if(selectedItem.text == "bottle")
                {
                    DialogueManager.GetInstance().SetStoryVariable("rightItem", true);


                }
                else
                {
                    UpdateChancesText(chancesRemaining -1);
                    
                    DialogueManager.GetInstance().SetStoryVariable("rightItem", false);
                    Debug.Log("set false");
                }
                break;
            case 34:
                if (selectedItem.text == "sonStatement")
                {
                    DialogueManager.GetInstance().SetStoryVariable("rightItem", true);


                }
                else
                {
                    UpdateChancesText(chancesRemaining - 1);

                    DialogueManager.GetInstance().SetStoryVariable("rightItem", false);
                    Debug.Log("set false");
                }
                break;
            case 35:
                if (selectedItem.text == "letter")
                {
                    DialogueManager.GetInstance().SetStoryVariable("rightItem", true);


                }
                else
                {
                    UpdateChancesText(chancesRemaining - 1);

                    DialogueManager.GetInstance().SetStoryVariable("rightItem", false);
                    Debug.Log("set false");
                }
                break;
            case 36:
                if (selectedItem.text == "wifeStatement" || selectedItem.text == "merchantReport")
                {
                    DialogueManager.GetInstance().SetStoryVariable("rightItem", true);


                }
                else
                {
                    UpdateChancesText(chancesRemaining - 1);

                    DialogueManager.GetInstance().SetStoryVariable("rightItem", false);
                    Debug.Log("set false");
                }
                break;

        }

        inventoryMenu.SetActive(false);
        DialogueManager.GetInstance().dialoguePlaying = true;



    }

    private void TriggerEndGame()
    {
        gameOverPopup = GameSceneManager.GetInstance().gameOverPopup;

        gameOverPopup.SetActive(true);
        DialogueManager.GetInstance().dialoguePlaying = false;
        UpdateChancesText(1);
    }

    private void TriggerWinGame()
    {
        gameWinPopup.SetActive(true);

    }
    private void UpdateChancesText(int value)
    {
        Debug.Log(value);
        GameSceneManager.GetInstance().chancesRemaining = value;


        if (GameSceneManager.GetInstance().chancesRemaining <= 0)
        {
            TriggerEndGame();
            
        }

    }

    private void Update()
    {

        int act = gameStage / 10;
        int scene = gameStage % 10;


        displayedData.text = "Act" + act.ToString() + " Scene" + scene.ToString();

        chancesText.text = "Chances Remaining: " + chancesRemaining.ToString();


    }

    private void EndScene()
    {   
        if (gameStage == 37)
        {
            TriggerWinGame();
            return;
        }
        if (gameStage/10 == 2)
        {
            gameStage = 22;
            
            //unlock the next scene and give the item if applicable
            switch (currentLocation)
            {
                case "myRoom":
                    roomUnlocked["chefRoom"] = true;
                    break;
                case "chefRoom":
                    roomUnlocked["brig"] = true;
                    obtainedObjects["bottle"] = true;
                    break;
                case "brig":
                    roomUnlocked["assistantRoom"] = true;

                    break;
                case "assistantRoom":
                    roomUnlocked["merchantRoom"] = true;

                    break;
                case "merchantRoom":
                    roomUnlocked["maidRoom"] = true;
                    roomUnlocked["pub"] = true;
                    roomUnlocked["youngerSonRoom"] = true;
                    obtainedObjects["wifeStatement"] = true;
                    break;
                case "maidRoom":
                    if (roomUnlocked["youngerSonRoom"] && roomUnlocked["pub"])
                    {
                        roomUnlocked["doctorOffice"] = true;
                    }
                    obtainedObjects["maidStatement"] = true;
                    break;
                case "pub":
                    if (roomUnlocked["maidRoom"] && roomUnlocked["youngerSonRoom"])
                    {
                        roomUnlocked["doctorOffice"] = true;
                    }
                    obtainedObjects["letter"] = true; 
                    break;
             
                case "youngerSonRoom":
                    if (roomUnlocked["maidRoom"] && roomUnlocked["pub"])
                    {
                        roomUnlocked["doctorOffice"] = true;
                    }                  
                    obtainedObjects["sonStatement"] = true;
                    break;
                case "doctorOffice":
                    obtainedObjects["stewardReport"] = true;
                    obtainedObjects["merchantReport"] = true;

                    break;
            }


            SceneManager.LoadSceneAsync("MapScene");

        }
        //if in Act 1 or 3 the game goes to next scene directly, if in Act 2 the game goes to map scene
        if(gameStage /10 == 3)
        {
            gameStage += 1;
            InitiateScene();
        }
        else if (gameStage / 10 == 1 || gameStage / 10 == 3)
        {
            foreach(var item in stageLocations)
            {
                if(item.Value == (gameStage, currentLocation)){
                    Debug.Log(item.Key);
                    (gameStage, currentLocation) = stageLocations[item.Key + 1];
                    InitiateScene();
                    break;
                }
            }

        }
    }

    private void InitiateScene()
    {   

        
        currentScene = sceneList[(gameStage, currentLocation)];
        backgroundAnimator.Play(currentLocation);
        DialogueManager.GetInstance().EnterDialogueMode(currentScene);
        

    }

}
