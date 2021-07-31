using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    private void Start()
    {
        Invoke("ChangeScene", 1.5f); 
        
    }
    private void Update()
    {

    }
    public void ChangeScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    
}
