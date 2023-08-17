//PARTS of this file is taken from https://github.com/trevermock/save-load-system, 
//The SetData() function contains original work from the project

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveSlot : MonoBehaviour
{
    [SerializeField] private string profileId = "";

    [SerializeField] private GameObject emptySlot;
    [SerializeField] private GameObject filledSlot;

    [SerializeField] private TextMeshProUGUI timeStampText;

    private Button saveSlotButton;

    private void Awake()
    {
        saveSlotButton = this.GetComponent<Button>();
    }
    public void SetData(GameData data)
    {
        if (data == null)
        {
            emptySlot.SetActive(true);
            filledSlot.SetActive(false);
        }
        else
        {
            emptySlot.SetActive(false);
            filledSlot.SetActive(true);

            int act = data.gameStage/10;
            int scene= data.gameStage%10;

            timeStampText.text = "Act"+ act.ToString() + " Scene"+ scene.ToString()+ "\n" + data.lastUpdatedTimeString;
        }
    }

    public string GetProfileId()
    {
        return this.profileId;
    }

    public void SetInteractable(bool settings)
    {
        saveSlotButton.interactable = settings; 
    }
}
