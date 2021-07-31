using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveItem : MonoBehaviour
{
    public GameObject player;
    public GameObject item;

    LayerMask mask;
    GameObject item1;
    RaycastHit Hit;

    CubeScript2 sc_item1;

    private void Start()
    {
        item1 = Instantiate(item, transform.position, transform.rotation);
        sc_item1 = item1.GetComponent<CubeScript2>();
        mask = ~(1 << 8 | 1 << 9);

    }
    void Update()
    {
        if(Physics.Raycast(player.transform.position,player.transform.transform.forward,out Hit, Mathf.Infinity,mask))
        {
            sc_item1.ray = true;
            Debug.DrawRay(player.transform.position, player.transform.transform.forward * Hit.distance, Color.yellow);
            item1.transform.position = Hit.point;
            item1.transform.rotation = Quaternion.FromToRotation(item.transform.up, Hit.normal);
            item1.transform.position += item1.transform.localScale.y / 1.98f * Hit.normal;
        }
        else
        {
            sc_item1.ray = false;
        }
    }
}
