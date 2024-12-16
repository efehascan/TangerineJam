using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CinematicTextManager : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro; // Yazıları gösterecek TextMeshPro
    public List<string> texts;         // Yazıların bulunduğu liste
    public float typingSpeed = 0.05f;  // Harflerin yazılma hızı
    public AudioSource typingAudioSource; // Yazı efekti için ses kaynağı
    public AudioClip typingSound;      // Yazı efekti sesi

    private int currentTextIndex = 0;  // Şu anki yazının indeksini takip eder
    private bool isTyping = false;    // Yazma işleminin devam edip etmediğini takip eder
    private Coroutine typingCoroutine; // Yazma Coroutine'ini takip eder
    private QuestionsManager _questionsManager;

    private void Start()
    {
        _questionsManager = FindObjectOfType<QuestionsManager>();
        ShowNextText(); // İlk yazıyı başlat
    }

    private void Update()
    {
        // Kullanıcı tıklama algılama
        if (Input.GetMouseButtonDown(0)) // Sol tık algılama
        {
            if (isTyping)
            {
                // Yazı yazılıyorsa yazıyı tamamla
                CompleteText();
            }
            else
            {
                // Sonraki yazıya geç
                ShowNextText();
            }
        }
    }

    private void ShowNextText()
    {
        if (currentTextIndex < texts.Count)
        {
            string nextText = texts[currentTextIndex];
            currentTextIndex++;

            // Yazma Coroutine'ini başlat
            typingCoroutine = StartCoroutine(TypeText(nextText));
        }
        else
        {
            // Tüm yazılar bittiğinde bir fonksiyon çalıştır
            OnTextsFinished();
        }
    }

    private IEnumerator TypeText(string text)
    {
        isTyping = true;
        textMeshPro.text = ""; // Metni sıfırla

        foreach (char letter in text.ToCharArray())
        {
            textMeshPro.text += letter; // Harfi ekle

            // Ses efekti çal
            if (typingAudioSource != null && typingSound != null)
            {
                if (!typingAudioSource.isPlaying)
                {
                    typingAudioSource.clip = typingSound;
                    typingAudioSource.Play();
                }
            }

            yield return new WaitForSeconds(typingSpeed); // Yazma hızına göre bekle
        }

        // Yazma işlemi sona erdiğinde ses durdurulsun
        if (typingAudioSource != null && typingAudioSource.isPlaying)
        {
            typingAudioSource.Stop();
        }

        isTyping = false;
    }

    private void CompleteText()
    {
        // Eğer yazı yazılıyorsa, hemen yazıyı tamamla
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        // Yazıyı tamamladıktan sonra sesi durdur
        if (typingAudioSource != null && typingAudioSource.isPlaying)
        {
            typingAudioSource.Stop();
        }

        isTyping = false;
        textMeshPro.text = texts[currentTextIndex - 1]; // Mevcut yazıyı tamamla
    }

    private void OnTextsFinished()
    {
        Debug.Log("Tüm yazılar bitti!"); 
        // Burada istediğiniz fonksiyonu çağırabilirsiniz
        // Örneğin: GameManager.Instance.DialogueFinished();
        _questionsManager.BeginQuestions();
        Destroy(textMeshPro.gameObject);
        Destroy(gameObject);
    }
}
