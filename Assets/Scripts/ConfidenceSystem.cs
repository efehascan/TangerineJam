using System;
using System.Collections.Generic;
using UnityEngine;

public class ConfidenceSystem : MonoBehaviour
{
   public int Confidence = 100; //genel özgüven değeri
   private DialogManager _dialogManager; //diyolog manageri çekiyorum

   private int QuestionOneValue = 1; //başta karar veridiğimiz soruların değerleri birinci soru için alttakilerde aynı
   private int QuestionTwoValue= 2;
   private int QuestionThereValue= 3;
   

   private int charaterValue; // anlık olarak hangi sorunun değerini tutuğunu hesaplayan değişken
   private int currentValue; // question değerinden charter değerini çıkardığım sonucu tutan değişken

   private void Start()
   {
      _dialogManager = FindObjectOfType<DialogManager>();
      Confidence = 100;
   }

   public void ExchangeQuestionOne(int value)
   {
      QuestionOneValue = value;
   }
   public void ExchangeQuestionTwo(int value)
   {
      QuestionTwoValue = value;
   }
   public void ExchangeQuestionThere(int value)
   {
      QuestionThereValue = value;
   }

   private void Update()
   {
      Debug.Log(Confidence); 
   }

   void DecidedCharaterValue()
   {
      Debug.Log("QuestionID"+_dialogManager.currentDiologQuestion);
      switch (_dialogManager.currentDiologQuestion) // diolog managerdeki hangi diyologta olduğumuza bakıp diyoloüın hangi soru ile ilgili olduğunu kontrol ediyrum
      {
         case 0: // soru 1 için 
            charaterValue = QuestionOneValue;
            break;
         case 1: //soru 2 için
            charaterValue = QuestionTwoValue;
            break;
         case 2: //soru 3 için
            charaterValue = QuestionThereValue;
            break;
      }
   }
   
   public void ChangeConfidence(int changeValue)
   {
      DecidedCharaterValue(); //butonlarla ilk çağırınca hangi soru ile alakalı cevap veridğimize bakan değişken
      Debug.Log("charatervalue"+ charaterValue);
      currentValue = charaterValue - changeValue; // aralarındaki farkı hesaplayıp uzak cevap verirsek ona göre özgüven düşürüyor
      switch (currentValue)
      {
         case -2:
            Confidence = Confidence- 20;
            break;
         case -1:
            
            break;
         case 0:
            Confidence = Confidence + 10;
            break;
         case 1:
            
            break;
         case 2:
            Confidence = Confidence - 20;
            break;
         
      }
   }
   
   
}
