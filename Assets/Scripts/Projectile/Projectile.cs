using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	
	void Start() {
		GetComponent<AudioSource> ().Play ();
	}
}