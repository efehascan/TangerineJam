using System;
using System.Collections.Generic;
using UnityEngine;

public class ConfidenceSystem : MonoBehaviour
{
    private Dictionary<string, Action> actionDictionary;

    private void Start()
    {
        actionDictionary = new Dictionary<string, Action>();
    }
}
