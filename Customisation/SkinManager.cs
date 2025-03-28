using System;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour
{
    public UnlockMatrix unlockMatrix;

    public Sprite lockImage, unlockImage;
    public Button noviceButton, intermediateButton, adeptButton, masterButton;
    public Image noviceIcon, intermediateIcon, adeptIcon, masterIcon;
    public TMP_Text noviceText, intermediateText, adeptText, masterText;

    private string unlockMatrixPath;

    // Start is called before the first frame update
    private void Awake()
    {
       

    }
    void Start()
    {
        RenderSkinShop();
    }
    private void Update()
    {
        
    }
    public void RenderSkinShop()
    {
        if (Convert.ToBoolean(PlayerPrefs.GetInt("NoviceBool"))) 
        {
            noviceIcon.sprite = unlockImage;
            noviceText.text = "Skin Unlocked. Tap the button to select the novice diver skin!";
            noviceButton.interactable = true;
        }
        if (Convert.ToBoolean(PlayerPrefs.GetInt("IntermediateBool")))
        {
            intermediateIcon.sprite = unlockImage;
            intermediateText.text = "Skin Unlocked. Tap the button to select the intermediate diver skin!";
            intermediateButton.interactable = true;
        }
        if (Convert.ToBoolean(PlayerPrefs.GetInt("AdeptBool")))
        {
            adeptIcon.sprite = unlockImage;
            adeptText.text = "Skin Unlocked. Tap the button to select the adept diver skin!";
            adeptButton.interactable = true;
        }
        if (Convert.ToBoolean(PlayerPrefs.GetInt("MasterBool")))
        {
            masterIcon.sprite = unlockImage;
            masterText.text = "Skin Unlocked. Tap the button to select the master diver skin!";
            masterButton.interactable = true;
        }
    }

}
