using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QuestState {  NotStarted, InProgress, Completed }

[System.Serializable] // Save data + data conversion
public class Quest
{
    public string questName;
    public QuestState state = QuestState.NotStarted;

    // Constructor that takes quest name and state
    public Quest(string questName, QuestState state)
    {
        this.questName = questName;
        this.state = state;
    }
}


public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance; // Instance of script

    public List<Quest> quests = new List<Quest>();


    public void Start()
    {
        if (Instance == null) // Singleton setup
        {
            Instance = this;
        }

        // TESTING QUEST LOGIC quest:
        quests.Add(new Quest("FindCoins", QuestState.NotStarted));

        Debug.Log("Quest added: Find coins, state of quest: " + QuestState.NotStarted);
    }


    public Quest GetQuestByName(string name)
    {
        for (int i = 0; i < quests.Count; i++) 
        {
            if (quests[i].questName == name)
            {
                return quests[i];
            }
        }

        Debug.LogWarning("Quest not found: " + name);
        return null;
    }


    public void SetQuestState(string name, QuestState newState)
    {
        Quest quest = GetQuestByName(name);
        if (quest != null)
        {
            quest.state = newState;
        }
    }
}
