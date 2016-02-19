using UnityEngine;
using System.Collections;

public class limitZoneProjectile : MonoBehaviour {

	private Vector3 positionbordure_haut;
	private SpriteRenderer sp_cannon;
	private float hauteurCannon;

	void Start(){
		positionbordure_haut = GameObject.Find("bordure_haut").transform.position;

		//Prends l'objet pointé
		sp_cannon = GetComponent<SpriteRenderer> ();
		hauteurCannon = sp_cannon.bounds.size.y;
	}

	// Update is called once per frame
	void Update () {

		positionbordure_haut = GameObject.Find("bordure_haut").transform.position;

		// Calculer à chaque frame la largeur du cannon
		hauteurCannon = sp_cannon.bounds.size.y;

		//Bloque vers cote haut de l'écran
		if (transform.position.y - hauteurCannon / 2 > positionbordure_haut.y) {
			Destroy (gameObject);
		}
	}
}
