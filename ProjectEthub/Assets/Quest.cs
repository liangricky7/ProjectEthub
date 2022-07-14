using UnityEngine;

public class QuestData : ScriptableObject
{
    new public string name;
    public string description;
    public Item[] itemDrops;
    public bool isMainQuest;
    public NPC questGiver;
}
