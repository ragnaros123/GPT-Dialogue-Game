//This ENTIRE file is taken from https://github.com/trevermock/save-load-system, 


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveSlotsMenu : Menu
{
    [SerializeField] private MainMenu mainMenu;
    [SerializeField] private Button backButton;
    
    private SaveSlot[] saveSlots;

    private bool isLoadingSave = false;


    private void Awake()
    {
        saveSlots = this.GetComponentsInChildren <SaveSlot>();
    }

    public void OnBackButtonClicked()
    {
         mainMenu.ActivateMenu();
        this.DeactivateMenu();
    }

    public void OnSaveSlotClicked(SaveSlot slot)
    {
        DisableButtons();

        DataPersistenceManager.instance.ChangeSelectedProfileId(slot.GetProfileId());


        if(!isLoadingSave)
        {
            DataPersistenceManager.instance.NewGame();
        }

        Debug.Log(DataPersistenceManager.instance.gameData.currentGameScence);
        if(DataPersistenceManager.instance.gameData.currentGameScence == "DialogueScene")
        {
            SceneManager.LoadSceneAsync("DialogueScene");
        }
        else
        {
            SceneManager.LoadSceneAsync("MapScene");
        }
        
    }
    public void ActivateMenu(bool isLoadingSave)
    {   

        this.gameObject.SetActive(true);

        this.isLoadingSave = isLoadingSave;

        Dictionary<string, GameData> profilesGameData = DataPersistenceManager.instance.GetAllProfiles();

        GameObject firstSelected = backButton.gameObject;

        foreach (SaveSlot saveSlot in saveSlots)
        {
            GameData profileData = null;
            profilesGameData.TryGetValue(saveSlot.GetProfileId(), out profileData);
            saveSlot.SetData(profileData);
            
            if (profileData == null && isLoadingSave )
            {
                saveSlot.SetInteractable(false);

            }
            else
            {
                saveSlot.SetInteractable(true);
                if(firstSelected.Equals(backButton.gameObject))
                {
                    firstSelected= saveSlot.gameObject;
                }
            }
        }

        //StartCoroutine(this.SetFirstSelected(firstSelected));
    }

    public void DeactivateMenu()
    {
        this.gameObject.SetActive(false);
    }

    private void DisableButtons()
    {
        foreach(SaveSlot saveSlot in saveSlots)
        {
            saveSlot.SetInteractable(false);
        }

        backButton.interactable = false; 
    }
}
