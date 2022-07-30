using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Destroy2 : MonoBehaviour
{
    #region Variables
    public GameObject collider1;
    public string sound, sound2;
    public float damage;
    public GameObject explosioneffect1, explosioneffect2, explosioneffect3, effect;
    GameObject effect1, effect2, effect3, effect4;
    Healthbar healthbar1;
    #endregion
    #region Methods
    public void OnCollisionEnter(Collision obj)
    {

        if (obj.transform.tag == collider1.transform.tag)
        {
            effect1 = Instantiate(explosioneffect1, transform.position+Vector3.up, transform.rotation);
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

        else if (obj.transform.tag == "EnemyTank")
        {
            healthbar1=obj.gameObject.GetComponent<Healthbar>();
            healthbar1.slider.value = obj.gameObject.GetComponent<Healthbar>().slider.value;
            effect2 = Instantiate(explosioneffect2, transform.position, transform.rotation);
            Destroy(effect2, 1f);
            FindObjectOfType<AudioManager>().Play(sound2);
            Destroy(gameObject);
            healthbar1.curhealth=healthbar1.slider.value;
            healthbar1.curhealth -= damage;
            healthbar1.sethealth(healthbar1.curhealth);
            if(healthbar1.slider.value <= 0)
            {
                effect4 = Instantiate(effect, obj.transform.position+Vector3.up, obj.transform.rotation);
                Destroy(effect4, 1f);
                effect3 = Instantiate(explosioneffect3, obj.transform.position+Vector3.up, obj.transform.rotation);
                FindObjectOfType<AudioManager>().Play(sound);
                Destroy(effect3, 2f);
                Destroy(obj.gameObject);
                Destroyed();
                Destroy(gameObject);
            }
        }

        else
        {
            Destroy(gameObject, 8f);
        }
    }

    void Destroyed()
    {
        FindObjectOfType<Playertankcontroller>().haskilled = true;
    }
    #endregion
}
