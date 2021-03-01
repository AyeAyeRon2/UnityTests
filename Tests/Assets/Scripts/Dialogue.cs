using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [Header("NPC Details")]
    public string NPCName;

    [Header("Body Text")]
    [TextArea(3, 10)]
    public string[] sentences;
}
