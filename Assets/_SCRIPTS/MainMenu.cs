using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public GameObject Loading;
	GameObject currentSelected;
	int selectedIndex;
	int totalSelection;
	bool canSelect = true;

	private string sfm;

	// Use this for initialization
	void Start () {
		totalSelection = transform.childCount;
		ChangeSelection(0);

		sfm = PlayerPrefs.GetString("select_from_menu");
	}

	void ChangeSelection(int index)
	{
		if(currentSelected!=null)
		currentSelected.GetComponent<RawImage>().color = Color.white;

		currentSelected = transform.GetChild(index).gameObject;
		currentSelected.GetComponent<RawImage>().color = Color.green;
		selectedIndex = index;
	}
	
	// Update is called once per frame
	void Update () {
		var y = Input.GetAxisRaw("Vertical");
		//Debug.Log(y);
		if (canSelect)
		{
			canSelect = false;
			//y *= -1;
			int selection = selectedIndex + (int)y;
			if (y == 1)
			{
				ChangeSelection(!(selection > totalSelection-1) ? selection : 0);
			}
			else if(y == -1)
			{
				ChangeSelection(!(selection < 0) ? selection : totalSelection - 1);
			}

		}

		if(y == 0)
		{
			canSelect = true;
		}


		if (Input.GetKeyUp(KeyCode.E))
		{
			Loading.SetActive(true);
			SceneManager.LoadScene(currentSelected.name);
		}

		foreach (KeyCode kcode in System.Enum.GetValues(typeof(KeyCode)))
		{
			if (Input.GetKeyDown(kcode) && kcode.ToString().Equals(sfm))
			{
				Loading.SetActive(true);
				SceneManager.LoadScene(currentSelected.name);
			}
		}
	}
}
