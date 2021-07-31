using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultScene : MonoBehaviour
{
   private void Start()
    {
       
    }
    public void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.tag == "Boss")
        {
            SceneManager.LoadScene("ResultScene");
        }
        
    }
}
