using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfidenceSystem : MonoBehaviour
{
    private int loveFootboal = 1;

    private int answerForFootboal;

    private int currnetLoveFootboal;

    public DialogManager _dialogManager;
    // Start is called before the first frame update
    void Start()
    {
        _dialogManager = FindObjectOfType<DialogManager>();
    }
    public void CheckConfidence ()
    {
        answerForFootboal = _dialogManager.currentAnswer;
        
        currnetLoveFootboal = loveFootboal - answerForFootboal;
        switch (currnetLoveFootboal)
        {
            
            case -2:
                Debug.Log("-20 özgüven");
                break;
            case -1:
                Debug.Log("-10 özgüven");
                break;
            case 0:
                Debug.Log("+10 özgüven");
                break;
            case 1:
                Debug.Log("-10 özgüven");
                break;
            case 2:
                Debug.Log("-20 özgüven");
                break;
                
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
