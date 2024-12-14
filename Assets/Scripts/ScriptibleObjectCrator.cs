using UnityEngine;

[CreateAssetMenu(fileName = "NewDialog", menuName = "Dialog System/Dialog")]
public class Dialog : ScriptableObject
{
    public string dialogId;    // ID of the dialog
    public string mainString;  // Main text
    public string option1;     // Option 1 text
    public string option2;     // Option 2 text
    public string option3;     // Option 3 text
    
    public string option1Id;   // ID of the ScriptableObject that option 1 leads to
    public string option2Id;   // ID of the ScriptableObject that option 2 leads to
    public string option3Id;   // ID of the ScriptableObject that option 3 leads to

    public int questionId; // o objenin hangi soru ile olduğunu hesaplıyor soru 1 için 0 soru 2 için 1 soru 3 için 2 değişkeni girmen gerkiyor 

}