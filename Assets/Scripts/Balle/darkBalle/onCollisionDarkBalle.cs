using UnityEngine;
using System.Collections;

public class onCollisionDarkBalle : MonoBehaviour {
	
	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "batonnet_left") {
			MySingleton.Instance.setBl_scale (new Vector3(col.transform.localScale.x, col.transform.localScale.y - 0.20f, 0));
			col.transform.localScale = MySingleton.Instance.getBl_scale ();
			
			if ( !gameObject.GetComponent<AudioSource>().isPlaying ){
				gameObject.GetComponent<AudioSource>().Play();
			}
		}

		if (col.gameObject.tag == "batonnet_right") {
			MySingleton.Instance.setBr_scale (new Vector3(col.transform.localScale.x, col.transform.localScale.y - 0.20f, 0));
			col.transform.localScale = MySingleton.Instance.getBr_scale ();

			if ( !gameObject.GetComponent<AudioSource>().isPlaying ){
				gameObject.GetComponent<AudioSource>().Play();
			}
		}
	}
}