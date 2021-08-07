using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class ResultScene : MonoBehaviour
{
    public GameObject FPSController;
    public bool Scenebool = true;
   private void Start()
    {
       
    }
    public void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.tag == "Boss")
        {
            ///var DeliteFPS = FPSController.GetComponent<FirstPersonController>().enabled;
          
        
            SceneManager.LoadScene("ResultScene");
        }
        
    }
}
