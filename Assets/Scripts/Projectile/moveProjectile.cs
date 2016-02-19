using UnityEngine;
using System.Collections;

public class moveProjectile : MonoBehaviour {
	public float speed=0.3f;
	private Vector3 rightTop;
	public float portée = 10f;
	private float i = 0f;
	// Use this for initialization
	void Start () {
		rightTop = Camera.main.ViewportToWorldPoint (new Vector3 (1, 1, 0));
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		transform.position = new Vector3 (transform.position.x, transform.position.y + speed, 0);

		if(transform.position.x > rightTop.x || i>portée){
			Destroy(gameObject);
			i = 0f;
		}
		i = i + 0.1f;
	}
}
