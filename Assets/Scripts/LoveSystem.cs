using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoveSystem : MonoBehaviour
{
   public int Love = 100; //genel özgüven değeri
   private DialogManager _dialogManager; //diyolog manageri çekiyorum

   private int QuestionOneExpectionAnswer = 2; //başta karar veridiğimiz soruların değerleri birinci soru için alttakilerde aynı
   private int QuestionTwoExpectionAnswer= 3;
   private int QuestionThereExpectionAnswer= 1;
   

   private int charaterValue; // anlık olarak hangi sorunun değerini tutuğunu hesaplayan değişken
   private int currentValue; // question değerinden charter değerini çıkardığım sonucu tutan değişken

   private void Start()
   {
      _dialogManager = FindObjectOfType<DialogManager>();
      Love = 0;
   }

   private void Update()
   {
      Debug.Log("Love"+Love); 
   }

   void DecidedCharaterValue()
   {
      switch (_dialogManager.currentDiologQuestion) // diolog managerdeki hangi diyologta olduğumuza bakıp diyoloüın hangi soru ile ilgili olduğunu kontrol ediyrum
      {
         case 0: // soru 1 için 
            charaterValue =QuestionOneExpectionAnswer;
            break;
         case 1: //soru 2 için
            charaterValue =QuestionTwoExpectionAnswer;
            break;
         case 2: //soru 3 için
            charaterValue = QuestionThereExpectionAnswer;
            break;
      }
   }
   
   public void ChangeLove(int changeValue)
   {
      DecidedCharaterValue(); //butonlarla ilk çağırınca hangi soru ile alakalı cevap veridğimize bakan değişken
      Debug.Log("charatervalue"+ charaterValue);
      currentValue = charaterValue - changeValue; // aralarındaki farkı hesaplayıp uzak cevap verirsek ona göre özgüven düşürüyor
      switch (currentValue)
      {
         case -2:
            Love = Love - 20;
            break;
         case -1:
            Love = Love;
            break;
         case 0:
            Love = Love + 10;
            break;
         case 1:
            Love = Love;
            break;
         case 2:
            Love = Love - 20;
            break;
         
      }
   }

}
