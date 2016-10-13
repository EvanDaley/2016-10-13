﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CycleButton : MonoBehaviour {

	private Text buttonText;
	public List<ButtonMode> modes;
	private int curMode = 0;

	void Awake () 
	{
		buttonText = GetComponentInChildren<Text> ();
	}

	public void PressedButton()
	{
		State += 1;
	}

	public int State
	{
		get{ return curMode; }
		set
		{
			curMode = value % modes.Count;
			buttonText.text = modes [curMode].displayText;
		}
	}
}

[System.Serializable]
public class ButtonMode
{
	public string uniqueID;
	public string displayText;
	public Sprite image;	// image use not implemented
}