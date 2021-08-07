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

    //実行内容 1秒待ってからテキスト非表示
    IEnumerator TextSet()
    {
        yield return new WaitForSeconds(2.0f);
        message.text = "";
    }
}