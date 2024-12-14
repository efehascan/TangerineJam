using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Asistant : MonoBehaviour
{
    [SerializeField] private GameObject textWriter;
    private Text messageText;

    private void Awake()
    {
        messageText = transform.Find("Message").Find("messageText").GetComponent<Text>();
    }

    private void Start()
    {
        messageText.text = "Penguenleri çok severim";
    }
}

