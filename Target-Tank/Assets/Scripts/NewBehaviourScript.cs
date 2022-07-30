using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public Slider slider;
    public float enemyhealth;
    public Image visualcolor;
    public TextMeshProUGUI mytext;
    //public Gradient gradiant;
    float lerpSpeed = 3f;
    public void setmaxhealth()
    {
        slider.maxValue = enemyhealth;
        slider.value = enemyhealth;


    }
    public void sethealth(float health)
    {
        slider.value = health;
        mytext.text = "Health: " + (int)((health / enemyhealth) * 100) + "%";
        visualcolor.fillAmount = Mathf.Lerp(visualcolor.fillAmount, health / enemyhealth, lerpSpeed);
        Color healthcolor = Color.Lerp(Color.red, Color.green, health / enemyhealth);
        visualcolor.color = healthcolor;
    }
}
