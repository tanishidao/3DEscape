using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObj : MonoBehaviour
{
    public float speed = 4.0f;
	private bool Grable = false;
	

    private void Start()
    {
		GetComponent<Renderer>().material.color = Color.red;
		
	}

    private void FixedUpdate()
    {
		
		Vector3 velocity = this.transform.rotation * new Vector3(speed, 0, 0);

		if (Grable == true)
       {
			if (Input.GetKey(KeyCode.W) && Input.GetMouseButton(0))
			{
				//場所は押した分だけ前に進んで話すと止まるよ。
				transform.position += velocity * Time.deltaTime;
			}
			//これは下。
			if (Input.GetKey(KeyCode.S) && Input.GetMouseButton(0))
			{
				transform.position -= velocity * Time.deltaTime;
			}
			//これは右。
			if (Input.GetKey(KeyCode.D) && Input.GetMouseButton(0))
			{
				transform.position -= velocity * Time.deltaTime;
			}
			//これは左。
			if (Input.GetKey(KeyCode.A) && Input.GetMouseButton(0))
			{
				transform.position += velocity * Time.deltaTime;
			}
		}
	
					    }
	private void OnTriggerStay(Collider other)
	{
		
		if(other.gameObject.CompareTag("Player"))
        {
			Debug.Log("侵入");
			GetComponent<Renderer>().material.color = Color.blue;
			Grable = true;
		}
		
		
	}
	private void OnTriggerExit(Collider other)
	{

		if (other.gameObject.CompareTag("Player"))
		{
			GetComponent<Renderer>().material.color = Color.red;
			Debug.Log("脱出");
			Grable = false;
		}
	}
}
