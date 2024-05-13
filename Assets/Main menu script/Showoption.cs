using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Showoption : MonoBehaviour
{
	[SerializeField] private GameObject dropDown;
	public void ToggleDropDownVisibility()
	{
		dropDown.SetActive(!dropDown.activeSelf);
		
	}


	public void DropdownValueChanged(int value)
	{
		if (value == 0) {
			GameManager.startHealthInit = 3;
		}else if(value == 1)
		{
			GameManager.startHealthInit =6;
		}
		else if (value == 2)
		{
			GameManager.startHealthInit = 10;
		}

	}
}
