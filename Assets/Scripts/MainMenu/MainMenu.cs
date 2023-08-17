
//PARTS of this file is taken from https://github.com/trevermock/save-load-system, 
//The OnContinueClicked() function contains original work from the project

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : Menu
{

    [SerializeField] private Button newGameButton;

    [SerializeField] private Button continueButton;

    [SerializeField] private SaveSlotsMenu saveSlotsMenu;

    [SerializeField] private Button loadGameButton;
    private void Start()
    {   
        //if no previous saves are found then turn off the continues and load game buttons
        if (!DataPersistenceManager.instance.HasGameData())
        {
            continueButton.interactable = false;
            loadGameButton.interactable = false;

        }
    }
    public void OnNewGameClicked()
    {   

       saveSlotsMenu.ActivateMenu(false);

        this.DeactivateMenu();
    }

    public void OnLoadGameClicked()
    {

        saveSlotsMenu.ActivateMenu(true);

        this.DeactivateMenu();
    }

    public void OnContinueClicked()
    {   
        DisableButtons();

        if (DataPersistenceManager.instance.gameData.currentGameScence == "DialogueScene")
        {
            SceneManager.LoadSceneAsync("DialogueScene");
        }
        else
        {
            SceneManager.LoadSceneAsync("MapScene");
        }
    }
    public void onExitClicked()
    {
        Application.Quit();
    }
    


    private void DisableButtons()
    {
        newGameButton.interactable = false;
        continueButton.interactable = false;
    }

    public void ActivateMenu()
    {
        this.gameObject.SetActive(true);
    }

    public void DeactivateMenu()
    {
        this.gameObject.SetActive(false);
    }
}
