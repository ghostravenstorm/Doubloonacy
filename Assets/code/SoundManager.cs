using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour{

	//[SerializeField]
	//private GameObject entityList;

	[SerializeField]
	private bool musicOn;

	/// Drag Game Objects with Audio Source components onto these in the inspector

	[SerializeField]
	private AudioSource ambientMusic;

	[SerializeField]
	private AudioSource combatMusic;

	[SerializeField]
	private List<AudioSource> skeletonSounds;

	[SerializeField]
	private List<AudioSource> boneExplosion;

	[SerializeField]
	private List<AudioSource> footstep;

	[SerializeField]
	private List<AudioSource> swordSwish;

	[SerializeField]
	private List<AudioSource> coinDrop;

	[SerializeField]
	private List<AudioSource> coinPickup;

	private List<AudioSource> musicLib = new List<AudioSource>();

	private readonly System.Random random = new System.Random();

	public void Start(){
		if(!musicOn) return;
		
		musicLib.Add(ambientMusic);
		musicLib.Add(combatMusic);

		setAmbientMusic();
	}

	public void setAmbientMusic(){
		if(!musicOn) return;

		pauseAllMusic();
		ambientMusic.Play();
	}

	public void setCombatMusic(){
		if(!musicOn) return;

		pauseAllMusic();
		combatMusic.Play();
	}

	public bool isAmbientMusicPlaying(){

		if(!musicOn) return false;
		return ambientMusic.isPlaying;
	}

	public bool isCombatMusicPlaying(){

		if(!musicOn) return false;
		return combatMusic.isPlaying;
	}

	public void pauseAllMusic(){
		if(!musicOn) return;

		musicLib.ForEach(delegate(AudioSource track){
			track.Pause();
		});
	}

	// TODO: Calculate if player is near enemy to enable combat music
	/*
	private GameObject getNearestEntityToPlayer(){

		int children = entityList.transform.childCount;
		GameObject currentChild;
		GameObject nearestChild;

		if(entityList.transform.childCount == 0)
			return null;

		nearestChild = entityList.transform.GetChild(0).gameObject;

		// Exception: Index out of bounds once all child objects are destroyed
		for(int i = 0; i < children; i++){
			currentChild = entityList.transform.GetChild(i).gameObject;

			// Assign current to nearest if its closer to the player
			if(GameManager.getDist(this.gameObject, currentChild) < GameManager.getDist(this.gameObject, nearestChild)){
				nearestChild = currentChild;
			}
		}

		return nearestChild;
	}
	*/

	// Return a random sound bite.
	public AudioSource getSkeletonSound(){
		int r = random.Next(0, skeletonSounds.Count);
		return skeletonSounds[r];
	}

	public AudioSource getBoneExplosion(){
		int r = random.Next(0, boneExplosion.Count);
		return boneExplosion[r];
	}

	public AudioSource getfootstep(){
		int r = random.Next(0, footstep.Count);
		return footstep[r];
	}

	public AudioSource getSwordSwish(){
		int r = random.Next(0, swordSwish.Count);
		return swordSwish[r];
	}

	public AudioSource getCoinDrop(){
		int r = random.Next(0, coinDrop.Count);
		return coinDrop[r];
	}

	public AudioSource getCoinPickup(){
		int r = random.Next(0, coinPickup.Count);
		return coinPickup[r];
	}
}