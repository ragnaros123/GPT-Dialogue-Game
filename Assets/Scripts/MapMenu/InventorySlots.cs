//this ENTIRE file is original work


using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{

    [SerializeField] private string profileId = "";

    [SerializeField] private GameObject hiddenSlot;
    [SerializeField] private GameObject displayedSlot;

    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private TextMeshProUGUI itemDescriptionText;

    [SerializeField] private Image itemImage;


    private string itemName;
    private string itemDescription;
    private void Awake()
    {

    }

    public void SetData(string itemName, string itemDescription)
    {
        if (itemName == null)
        {
            hiddenSlot.SetActive(true);
            displayedSlot.SetActive(false);
        }
        else
        {
            hiddenSlot.SetActive(false);
            displayedSlot.SetActive(true);

            this.itemName = itemName;
            this.itemDescription = itemDescription;
            LoadAndDisplayImage();
        }
    }


    public void OnInventoryButtonClick()
    {
        itemNameText.text = itemName;
        itemDescriptionText.text = itemDescription;

    }
    void LoadAndDisplayImage()
    {

        string imagePath = Application.dataPath + "/Animations/Items/" + itemName + ".png";
        Texture2D texture = LoadTextureFromFile(imagePath);

        itemImage.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
    }

    Texture2D LoadTextureFromFile(string filePath)
    {
        Texture2D texture = null;

        if (System.IO.File.Exists(filePath))
        {
            byte[] fileData = System.IO.File.ReadAllBytes(filePath);

            texture = new Texture2D(2, 2, TextureFormat.RGB24, false);
            texture.LoadImage(fileData);
        }
        else
        {
            Debug.LogError("File not found at path: " + filePath);
        }

        return texture;
    }

    public string GetProfileId()
    {
        return this.profileId;
    }
   
}
