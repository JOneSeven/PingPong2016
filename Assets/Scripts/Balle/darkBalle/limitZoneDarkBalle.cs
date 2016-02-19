using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class limitZoneDarkBalle : MonoBehaviour {

	private Vector3 leftTopCorner;
	private Vector3 rightBottomCorner;
	private float rayonBalle;

	void Start(){
		leftTopCorner = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, 0));
		rightBottomCorner = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, 0));

		rayonBalle = GetComponent<CircleCollider2D> ().bounds.size.x;

	}

	// Update is called once per frame
	void Update () {

		rayonBalle = GetComponent<CircleCollider2D> ().bounds.size.x;

		//Bloque vers cote gauche de l'écran
		if (transform.position.x + rayonBalle / 2 < leftTopCorner.x) {
			Destroy(gameObject);
			SceneManager.LoadScene("GreenScene");
		}

		//Bloque vers cote droit de l'écran
		if (transform.position.x - rayonBalle / 2 > rightBottomCorner.x) {
			Destroy(gameObject);
			SceneManager.LoadScene("GreenScene");
		}
	}
}
