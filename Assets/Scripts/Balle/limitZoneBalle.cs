using UnityEngine;

public class limitZoneBalle : MonoBehaviour {

	private Vector3 leftTopCorner;
	private Vector3 rightBottomCorner;

	private CircleCollider2D sp_balle;
	private float widthBatonnet;

	void Start(){
		leftTopCorner = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, 0));
		rightBottomCorner = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, 0));

		//Prends l'objet pointé
		sp_balle = GetComponent<CircleCollider2D> ();
		widthBatonnet = sp_balle.bounds.size.x;
	}

	void Update () {

		widthBatonnet = sp_balle.bounds.size.x;

		//Bloque vers cote gauche de l'écran
		if (transform.position.x + widthBatonnet / 2 < leftTopCorner.x) {
			Destroy(gameObject);
			MySingleton.Instance.setLife (MySingleton.Instance.getLife() - 1);
		}

		//Bloque vers cote droit de l'écran
		if (transform.position.x - widthBatonnet / 2 > rightBottomCorner.x) {
			Destroy(gameObject);
			MySingleton.Instance.setLife (MySingleton.Instance.getLife() - 1);
		}
	}
}