//this ENTIRE file is original work


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPopup : MonoBehaviour
{
    public GameObject menuPanel;

    private bool isMenuOpen;

    void Start()
    {
        menuPanel.SetActive(false); 
        isMenuOpen = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isMenuOpen)
            {
                CloseMenu();
            }
            else
            {
                OpenMenu();
            }
        }
    }

    public void OpenMenu()
    {
        menuPanel.SetActive(true); 
        isMenuOpen = true;
    }

    public void CloseMenu()
    {
        menuPanel.SetActive(false); 
        isMenuOpen = false;
    }

    
    public void OnCloseButtonClicked()
    {
        CloseMenu();
    }
}
