using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour{

	public static readonly float DIST_SCALE = 5.0f;
	public static readonly float MOVE_SCALE = 5.0f;

	[SerializeField]
	private GUIManager guimanager;

	[SerializeField]
	private PlayerController2D playerController;

	public static float getDist(GameObject target, GameObject current){

		float value = Vector3.Distance(target.transform.position, current.transform.position);
		//Debug.Log("Distance between " + a.name + " and " + b.name + ": " + value);

		return value;
	}

	public static void WinState(){

	}

}