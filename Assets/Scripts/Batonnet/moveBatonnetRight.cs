using UnityEngine;

public class moveBatonnetRight : MonoBehaviour {

	private Vector2 mouvement2D; // stockage mouvement

	void Update() {
		mouvement2D = new Vector2 (0, Input.GetAxis("Horizontal") * 0.5f);
		transform.Translate (mouvement2D);
	}
}
