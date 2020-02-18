using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KeyBinding : MonoBehaviour {

	public GameObject ErrorMsg;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		foreach (KeyCode kcode in System.Enum.GetValues(typeof(KeyCode)))
		{
			if (Input.GetKeyDown(kcode))
			{
				if(KeyBindingAction.SelectedKeyBinding != null)
				{
					KeyBindingAction.SelectedKeyBinding.transform.Find("value").GetComponent<Text>().text = kcode.ToString();
					KeyBindingAction.SelectedKeyBinding.GetComponent<RawImage>().color = Color.white;
					KeyBindingAction.SelectedKeyBinding = null;
					Debug.Log(kcode);
				}
			}
		}
	}

	public void SaveBinding()
	{
		var bindings = GameObject.FindObjectsOfType<KeyBindingAction>();

		for (int i = 0; i < bindings.Length; i++)
		{
			var obj = bindings[i];
			string val = obj.transform.Find("value").GetComponent<Text>().text;

			if (string.IsNullOrEmpty(val))
			{
				ErrorMsg.SetActive(true);
				return;
			}
			else
			{
				PlayerPrefs.SetString(obj.name, val);
			}
		}

		SceneManager.LoadScene("MainMenu");
	}
}
