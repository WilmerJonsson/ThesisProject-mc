using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NPC : MonoBehaviour, IInteractable
{
    [SerializeField] private List<SO_Dialogue> dialogues;
        int currentDialogueIndex = 0;
    public void Interact()
    {
        if (dialogues.Count == 0) return;

        DialogueManager.Instance.QueueDialogue(dialogues[currentDialogueIndex], this);
    }

    public void OnDialogueFinished()
    {
        currentDialogueIndex++;
        if (currentDialogueIndex >= dialogues.Count)
        {
            currentDialogueIndex = 0;
        }
    }

}
