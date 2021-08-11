using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscMenu : MonoBehaviour
{
    public GameObject pause;
    
    // Start is called before the first frame update
    void Awake()
    {
       
        Debug.Log("è¡Ç¶ÇΩÅI");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            pause.SetActive(true);
            Debug.Log("kita");
            
            
        }
        else
        {
            pause.SetActive(false);
        }

        

    }
    public void ClosedGame()
    {
        Application.Quit();
    }
    public void QuitMenu()
    {
        pause.SetActive(false);
    }


}
