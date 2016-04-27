using UnityEngine;
using UnityEngine.Serialization;
using System;
using System.Collections;

// This does not attach to any game object.
// Extend to a specific kind of Item.

public interface Item{

	[SerializeField]
	string name{ get; set; }

}
