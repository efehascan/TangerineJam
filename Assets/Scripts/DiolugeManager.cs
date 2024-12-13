using System;
using UnityEngine;
using TMPro; // TextMeshPro namespace'ini ekliyoruz
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Dialog[] allDialogs;  // Tüm diyalogları tutan dizi
    private Dialog currentDialog; // Şu anda gösterilen diyalog
    private bool inAction;
    public ConfidenceSystem _confidenceSystem;
    private int currentAnswer;

    // UI Elemanları için TextMeshProUGUI referansları
    public TextMeshProUGUI mainText;  // Ana diyalog metni
    public Button option1Button;      // 1. seçenek butonu
    public Button option2Button;      // 2. seçenek butonu
    public Button option3Button;      // 3. seçenek butonu

    // Seçeneklerin TextMeshProUGUI referansları
    public TextMeshProUGUI option1Text;
    public TextMeshProUGUI option2Text;
    public TextMeshProUGUI option3Text;

    private void Start()
    {
        LoadDialog("0");
        _confidenceSystem = FindObjectOfType<ConfidenceSystem>();
    }

    public void LoadDialog(string dialogId)
    {
        // Dialog ID'ye göre doğru diyalogu yükle
        foreach (Dialog dialog in allDialogs)
        {
            if (dialog.dialogId == dialogId)
            {
                currentDialog = dialog;
                DisplayDialog(currentDialog);
                break;
            }
        }
        
        _confidenceSystem.CheckConfidence();
        
        
    }

    private void DisplayDialog(Dialog dialog)
    {
        // Ana metni TextMeshPro ile göster
        mainText.text = dialog.mainString;

        // Seçenekleri TextMeshPro ile göster
        option1Text.text = dialog.option1;
        option2Text.text = dialog.option2;
        option3Text.text = dialog.option3;

        // Butonları etkinleştir
        option1Button.gameObject.SetActive(true);
        option2Button.gameObject.SetActive(true);
        option3Button.gameObject.SetActive(true);
        
        // Her bir butona tıklama işlevselliği ekle
        option1Button.onClick.RemoveAllListeners();
        option2Button.onClick.RemoveAllListeners();
        option3Button.onClick.RemoveAllListeners();

        option1Button.onClick.AddListener(() => OnOptionSelected(1));
        option2Button.onClick.AddListener(() => OnOptionSelected(2));
        option3Button.onClick.AddListener(() => OnOptionSelected(3));
    }

    public void OnOptionSelected(int option)
    {
        string nextDialogId = null;
        Debug.Log(option);
        currentAnswer = option;

        // Seçilen seçeneğe göre bir sonraki diyalog ID'sini al
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

        // Yeni diyalog ID'si varsa, yeni diyalogu yükle
        if (nextDialogId != null)
        {
            LoadDialog(nextDialogId);
        }
    }
}
