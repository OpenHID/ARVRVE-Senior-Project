﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearAllCommands : MonoBehaviour {

	public Button clearButton;
	public Transform parentTransform;
	public GameObject player;
	Vector3 originalPos;

	// Use this for initialization
	void Start () {

		Button clearBtn = clearButton.GetComponent<Button>();
		clearButton.onClick.AddListener(Clear);
		originalPos = player.transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Clear() {

		//Delete all of the commands in the solution panel
		foreach (Transform child in parentTransform)
		{
			if (child.name != "Command") //Do not destroy original prefab
			{
				Destroy (child.gameObject);
			}
		}

		//Move player to its original position
		player.transform.position = originalPos;

	}
}