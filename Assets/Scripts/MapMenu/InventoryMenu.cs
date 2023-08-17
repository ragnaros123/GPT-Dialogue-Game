//this ENTIRE file is original work


using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMenu : MonoBehaviour, IDataPersistence
{   
    private Dictionary<string, bool> obtainedObjects;
    private Dictionary<string, string> itemDescription;

    private InventorySlot[] inventorySlots;
    private ArrayList obtainedObjectsList;
    private int gameStage;

    [SerializeField] private GameObject CloseButton;
    [SerializeField] private GameObject SubmitButton;
    [SerializeField] private TextMeshProUGUI titleText;

    public void Awake()
    {
        inventorySlots = this.GetComponentsInChildren<InventorySlot>();
    }
    public void LoadData(GameData data)
    {
        this.obtainedObjects = data.obtainedObjects;
        this.itemDescription = data.itemDescription;
        this.gameStage = data.gameStage;
    }

    public void SaveData(ref GameData data)
    {
        
    }

   
    public void Start()
    {

        Debug.Log("starting");
        obtainedObjectsList = new ArrayList();
        obtainedObjectsList = GetUnlockedObjects();
        foreach (InventorySlot slot in inventorySlots)
        {
            int profileId = int.Parse(slot.GetProfileId());
            if (profileId < obtainedObjectsList.Count)
            {
                
                string itemName = obtainedObjectsList[profileId].ToString();
                
                slot.SetData(itemName, itemDescription[itemName] );
            }
            else
            {
                break;
            }

        }
    }


    private ArrayList GetUnlockedObjects()
    {

        foreach (var item in DataPersistenceManager.GetInstance().gameData.obtainedObjects)
        {
            if (item.Value == true)
            {
                this.obtainedObjectsList.Add(item.Key);
            }

        }
        obtainedObjectsList.Reverse();
        return obtainedObjectsList;
    }



    public void OpenMenu(Dictionary<string, bool> obtainedObjects, Dictionary<string, string> itemDescriptions )
    {   

        this.obtainedObjects = obtainedObjects;
        this.itemDescription = itemDescriptions;
        this.gameObject.SetActive(true);

       gameStage=DataPersistenceManager.GetInstance().gameData.gameStage;

        if (gameStage / 10 == 2)
        {
            SubmitButton.SetActive(false);

        }
        if (gameStage / 10 == 3)
        {

            titleText.text = "Choose an item to present";
            CloseButton.SetActive(false);
        }
    }
   public void CloseMenu()
    {
        this.gameObject.SetActive(false);
    }

    
}
