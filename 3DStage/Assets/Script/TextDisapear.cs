using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDisapear : MonoBehaviour
{
    public Text message;

   
    
    void Start()
    {
        
        StartCoroutine("TextSet");
    }

    //���s���e 1�b�҂��Ă���e�L�X�g��\��
    IEnumerator TextSet()
    {
        yield return new WaitForSeconds(2.0f);
        message.text = "";
    }
}