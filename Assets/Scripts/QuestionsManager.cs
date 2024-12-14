using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionsManager : MonoBehaviour
{ [SerializeField] private GameObject[] questionPanels; // Soruların bulunduğu GameObject listesi
   private int currentQuestionIndex = 0; // Şu anki sorunun indeksi
   public GameObject panel;

   void Start()
   {
    
      // Tüm panelleri gizle, sadece ilkini göster
      foreach (GameObject panel in questionPanels)
      {
         panel.SetActive(false);
      }
      questionPanels[0].SetActive(true);
   }

   public void NextQuestion()
   {
      // Mevcut paneli kapat
      questionPanels[currentQuestionIndex].SetActive(false);

      // Sonraki paneli aç
      currentQuestionIndex++;
      if (currentQuestionIndex < questionPanels.Length)
      {
         questionPanels[currentQuestionIndex].SetActive(true);
      }
      else
      {
         Debug.Log("Tüm sorular cevaplandı!");
         panel.SetActive(false);
         
      }
   }
}
