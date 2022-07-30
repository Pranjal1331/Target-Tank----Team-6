using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Destroy : MonoBehaviour
{
    #region Variables
    public GameObject collider1;
    public string sound2;
    public float damage;
    public GameObject explosioneffect1, explosioneffect2;
    GameObject effect1;
    #endregion
    #region Methods
    public void OnCollisionEnter(Collision obj)
    {   
        if (obj.transform.tag == collider1.transform.tag)
        {
            effect1 = Instantiate(explosioneffect1, transform.position, transform.rotation);
            Destroy(obj.gameObject);
            FindObjectOfType<AudioManager>().Play(sound2);
            Destroy(gameObject);
            Destroy(effect1, 1f);
        }

        else if(obj.transform.tag == "Ground")
        {
            effect1 = Instantiate(explosioneffect2, transform.position, transform.rotation);
            FindObjectOfType<AudioManager>().Play("explode");
            Destroy (gameObject);
            Destroy (effect1, 1f);
        }

        else
        {
            Destroy(gameObject, 8f);
        }
    }
    #endregion
}
