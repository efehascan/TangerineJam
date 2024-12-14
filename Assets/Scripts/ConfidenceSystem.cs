using System;
using System.Collections.Generic;
using UnityEngine;

public class ConfidenceSystem : MonoBehaviour
{
    public Dictionary<string, Action> actionDictionary;
    

    private void Start()
    {
        actionDictionary = new Dictionary<string, Action>();
        actionDictionary.Add("1", RiseUpConfidence);
        actionDictionary.Add("2", RiseDownConfidence);
    }

    void RiseUpConfidence()
    {
        Debug.Log("arttır");
    }
    void RiseDownConfidence()
    {
        Debug.Log("aazalt");
    }
}
