using UnityEngine;
using System.Collections;

public class mainMenuLoad: MonoBehaviour {
	//This function loads the scene with the game on it. 
	//Relies on the build settings in the project folder
	public void LoadScene(string level){ 
		Debug.Log("Loading level: " + level);
		Application.LoadLevel(level);
	}

	//Quits game
	public void QuitGame(){
		Debug.Log("Quit pressed");
		Application.Quit ();	
	}

}
