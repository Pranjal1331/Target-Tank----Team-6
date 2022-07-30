using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
[ExecuteInEditMode]
public class Healthbar : MonoBehaviour
{
    #region Variables
    public Slider slider;
    public float maxhealth;
    public Image visualcolor;
    public TextMeshProUGUI mytext;
    public Gradient gradient;
    public float curhealth=0f;
    
    #endregion
    #region Methods
    public void Start()
    {
        curhealth = maxhealth;
        slider.maxValue = curhealth;
        slider.value = curhealth;
        gradient.Evaluate(1f);
    }
    
    public void sethealth(float health)
    {
         slider.value = health;
        visualcolor.color = gradient.Evaluate(slider.normalizedValue);
        mytext.text = "Health";
    }
    #endregion
}
