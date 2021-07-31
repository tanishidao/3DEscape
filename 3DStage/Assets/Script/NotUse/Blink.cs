using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blink : MonoBehaviour
{
    public float speed = 1.0f;
    

    private Text text;
    private Image image;
    private float time;



    private enum ObjType
    {
        TEXT,
        IMAGE
    }
    private ObjType thisObjtype = ObjType.TEXT;

    private void Start()
    {
        if (this.gameObject.GetComponent<Image>())
        {
            thisObjtype = ObjType.IMAGE;
            image = this.gameObject.GetComponent<Image>();
        }
        else if (this.gameObject.GetComponent<Text>())
        {
            thisObjtype = ObjType.TEXT;
            text = this.gameObject.GetComponent<Text>();
        }
    }
    void Update()
    {
        if (thisObjtype == ObjType.IMAGE)
        {
            image.color = GetAlphaColor(image.color);
        }
        else if(thisObjtype == ObjType.TEXT)
        {
            text.color = GetAlphaColor(text.color);
        }
    }
    Color GetAlphaColor(Color color)
    {
        time += Time.deltaTime * 5.0f * speed;
        color.a = Mathf.Sin(time) * 0.5f + 0.5f;
        return color;
    }
}
