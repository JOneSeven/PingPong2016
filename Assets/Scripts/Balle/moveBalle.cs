using UnityEngine;

public class moveBalle : MonoBehaviour {
	
	private float speed = MySingleton.Instance.getSpeedBalle();
	private float sx, sy;

	void Start () {
		sx = Random.Range (0, 2) == 0 ? -1 : 1;
		sy = Random.Range (0, 2) == 0 ? -1 : 1;
		GetComponent<Rigidbody2D>().velocity = new Vector2(speed * sx, speed * sy);
	}

	void Update(){
		//Vertical
		if (GetComponent<Rigidbody2D> ().velocity.x > 0) {
			if (GetComponent<Rigidbody2D> ().velocity.x < 3) {
				GetComponent<Rigidbody2D> ().velocity = new Vector2(GetComponent<Rigidbody2D> ().velocity.x + 0.01f, GetComponent<Rigidbody2D> ().velocity.y);
			}
		} else {
			if (GetComponent<Rigidbody2D> ().velocity.x > -3) {
				GetComponent<Rigidbody2D> ().velocity = new Vector2(GetComponent<Rigidbody2D> ().velocity.x - 0.01f, GetComponent<Rigidbody2D> ().velocity.y);
			}
		}

		//Horizontal
		if (GetComponent<Rigidbody2D> ().velocity.y > 0) {
			if (GetComponent<Rigidbody2D> ().velocity.y < 3) {
				GetComponent<Rigidbody2D> ().velocity = new Vector2(GetComponent<Rigidbody2D> ().velocity.x, GetComponent<Rigidbody2D> ().velocity.y + 0.01f);
			}
		} else {
			if (GetComponent<Rigidbody2D> ().velocity.y > -3) {
				GetComponent<Rigidbody2D> ().velocity = new Vector2(GetComponent<Rigidbody2D> ().velocity.x, GetComponent<Rigidbody2D> ().velocity.y - 0.01f);
			}
		}
	}
}