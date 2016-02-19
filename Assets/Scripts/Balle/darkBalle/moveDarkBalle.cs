using UnityEngine;
using System.Collections;

public class moveDarkBalle : MonoBehaviour {
	
	public float speed= 1.0f;
	private float sx, sy;

	void Awake(){
		Invoke ("redirectionBalle",0.5f);
		Invoke ("redirectionBalle",1.0f);
		Invoke ("redirectionBalle",1.5f);/**/
	}


	// Use this for initialization
	void Start () {
		int rand = Random.Range (0, 2) == 0 ? 0 : 1;
		if (rand == 0) {
			sx = MySingleton.Instance.getBl_position ().x;
			sy = MySingleton.Instance.getBl_position ().y;
		} else {
			sx = MySingleton.Instance.getBr_position ().x;
			sy = MySingleton.Instance.getBr_position ().y;
		}

		GetComponent<Rigidbody2D>().velocity = new Vector2(speed * sx, speed * sy);
		//GetComponent<CircleCollider2D>().attachedRigidbody.AddForce(MySingleton.Instance.getCurrentForce());
	}

	public void redirectionBalle () {
		GetComponent<Rigidbody2D> ().velocity = randomDirection (MySingleton.Instance.getSpeedBalle());
	}

	public Vector2 randomDirection(float speed){
		float sx, sy;
		sx = Random.Range (0, 2) == 0 ? -1 : 1;
		sy = Random.Range (0, 2) == 0 ? -1 : 1;

		return new Vector2(speed * sx, speed * sy);
	}
}
