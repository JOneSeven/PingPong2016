using UnityEngine;

public class limitZoneCannon : MonoBehaviour {

	private Vector3 leftTopCorner;
	private Vector3 rightBottomCorner;

	private SpriteRenderer sp_cannon;

	private float largeurCannon;

	void Start(){
		leftTopCorner = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, 0));
		rightBottomCorner = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, 0));

		//Prends l'objet pointé
		sp_cannon = GetComponent<SpriteRenderer> ();
		largeurCannon = sp_cannon.bounds.size.x;
	}

	// Update is called once per frame
	void Update () {

		leftTopCorner = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, 0));
		rightBottomCorner = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, 0));

		// Calculer à chaque frame la largeur du cannon
		largeurCannon = sp_cannon.bounds.size.x;

		//Bloque vers cote gauche de l'écran
		if (transform.position.x - largeurCannon / 2 < leftTopCorner.x) {
			transform.position = new Vector3 (leftTopCorner.x + largeurCannon/2, transform.position.y, 0);		
		}

		//Bloque vers cote droit de l'écran
		if (transform.position.x + largeurCannon / 2 > rightBottomCorner.x) {
			transform.position = new Vector3 (rightBottomCorner.x - largeurCannon/2, transform.position.y, 0);		
		}
	}
}
