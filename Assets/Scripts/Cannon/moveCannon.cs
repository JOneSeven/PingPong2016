using UnityEngine;

public class moveCannon : MonoBehaviour {

	private Vector2 mouvement2D; // stockage mouvement
	private float inputX;

	void Update() {
		inputX = Input.GetAxis ("Horizontal");
		mouvement2D = new Vector2 (0.5f * inputX, 0);
		transform.Translate (mouvement2D);
	}
}
