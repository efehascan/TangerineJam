using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMan : MonoBehaviour
{
   public GameObject infoCard; // Bilgi kartı (Canvas öğesi)
    public Vector3 offset = new Vector3(500f, 250f, 0f); // Fareye göre bilgi kartının konumu
    private bool isMouseOver = false; // Fare karakterin üzerinde mi kontrolü
    private RectTransform infoCardRect; // Bilgi kartının RectTransform'u
    private Canvas canvas; // Bilgi kartının ait olduğu Canvas
    private DialogManager _dialogManager;
    public CameraZoom CameraZoom;
    
   
 

    void Start()
    {
        
        CameraZoom = FindObjectOfType<CameraZoom>();
        _dialogManager = FindObjectOfType<DialogManager>();
        if (infoCard != null)
        {
            infoCard.SetActive(false); // Bilgi kartını başlangıçta kapalı yap
            infoCardRect = infoCard.GetComponent<RectTransform>();
            canvas = infoCard.GetComponentInParent<Canvas>(); // Canvas'ı bul
        }
    }

    

    void Update()
    {
        if (isMouseOver && infoCard != null)
        {
            // Fare pozisyonunu dünya koordinatlarından UI koordinatlarına çevir
            Vector2 anchoredPosition;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvas.GetComponent<RectTransform>(), // Canvas'ın RectTransform'u
                Input.mousePosition,                 // Fare pozisyonu
                canvas.worldCamera,                  // Canvas'ın kamerası (Overlay ise null olabilir)
                out anchoredPosition                 // Çıktı olarak hesaplanan pozisyon
            );

            // Bilgi kartının pozisyonunu ayarla
            infoCardRect.anchoredPosition = anchoredPosition + (Vector2)offset;
        }
    }

    void OnMouseEnter()
    {
        if (infoCard != null)
        {
            infoCard.SetActive(true); // Fare karakterin üzerine geldiğinde bilgi kartını aç
            isMouseOver = true;
        }
    }

    void OnMouseExit()
    {
        if (infoCard != null)
        {
            infoCard.SetActive(false); // Fare karakterin üzerinden gittiğinde bilgi kartını kapat
            isMouseOver = false;
        }
    }

    void OnMouseDown()
    {
        // Karaktere tıklandığında yapılacak işlemi burada yazabilirsiniz
        PerformAction();
    }

    void PerformAction()
    {
        Debug.Log($"{gameObject.name} tıklandı!"); 
        _dialogManager.StartConversition();
        Destroy(infoCard);
        CameraZoom.MoveCameraToTarget("Man");
        
    }

   
}
