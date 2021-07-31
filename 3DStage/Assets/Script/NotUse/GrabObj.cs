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
				//�ꏊ�͉������������O�ɐi��Řb���Ǝ~�܂��B
				transform.position += velocity * Time.deltaTime;
			}
			//����͉��B
			if (Input.GetKey(KeyCode.S) && Input.GetMouseButton(0))
			{
				transform.position -= velocity * Time.deltaTime;
			}
			//����͉E�B
			if (Input.GetKey(KeyCode.D) && Input.GetMouseButton(0))
			{
				transform.position -= velocity * Time.deltaTime;
			}
			//����͍��B
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
			Debug.Log("�N��");
			GetComponent<Renderer>().material.color = Color.blue;
			Grable = true;
		}
		
		
	}
	private void OnTriggerExit(Collider other)
	{

		if (other.gameObject.CompareTag("Player"))
		{
			GetComponent<Renderer>().material.color = Color.red;
			Debug.Log("�E�o");
			Grable = false;
		}
	}
}
