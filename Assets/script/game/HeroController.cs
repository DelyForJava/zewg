using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour 
{

	// Use this for initialization
	private void callback()
	{
		Debug.Log("I am in timer pool");
	}

	void Start () 
	{
		Timer.In(10,callback,20);
	}
	
	// Update is called once per frame
	void Update () 
	{		
		if(_moving)
		{
			Vector3 jp = Data.JoystickPosition;
			Vector3 hm = new Vector3(jp.x,0,jp.y);
			transform.position += (hm * 0.1f * Time.deltaTime);
			Vector3 target = transform.position + hm;
			transform.LookAt (target);
		}
	}

	void LateUpdate()
	{
		Vector3 jp = Data.JoystickPosition;
		Vector3 hm = new Vector3(jp.x,0,jp.y);
		mCamera.transform.position += (hm * 0.1f * Time.deltaTime);
	}

	public GameObject mCamera;

	private bool _moving = true;

}