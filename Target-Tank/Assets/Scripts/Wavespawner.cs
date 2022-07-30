using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wavespawner : MonoBehaviour
{
    [System.Serializable]
    #region Variables
    public class enemys
    {
        public Transform enemypos;
    }
    public Transform enemy, heartpos;
    public GameObject heart;
    public float rate;
    int enemies = 0;
    public enemys[] pos;
    #endregion
    #region Methods
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {   
            GameObject obj = Instantiate(heart, heartpos.position + 3f * Vector3.up, heartpos.rotation);
            //obj.transform.LeanRotateAroundLocal(Vector3.up, 180f, 2f);
            StartCoroutine(EnemyDrop());
            gameObject.GetComponent<BoxCollider>().enabled = false;  
        }
        
    }

    int i = 0;
    IEnumerator EnemyDrop()
    {
        while (enemies < pos.Length)
        { 
            Instantiate(enemy, pos[i].enemypos.position, pos[i].enemypos.rotation);
            Debug.Log("Spawn");
            //yield return new WaitForSeconds(rate);
            enemies += 1;
            i++;
        }
        yield break;
    }
    #endregion
}
