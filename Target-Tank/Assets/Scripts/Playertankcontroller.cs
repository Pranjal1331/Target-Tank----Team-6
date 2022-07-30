using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playertankcontroller : MonoBehaviour
{
    #region Variables
    //Movement
    private float Forwardinput;
    private float Rotationinput;
    public float Forwardspeed;
    public float Rotationspeed;
    public Rigidbody rb;
    public Transform turret;
    public float s_turrent;
    float a_turret;
    public Gameover gameover;

    //Score
    public float maxscore = 0f;
    float score = 0f;
    public bool haskilled = false;
    public Healthbar healthbar;
    
    //Shoot
    public string fire;
    public Transform cannon, head;
    public GameObject Muzzleeffect, effect;
    public GameObject obj;
    public float force = 1000f;
    public float firerate;
    private float nextfirerate = 0f;

    //Collision
    public GameObject explosioneffect1;
    GameObject effect1;
    public string sound;
    #endregion
    #region Methods
    void FixedUpdate()
    {   
        
        if (turret)
        {
            Rotate_turret();
        }
        Forwardinput = Input.GetAxis("Vertical");
        Rotationinput = Input.GetAxis("Horizontal");
        

        Vector3 currposition = transform.position + (transform.forward * Forwardinput * Forwardspeed * Time.deltaTime);
        rb.MovePosition(currposition);
        Quaternion currrotation = transform.rotation * Quaternion.Euler(Vector3.up * (Rotationspeed * Rotationinput * Time.deltaTime));
        rb.MoveRotation(currrotation);

        score = gameObject.transform.position.z-1900f;
        if(score > maxscore)
        {
            maxscore = score;
        }
        FindObjectOfType<Score>().setscore((int)maxscore, haskilled);
        haskilled = false;

        if (Input.GetButton("Fire1") && Time.time >= nextfirerate)
        {

            nextfirerate = Time.time + 1f / firerate;
            GameObject proj = Instantiate(obj, cannon.transform.position, cannon.rotation);
            FindObjectOfType<AudioManager>().Play(fire);
            GameObject effectmuzzle = Instantiate(Muzzleeffect, cannon.transform.position, cannon.rotation);


            Destroy(effectmuzzle, 1f);


            proj.GetComponent<Rigidbody>().AddRelativeForce(obj.transform.forward * force, ForceMode.Impulse);
           
        }
        if (gameObject.transform.position.y <= -60f || (transform.rotation.z >=120 && transform.rotation.z <=240))
        {
            GameObject object1 = Instantiate(effect, transform.position, transform.rotation);
            FindObjectOfType<AudioManager>().Play("Destroyenemy");
            Destroy(object1, 1f);
            gameover.setscreen((int)maxscore, "Theme", "Tanktrack");   
        }

    }

    void Rotate_turret()
    {
        a_turret += Input.GetAxis("Mouse X") * s_turrent * -Time.deltaTime;
        a_turret = Mathf.Clamp(a_turret, -60, 60);
        turret.localRotation = Quaternion.AngleAxis(a_turret, Vector3.back);
    }

    public void OnCollisionEnter(Collision obj)
    {
        if(obj.transform.tag == "Missile_enemy")
        {
            effect1 = Instantiate(explosioneffect1, obj.transform.position, obj.transform.rotation);
            Destroy(effect1, 1f);
            Destroy(obj.gameObject);
            FindObjectOfType<AudioManager>().Play(sound);
            
            healthbar.curhealth = healthbar.slider.value;
            healthbar.curhealth -= obj.gameObject.GetComponent<Destroy>().damage;
            healthbar.sethealth(healthbar.curhealth);
            
            if(healthbar.curhealth <= 0)
            {
                GameObject effect2 = Instantiate(effect, transform.position, transform.rotation);
                Destroy(effect2 , 1f);
                FindObjectOfType<AudioManager>().Play("Destroyenemy");
                gameover = gameObject.GetComponent<Gameover>();
                gameover.setscreen((int)maxscore, "Theme", "Tanktrack");
                Destroy(gameObject);
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Heart")
        {
            Destroy(other.gameObject);
            healthbar.curhealth = healthbar.slider.value;
            healthbar.curhealth += 50f;
            if(healthbar.curhealth > 1000f)
            {
                healthbar.curhealth = 1000f;
            }
            healthbar.sethealth(healthbar.curhealth);
        }
    }
    #endregion
}
