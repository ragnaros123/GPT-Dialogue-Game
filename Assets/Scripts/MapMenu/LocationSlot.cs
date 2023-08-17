//this ENTIRE file is original work


using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LocationSlot : MonoBehaviour
{
    [SerializeField] private string profileId = "";

    [SerializeField] private GameObject hiddenSlot;
    [SerializeField] private GameObject displayedSlot;

    [SerializeField] private TextMeshProUGUI locationText;
    [SerializeField] private Image locationImage;

    private Dictionary<string, string> locationNames;   
    private Button locationSlotButton;
    private string location;

    private void Awake()
    {
        locationSlotButton = this.GetComponent<Button>();
        locationNames = new Dictionary<string, string> {

            {"chefRoom", "Chef's Bedroom"},
            {"brig", "The Brig"},
            {"assistantRoom", "Assistant's Room"},
            {"merchantRoom", "Merchant's Room"},
            {"maidRoom", "Maid's Room"},
            {"pub", "The Pub"},
            {"youngerSonRoom", "Younger Son's Room"},
            {"doctorOffice", "Doctor's Office"},

        };

    }

    private void Start()
    {
        
    }
    public void SetData(string location)
    {   

        if (location == null)
        {
            hiddenSlot.SetActive(true);
            displayedSlot.SetActive(false);
        }
        else
        {   
            hiddenSlot.SetActive(false);
            displayedSlot.SetActive(true);

            Debug.Log(location);
            Debug.Log(locationNames[location]);
            locationText.text = locationNames[location];
            this.location = location;

            LoadAndDisplayImage();

            
        }
    }

    void LoadAndDisplayImage()
    {

        string imagePath = Application.dataPath + "/Animations/background/" + location + ".png";
        Texture2D texture = LoadTextureFromFile(imagePath);

        locationImage.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
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

    public string GetLocation()
    { return this.location; }

    public void SetInteractable(bool settings)
    {
        locationSlotButton.interactable = settings;
    }
}
