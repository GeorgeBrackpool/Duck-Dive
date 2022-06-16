using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScore : MonoBehaviour
{
     [SerializeField] TextMeshProUGUI highScore;
    // Start is called before the first frame update
    void Start()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    public void ResetScore()
    {
        //This method is for testing purposes.
        PlayerPrefs.DeleteKey("HighScore");
        highScore.text = "0";
    }
}
