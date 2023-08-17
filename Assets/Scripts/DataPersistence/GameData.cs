//this ENTIRE file is original work

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData 
{
    public int gameStage;

    
    public SerializableDictionary<string, bool> obtainedObjects;
    public SerializableDictionary<string, bool> visitedCharacters;
    public SerializableDictionary<string, bool> roomUnlocked;
    public SerializableDictionary<string, string> itemDescription;

    public string currentLocation;
    public string currentGameScence;
    public int chancesRemaining;

    //used to look up the next scene
    public Dictionary<int, (int, string)> stageLocations;

    //used to convert lookup the correct ink file
    public Dictionary<(int, string), string> sceneList;

    public string lastUpdatedTimeString;

    public long lastUpdatedTimeLong;

    public int chanceRemaining;

    public GameData()
    {
        //Gamestage 1 represents Act 1
        this.gameStage = 11;

        this.chancesRemaining = 5;

        obtainedObjects = new SerializableDictionary<string, bool>()
        {
            { "bottle", false },
            { "wifeStatement", false },
            { "maidStatement", false },
            { "letter", false },
            { "sonStatement", false },
            { "stewardReport", false },
            { "merchantReport", false },
        };


        visitedCharacters = new SerializableDictionary<string, bool>()
        {
            { "captain", false },
            { "chef", false },
            { "assistant", false },
            { "wife", false },
            { "maid", false },
            { "elderSon", false },
            { "youngerSon", false },
            { "doctor", false },
        };

        roomUnlocked = new SerializableDictionary<string, bool>()
        {
            {"chefRoom", true},
            {"brig", false},
            {"assistantRoom", false},
            {"merchantRoom", false},
            {"maidRoom", false},
            {"pub", false},
            {"youngerSonRoom", false},
            {"doctorOffice", false},

        };

        currentLocation = "myRoom";
        currentGameScence = "DialogueScene";


        stageLocations = new SerializableDictionary<int, (int, string)>
        {
            {1, (11, "myRoom") },
            {2, (12, "stairs")},
            {3, (13,"merchantRoom")},
            {4, (14,"kitchen") },
            {5, (21, "myRoom") },
            {6,  (22,"chefRoom") },
            {7, (22, "brig") },
            {8, (22,"assistantRoom") },
            {9, (22, "merchantRoom") },
            {10, (22, "maidRoom") },
            {11, (22, "pub") },
            {12, (22, "youngerSonRoom") },
            {13, (22, "doctorOffice") },
            {14, (31, "meetingRoom") }
        };

        sceneList = new SerializableDictionary<(int, string), string>()
        {
            {(11, "myRoom"),"11" },
            { (12, "stairs"), "12" },
            { (13,"merchantRoom"), "13" },
            { (14,"kitchen"),"14" },
            { (21, "myRoom"), "21" },
            { (22,"chefRoom"),"22" },
            { (22, "brig"),"23" },
            { (22,"assistantRoom"),"24" },
            { (22, "merchantRoom"),"25" },
            { (22, "maidRoom"),"26" },
            { (22, "pub"),"27" },
            { (22, "youngerSonRoom"), "28" },
            { (22, "doctorOffice"),"29" },
            { (31, "meetingRoom"), "31" },
            { (32, "meetingRoom"), "32" },
            { (33, "meetingRoom"), "33" },
            { (34, "meetingRoom"), "34" },
            { (35, "meetingRoom"), "35" },
            { (36, "meetingRoom"), "36" },
            { (37, "meetingRoom"), "37" },
            { (38, "meetingRoom"), "38" },
            { (39, "meetingRoom"), "39" },
      

        };

        itemDescription = new SerializableDictionary<string, string>() {
            { "bottle", "A bottle of poison found in the chef's bedroom" },
            { "wifeStatement", "A statement from the wife describing how the merchant went to bed a few hours after eating" },
            { "maidStatement", "A statement from the maid describing how she did not see the assistant in the merchant's bedroom when serving food" },
            { "letter", "A letter found by the elder son that id signed by P.A." },
            { "sonStatement", "A statement from the younger son about his missing bottle of chemicals" },
            { "stewardReport", "A death report describing how the steward died from a fatal blow to the head, and bruises on arms" },
            { "merchantReport", "A death report describing how the merchant died from cyanide poisoning" },
        };
    }
}
