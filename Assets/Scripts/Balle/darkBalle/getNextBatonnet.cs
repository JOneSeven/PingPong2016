using UnityEngine;
using System.Collections;

public class getNextBatonnet : MonoBehaviour {

	private Vector2 otherBatonnet;

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.name == "batonnet_left") {
			otherBatonnet = GameObject.FindGameObjectWithTag ("batonnet_right").transform.position;
			GetComponent<Rigidbody2D>().velocity =  new Vector2(otherBatonnet.x, otherBatonnet.y);;
		} else if (col.gameObject.name == "batonnet_right") {
			otherBatonnet = GameObject.FindGameObjectWithTag ("batonnet_left").transform.position;
			GetComponent<Rigidbody2D>().velocity =  new Vector2(otherBatonnet.x, otherBatonnet.y);;
		}
	}
}