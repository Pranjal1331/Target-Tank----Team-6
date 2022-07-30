using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Loadingscreen : MonoBehaviour
{
    #region Variables
    [SerializeField] private GameObject _canvas;
    [SerializeField] private Slider progressbar;   
    private float _target;
    #endregion
    #region Methods
    public void LoadScene(int index)
    {
        StartCoroutine(LoadSceneAsync(index));
    }
    
      IEnumerator LoadSceneAsync(int index)
      {
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);
        Time.timeScale = 1f;
        _canvas.SetActive(true);
        while(!operation.isDone)
        {   
            _target = operation.progress;

            if (operation.isDone)
            {
                SceneManager.LoadScene(index);
            }
            yield return null;
        }
       
        _canvas.SetActive(false);
    }
    
    void Update()
    {
        progressbar.value=Mathf.MoveTowards(progressbar.value, _target, 10*Time.deltaTime);
    }
    #endregion
}
