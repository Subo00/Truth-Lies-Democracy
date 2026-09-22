using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PhotoConfirmer : MonoBehaviour
{
    [HideInInspector]
    public Sprite currentPhoto;

    [HideInInspector]
    public string currentDescription;

    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private GameObject confirmPhotoUI;
    [SerializeField] private Image photoConfirmationImage;
    [SerializeField] private Mover mover;
    [SerializeField] private PhotoCapture photoCapture;

    public void OnPhotoTaken()
    {
        photoCapture.enabled = false;
        mover.enabled = false;
        confirmPhotoUI.SetActive(true);
        photoConfirmationImage.sprite = currentPhoto;
        descriptionText.text = currentDescription;

    }



    public void OnBackToTakingPhotos()
    {
        photoCapture.enabled = true;
        mover.enabled = true;
        confirmPhotoUI.SetActive(false);
    }
}
