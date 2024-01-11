using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Articy.Unity;
using Articy.Unity.Interfaces;
using Articy.UnityImporterTutorial;
using System;


public class DialogueManager : MonoBehaviour, IArticyFlowPlayerCallbacks
{
    [Header("UI")]
    // Reference to Dialog UI
    [SerializeField]
    GameObject dialogueWidget;
    // Reference to dialogue text
    [SerializeField]
    Text dialogueText;
    // Reference to speaker
    [SerializeField]
    Text dialogueSpeaker;
    //dialogue button
    [SerializeField]
    Button dialogueButton;
    [SerializeField]
    Button endDialogueButton;

    // To check if we are currently showing the dialog ui interface
    public bool DialogueActive { get; set; }

    private ArticyFlowPlayer flowPlayer;

    void Start()
    {
        flowPlayer = GetComponent<ArticyFlowPlayer>();
        dialogueButton.onClick.AddListener(ContinueDialogue);
        endDialogueButton.onClick.AddListener(CloseDialogueBox);
    }

    private void ContinueDialogue()
    {
        flowPlayer.Play();
    }

    public void StartDialogue(IArticyObject aObject)
    {
        DialogueActive = true;
        dialogueWidget.SetActive(DialogueActive);
        flowPlayer.StartOn = aObject;
        dialogueButton.gameObject.SetActive(true);

    }

    public void CloseDialogueBox()
    {
        DialogueActive = false;
        dialogueWidget.SetActive(DialogueActive);
        //dialogueButton.gameObject.SetActive(true);
        endDialogueButton.gameObject.SetActive(DialogueActive);
        flowPlayer.FinishCurrentPausedObject();
    }

    public void OnFlowPlayerPaused(IFlowObject aObject)
    {
        dialogueText.text = string.Empty;
        dialogueSpeaker.text = string.Empty;

        var objectWithText = aObject as IObjectWithText;
        if (objectWithText != null)
        {
            dialogueText.text = objectWithText.Text;
        }

        var objectWithSpeaker = aObject as IObjectWithSpeaker;
        if (objectWithSpeaker != null)
        {
            var speakerEntity = objectWithSpeaker.Speaker as Entity;
            if (speakerEntity != null)
            {
                dialogueSpeaker.text = speakerEntity.DisplayName;  
            }
        }
    }

    public void OnBranchesUpdated(IList<Branch> aBranches)
    {
        bool dialogueIsFinished = true;
        foreach (Branch branch in aBranches)
        {
            if (branch.Target is IDialogueFragment)
            {
                dialogueIsFinished = false;
                break;
            }
        }

        if (dialogueIsFinished)
        {
            dialogueButton.gameObject.SetActive(false);
            endDialogueButton.gameObject.SetActive(true);
        }
    }
}
