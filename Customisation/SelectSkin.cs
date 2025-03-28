using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SelectSkin : MonoBehaviour
{
    public AudioSource selectedSound;
    public int selectedIndex;
    //Frames
    public GameObject DefaultFrame;
    public GameObject NoviceFrame;
    public GameObject IntermediateFrame;
    public GameObject AdeptFrame;
    public GameObject MasterFrame;

    //Each Method is tied to a button which enables the "frame" to show the skin is selected along with a confirmation noise. It sets all other frames to false and makes the duck Asset change skin.
    //This Class is tied closely to SkinManager, Unlock Matrix and AchievementManager. The buttons in here do not become interactable until achievements have been met.

    private void Start()
    {
        CheckFrame(); //Checks the ChosenSkin PlayerPref to see which frame it should display for the current selected skin.
    }
    public void SaveDefaultSkin()
    {
       
        PlayerPrefs.SetInt("ChosenSkin", selectedIndex = 0);
        DefaultFrame.SetActive(true);
        if(DefaultFrame.activeInHierarchy == true)
        {
            NoviceFrame.SetActive(false);
            IntermediateFrame.SetActive(false);
            AdeptFrame.SetActive(false);
            MasterFrame.SetActive(false);
        }
        selectedSound.Play();
        
        //Scriptable Object which contains the skin sprite.

    }
    public void SaveNoviceSkin()
    {
        PlayerPrefs.SetInt("ChosenSkin", selectedIndex = 1);
        NoviceFrame.SetActive(true);
        if (NoviceFrame.activeInHierarchy == true)
        {
            DefaultFrame.SetActive(false);
            IntermediateFrame.SetActive(false);
            AdeptFrame.SetActive(false);
            MasterFrame.SetActive(false);
        }
        selectedSound.Play();
       
        //Scriptable Object which contains the skin sprite.
    }
    public void SaveIntermediateSkin()
    {
        PlayerPrefs.SetInt("ChosenSkin", selectedIndex = 2);
        IntermediateFrame.SetActive(true);
        if (IntermediateFrame.activeInHierarchy == true)
        {
            DefaultFrame.SetActive(false);
            NoviceFrame.SetActive(false);
            AdeptFrame.SetActive(false);
            MasterFrame.SetActive(false);
        }
        selectedSound.Play();
        
        //DuckObject.GetComponent<SpriteRenderer>().sprite = IntermediateSkin.PlayerSkin;Scriptable Object which contains the skin sprite.
    }
    public void SaveAdeptSkin()
    {
        PlayerPrefs.SetInt("ChosenSkin", selectedIndex = 3);
        AdeptFrame.SetActive(true);
        if (AdeptFrame.activeInHierarchy == true)
        {
            DefaultFrame.SetActive(false);
            NoviceFrame.SetActive(false);
            IntermediateFrame.SetActive(false);
            MasterFrame.SetActive(false);
        }
        selectedSound.Play();
        

        //DuckObject.GetComponent<SpriteRenderer>().sprite = AdeptSkin.PlayerSkin;Scriptable Object which contains the skin sprite.
    }
    public void SaveMasterSkin()
    {
        PlayerPrefs.SetInt("ChosenSkin", selectedIndex = 4);
        MasterFrame.SetActive(true);
        if (MasterFrame.activeInHierarchy == true)
        {
            DefaultFrame.SetActive(false);
            NoviceFrame.SetActive(false);
            IntermediateFrame.SetActive(false);
            AdeptFrame.SetActive(false);
        }
        selectedSound.Play();
      
        //DuckObject.GetComponent<SpriteRenderer>().sprite = MasterSkin.PlayerSkin;Scriptable Object which contains the skin sprite.

    }

    public void CheckFrame()
    {
        if(PlayerPrefs.GetInt("ChosenSkin") == 0 && DefaultFrame != null)
        {
            DefaultFrame.SetActive(true);
        }
        if (PlayerPrefs.GetInt("ChosenSkin") == 1 && NoviceFrame != null)
        {
            NoviceFrame.SetActive(true);
        }
        if (PlayerPrefs.GetInt("ChosenSkin") == 2 && IntermediateFrame != null)
        {
            IntermediateFrame.SetActive(true);
        }
        if (PlayerPrefs.GetInt("ChosenSkin") == 3 && AdeptFrame != null)
        {
            AdeptFrame.SetActive(true);
        }
        if (PlayerPrefs.GetInt("ChosenSkin") == 4 && DefaultFrame != null)
        {
            MasterFrame.SetActive(true);
        }

    }

}
