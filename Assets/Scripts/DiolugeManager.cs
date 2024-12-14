using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // TextMeshPro namespace'ini ekliyoruz
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Dialog[] allDialogs;
    public Dialog currentDialog;
    public ConfidenceSystem _confidenceSystem;
    public int currentDiologQuestion;

    public TextMeshProUGUI mainText;
    public Button option1Button;
    public Button option2Button;
    public Button option3Button;

    public TextMeshProUGUI option1Text;
    public TextMeshProUGUI option2Text;
    public TextMeshProUGUI option3Text;

    [SerializeField] private float typingSpeed = 0.05f; // Yazma hızı
    [SerializeField] private AudioSource typingAudioSource; // Yazma sesi
    [SerializeField] private AudioClip typingSound;

    private void Start()
    {
        //load diyolog sıfır yerine tetikleyen olay gerçekleşince olacak 
        
        LoadDialog("0");
        _confidenceSystem = FindObjectOfType<ConfidenceSystem>();
    }

    public void LoadDialog(string dialogId)
    {
        foreach (Dialog dialog in allDialogs)
        {
            if (dialog.dialogId == dialogId)
            {
                currentDialog = dialog;
                DisplayDialog(currentDialog);
                break;
            }
        }
    }

    private void DisplayDialog(Dialog dialog)
    {
        StopTypingEffect(); // Önceki yazma efekti ve sesi durdur
        StartCoroutine(TypeText(dialog.mainString)); // Yeni yazdırmayı başlat

        option1Text.text = dialog.option1;
        option2Text.text = dialog.option2;
        option3Text.text = dialog.option3;

        option1Button.gameObject.SetActive(true);
        option2Button.gameObject.SetActive(true);
        option3Button.gameObject.SetActive(true);

        option1Button.onClick.RemoveAllListeners();
        option2Button.onClick.RemoveAllListeners();
        option3Button.onClick.RemoveAllListeners();

        option1Button.onClick.AddListener(() => OnOptionSelected(1));
        option2Button.onClick.AddListener(() => OnOptionSelected(2));
        option3Button.onClick.AddListener(() => OnOptionSelected(3));

        currentDiologQuestion = dialog.questionId;
    }

    private IEnumerator TypeText(string text)
    {
        mainText.text = ""; 

        foreach (char letter in text.ToCharArray())
        {
            mainText.text += letter;

            if (typingAudioSource != null && typingSound != null && !typingAudioSource.isPlaying)
            {
                typingAudioSource.clip = typingSound;
                typingAudioSource.Play();
            }

            yield return new WaitForSeconds(typingSpeed);
        }

        if (typingAudioSource != null && typingAudioSource.isPlaying)
        {
            typingAudioSource.Stop();
        }
    }

    private void StopTypingEffect()
    {
        StopAllCoroutines();

        if (typingAudioSource != null && typingAudioSource.isPlaying)
        {
            typingAudioSource.Stop();
        }
    }

    public void OnOptionSelected(int option)
    {
        string nextDialogId = null;

        switch (option)
        {
            case 1:
                nextDialogId = currentDialog.option1Id;
                break;
            case 2:
                nextDialogId = currentDialog.option2Id;
                break;
            case 3:
                nextDialogId = currentDialog.option3Id;
                break;
        }

        if (nextDialogId != null)
        {
            LoadDialog(nextDialogId);
        }
    }
}
