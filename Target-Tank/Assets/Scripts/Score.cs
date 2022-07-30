using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    #region Variables
    public TMP_Text text1;
    public TMP_Text text2;
    public Transform player;
    public int killed=0;
    #endregion
    #region Methods
    public void setscore(int score, bool value)
    {   
        text1.text = "Distance: " + score;
        if (value == true)
        {
            killed++;
        }
        text2.text = "Tanks Destroyed: " + killed;
      
        if (player == null)
        {
            Time.timeScale = 0f;
        }
    }
    #endregion
}
