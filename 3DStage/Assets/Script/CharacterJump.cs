using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJump : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 movedirection;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if(controller.isGrounded)
        {
            if(Input.GetMouseButtonDown(0))
            {
                movedirection.y = 20;
            }
        }
        movedirection.y -= 10 * Time.deltaTime; //èdóÕåvéZ
        controller.Move(movedirection * Time.deltaTime);
    }
}
