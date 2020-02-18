using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class KeyBindingAction : MonoBehaviour, IPointerClickHandler
{

	public static KeyBindingAction SelectedKeyBinding = null;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (SelectedKeyBinding != null)
		{
			SelectedKeyBinding.GetComponent<RawImage>().color = Color.white;
		}
		SelectedKeyBinding = this;
		SelectedKeyBinding.GetComponent<RawImage>().color = Color.green;
	}


}
