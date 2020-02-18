using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideAndPlay : MonoBehaviour {

	private enum ParamType
	{
		Trigger, Bool
	}

	private BoxCollider bc;
	private MeshRenderer mr;

	[SerializeField]
	private string AnimationToPlay;

	[SerializeField]
	private ParamType ParameterType;

	[SerializeField]
	private float AnimationLength;

	[SerializeField]
	private GameObject NextObject;

	// Use this for initialization
	void Start () {
		mr = GetComponent<MeshRenderer>();
		bc = GetComponent<BoxCollider>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.CompareTag("A"))
		{

			for(int i = 0; i < transform.childCount; i++)
			{
				transform.GetChild(i).gameObject.SetActive(false);
			}
			mr.enabled = false;
			bc.enabled = false;

			var animator = collider.GetComponent<Animator>();
			switch (ParameterType)
			{
				case ParamType.Trigger:

					animator.SetTrigger(AnimationToPlay);
					break;
				case ParamType.Bool:

					animator.SetBool(AnimationToPlay, true);
					break;
			}

			Invoke("EnableNextObject", AnimationLength);
		}
	}

	private void EnableNextObject()
	{
		if(NextObject!=null)
		NextObject.SetActive(true);

		Destroy(this.gameObject);
	}
}
