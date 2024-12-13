using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfidenceSystem : MonoBehaviour
{
    private int loveFootboal;

    private int answerForFootboal;

    private int currnetLoveFootboal;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void CheckConfidence ()
    {
        Debug.Log("sex");
        currnetLoveFootboal = loveFootboal - answerForFootboal;
        switch (currnetLoveFootboal)
        {
            case -1:
                Debug.Log("-10 özgüven");
                break;
            case 0:
                Debug.Log("+10 özgüven");
                break;
            case 1:
                Debug.Log("-10 özgüven");
                break;
                
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
