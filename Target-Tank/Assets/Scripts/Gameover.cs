using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Gameover : MonoBehaviour
{
    #region Variables
    public GameObject gameoverscreen;
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public GameObject obj;
    #endregion
    #region Methods
    public void setscreen(int points, string sound1, string sound2)
    {
        gameoverscreen.SetActive(true);
        text1.text = "Distance: " + points.ToString();
        text2.text = "Tanks Destroyed: " + obj.GetComponent<Score>().killed;
        FindObjectOfType<AudioManager>().Stop(sound1);
        FindObjectOfType<AudioManager>().Stop(sound2);
        Time.timeScale = 0f;
    }
    public void game(int idx)
    {
        SceneManager.LoadScene(idx);
    }
    #endregion
}
