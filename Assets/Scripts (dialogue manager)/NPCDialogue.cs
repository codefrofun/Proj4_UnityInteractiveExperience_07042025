using UnityEngine;

[System.Serializable]
public class DialogueSet
{
    public QuestState state;
    [TextArea(2, 4)]               // Creates two readable lines instead of having one long one
    public string[] dialogueLines;
}


public class NPCDialogue : MonoBehaviour
{
    public string questName; // Name of the quest this NPC reacts to
    public DialogueSet[] dialogueSets; // Dialogue per quest state

    private DialogueManagerScript dialogueManager;

    private void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManagerScript>();
    }

    public void Interact()
    {
        if (dialogueManager == null) return;

        Quest quest = QuestManager.Instance.GetQuestByName(questName);
        if (quest == null)
        {
            Debug.LogWarning($"No quest found for {questName}");
            return;
        }

        string[] dialogue = GetDialogueForState(quest.state);
        if(dialogue != null && dialogue.Length > 0)
        {
            dialogueManager.DialogueUI(dialogue);
        }
    }

    private string[] GetDialogueForState(QuestState state)
    {
        // Go through each dialogue set in the list
        foreach (DialogueSet set in dialogueSets)
        {
            // If the quest state matches this set's state (like inprogress or not, etc.)
            if (set.state == state)
            {
                return set.dialogueLines;
            }
        }
        // If no matching state is found, return a default fallback dialogue
        return new string[] { "Can I help you?" };
    }
}
