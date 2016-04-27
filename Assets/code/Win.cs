using UnityEngine;
using System.Collections;

public class Win : MonoBehaviour{
	
	[SerializeField]
	private GameObject guimanager;

	private void OnTriggerEnter2D(Collider2D collider){

		string tag = collider.gameObject.tag;

		if(tag.ToLower() == "player"){
			var gui = guimanager.GetComponent<GUIManager>();
			gui.displayWin();
		}
	}
}