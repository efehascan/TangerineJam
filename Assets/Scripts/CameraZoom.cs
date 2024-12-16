using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public Transform womenTargetPosition; // Kadın karakter için hedef pozisyon
    public Transform manTargetPosition;   // Erkek karakter için hedef pozisyon
    public float defaultMoveDuration = 2f; // Varsayılan hareket süresi
    public float defaultZoomSize = 5f;     // Varsayılan kamera yakınlaştırma oranı
    public float zOffset = -10f;           // Hedefin z pozisyonundan uzaklık

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main; // Kamerayı referans al
        if (mainCamera == null)
        {
            Debug.LogError("Kamera bulunamadı!");
        }
    }

    public void MoveCameraToTarget(string targetName, float moveDuration = -1, float zoomSize = -1)
    {
        Transform targetTransform = null;

        // Hedef seçimi
        if (targetName == "Women")
        {
            targetTransform = womenTargetPosition;
        }
        else if (targetName == "Man")
        {
            targetTransform = manTargetPosition;
        }
        else
        {
            Debug.LogWarning("Geçersiz hedef adı: " + targetName);
            return;
        }

        // Hareket süresi ve zoom ayarları
        float duration = moveDuration > 0 ? moveDuration : defaultMoveDuration;
        float targetZoomSize = zoomSize > 0 ? zoomSize : defaultZoomSize;

        // Hareketi ve yakınlaştırmayı başlat
        StopAllCoroutines();
        StartCoroutine(MoveCamera(targetTransform.position + new Vector3(0, 0, zOffset), duration, targetZoomSize));
    }

    private IEnumerator MoveCamera(Vector3 targetPosition, float moveDuration, float targetZoomSize)
    {
        Vector3 startPosition = transform.position;
        float startZoom = mainCamera.orthographicSize; // Başlangıç zoom oranı
        float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            elapsedTime += Time.deltaTime;

            // Pozisyonu interpolasyon ile ayarla
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / moveDuration);

            // Zoom oranını interpolasyon ile ayarla
            mainCamera.orthographicSize = Mathf.Lerp(startZoom, targetZoomSize, elapsedTime / moveDuration);

            yield return null;
        }

        // Hedefe tam olarak ulaş
        transform.position = targetPosition;
        mainCamera.orthographicSize = targetZoomSize;
    }
}
