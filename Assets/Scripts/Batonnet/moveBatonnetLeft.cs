using UnityEngine;

public class moveBatonnetLeft : MonoBehaviour {

	private Vector2 mouvement2D;

	void Update() {
		mouvement2D = new Vector2 (0, Input.GetAxis ("Vertical") * 0.5f);
		transform.Translate (mouvement2D);
	}
}
