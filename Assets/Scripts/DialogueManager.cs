//PARTS of this file is taken from https://github.com/trevermock/ink-dialogue-system, 
//The Start() Update() EnterDialogueMode() ExitDialogueMode() HandleTags() functions contains original work from the project

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using System.Net;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private InputActionReference continueDialogue;

    [SerializeField] private float typingSpeed = 0.04f;
    private static Coroutine typingCoroutine;
    private bool typingDone = false;

    [Header("Dialogue UI")]
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI displayNameText;
    [SerializeField] private GameObject nextIndicator;

    

    [SerializeField] private GameObject portraitFrame;
    [SerializeField] private GameObject nameFrame;

    [SerializeField] private Animator portraitAnimator;
    [SerializeField] private Animator layoutAnimator;


    [Header("Choices UI")]

    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    [SerializeField] private GameObject gameOverPopup;


    [SerializeField] private TextAsset inkJSON; 
    private Story currentStory;


    [SerializeField] AudioClip typingSound;
    [SerializeField] AudioSource audioSource;



    //indicates whether dialogue is playing
    public bool dialoguePlaying;

    private static DialogueManager instance;

    private GameSceneManager dialogueVariables;


    //tags 
    private const string SPEAKER_TAG = "speaker";
    private const string PORTRAIT_TAG = "portrait";
    private const string LAYOUT_TAG = "layout";

    private void Awake()
    {   
        // checks for singleton class
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Dialogue mananger class");
        }
        instance = this;

        dialogueVariables = new GameSceneManager();
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialoguePlaying = true;
        dialoguePanel.SetActive(true);
        portraitFrame.SetActive(true);
        nameFrame.SetActive(true);

        HideChoices();


        //initialise the choicesText array that stores the text in choices
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices) 
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;    
        }
    }


    private void Update()
    {
        if (!dialoguePlaying)
        {
            return;
        }

        if (currentStory.currentChoices.Count == 0 && typingDone && InputManager.GetInstance().GetSubmitPressed())
        {
            Debug.LogWarning(currentStory.currentChoices);
            ContinueStory();    
        }

    }

    public void OnDialogueBoxClicked()
    {
        InputManager.GetInstance().submitPressed = true;
    }


    public void DialogueNext() {
        
    }


    public void EnterDialogueMode(TextAsset inkJSON)
    {

        //initialises the ink story object, and reveals the dialogue panel
        currentStory = new Story(inkJSON.text);
        Debug.LogWarning("dialogue mode entered");
        dialoguePlaying = true;
        dialoguePanel.SetActive(true);
        portraitFrame.SetActive(true);
        nameFrame.SetActive(true);

        dialogueVariables.StartListening(currentStory);

        displayNameText.text = "";
        portraitAnimator.Play("default");
        layoutAnimator.Play("left");

        ContinueStory();
    }

    private void ExitDialogueMode()
    {
        Debug.LogWarning("dialogue mode exited");
        dialoguePlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
        portraitFrame.SetActive(false);
        nameFrame.SetActive(false);
        HideChoices();



        dialogueVariables.StopListening(currentStory);


        GameSceneManager.GetInstance().OnDialogueEnd();

    }

    public void  SetStoryVariable(string name, bool value)
    {
        currentStory.variablesState[name] = value;
    }


    private void ContinueStory()
    {   

        //checks if the dialogue can continue, and go to next line
        if (currentStory.canContinue)
        {
            Debug.LogWarning("story continue");
            if(typingCoroutine != null)
            {
                StopCoroutine(typingCoroutine);
            }


            typingCoroutine = StartCoroutine(DisplayLine(currentStory.Continue()));

            

            HandleTags(currentStory.currentTags);
        }
        else
        {
            Debug.LogWarning("story cannot continue");

            ExitDialogueMode();
        }
    }

    private IEnumerator DisplayLine(string line)
    {   

        //display the line of the dialogue with a typing effect
        dialogueText.text = "";

        HideChoices();
        nextIndicator.SetActive(false);

        typingDone = false;


        foreach(char letter in line.ToCharArray())
        {   
            //if space is pressed then skip the typing effect and show the entire line
            if (InputManager.GetInstance().GetSubmitPressed())
            {
                dialogueText.text = line;
                break;
            }

            dialogueText.text += letter;
            audioSource.clip = typingSound;
            audioSource.Play();
            yield return new WaitForSeconds(typingSpeed);
        }

        nextIndicator.SetActive(true);
        DisplayChoices();

        typingDone = true;
    }


    private void HideChoices()
    {
        foreach(GameObject choiceButton in choices)
        {
            choiceButton.SetActive(false);
        }
    }

   

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;
        
        if (currentChoices.Count > choices.Length) 
        {
            Debug.LogError("Choices number excess UI limit");
        }

        int index = 0;
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;    

        }

        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }

        StartCoroutine(SelectFirstChoice());
    }


    private IEnumerator SelectFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    private void HandleTags(List<string> currentTags)
    {
        string portrait = "";
        foreach (string tag in currentTags)
        {
            string[] splitTag = tag.Split(":");
            if (splitTag.Length != 2)
            {
                Debug.LogError("Tag could not be parsed, length is "+tag);

            }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            

            switch (tagKey)
            {
                case SPEAKER_TAG:

                    displayNameText.text = tagValue;
                    portrait = tagValue;
                    break;
                case PORTRAIT_TAG:
                    
                    portrait = portrait + "_" + "neutral";
                    portrait = portrait.Replace(".", "");
                    Debug.Log(portrait);
                    portraitAnimator.Play(portrait);
                    break;
                case LAYOUT_TAG:
                    layoutAnimator.Play(tagValue);
                    break;
                default:
                    break;



            }
        }
    }
    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);

        InputManager.GetInstance().RegisterSubmitPressed();

        if (typingDone)
        {
            ContinueStory();
        }
        
    }

    public void OnSkipClicked()
    {
        ExitDialogueMode();
    }

   
}
