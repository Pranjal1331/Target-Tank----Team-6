using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class MainMenu : MonoBehaviour
{
    #region Variables
    public GameObject title, play, options, quit;
    #endregion
    #region Methods
    private void Start()
    {
        title.transform.LeanScale(Vector2.one, 1f).setEaseInOutQuart();
        Invoke("Anim", 1.5f);
    }
    void Anim()
    {
        play.transform.LeanScale(6*Vector3.one, 1f).setEaseInOutQuart();
        options.transform.LeanScale(6*Vector3.one, 1f).setEaseInOutQuart();
        quit.transform.LeanScale(6*Vector3.one, 1f).setEaseInOutQuart();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
    #endregion
}
