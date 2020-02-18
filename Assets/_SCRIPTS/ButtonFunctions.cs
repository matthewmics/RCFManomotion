using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour {

	public GameObject Loading;
	private string rtm;
	// Use this for initialization
	void Start () {
		rtm = PlayerPrefs.GetString("return_to_menu");
	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetKeyUp(KeyCode.R))
		{
			Loading.SetActive(true);
			SceneManager.LoadScene("MainMenu");
		}

		foreach (KeyCode kcode in System.Enum.GetValues(typeof(KeyCode)))
		{
			if (Input.GetKeyDown(kcode) && kcode.ToString().Equals(rtm))
			{
				Loading.SetActive(true);
				SceneManager.LoadScene("MainMenu");
			}
		}

	}
}
