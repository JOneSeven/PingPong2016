using UnityEngine;
using UnityEngine.UI;

public class onCollisionBalle : MonoBehaviour {
	
	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "batonnet_left" || col.gameObject.tag == "batonnet_right") {
			MySingleton.Instance.setScore(MySingleton.Instance.getScore() + 1);
			if ( !col.gameObject.GetComponent<AudioSource>().isPlaying ){
				col.gameObject.GetComponent<AudioSource>().Play();
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		col.name = col.name.Replace ("(Clone)", "");

		if (col.name == "speeder") {
			if (!col.GetComponent<AudioSource> ().isPlaying) {
				col.GetComponent<AudioSource> ().Play ();
			}
			if (MySingleton.Instance.getSpeedBalle () <= 10) {

				MySingleton.Instance.setSpeedBalle (MySingleton.Instance.getSpeedBalle () + 1f);
				Vector2 currentV = GetComponent<Rigidbody2D>().velocity;
				if (currentV.x < 0) {
					currentV = new Vector2 (-(currentV.x / currentV.x), currentV.y);
				} else {
					currentV = new Vector2 ((currentV.x / currentV.x), currentV.y);
				}

				if (currentV.y < 0) {
					currentV = new Vector2 (currentV.x, -(currentV.y / currentV.y));
				} else {
					currentV = new Vector2 (currentV.x, (currentV.y / currentV.y));
				}
				float speed = MySingleton.Instance.getSpeedBalle ();
				GetComponent<Rigidbody2D>().velocity = new Vector2(speed * currentV.x, speed * currentV.y);
				//GetComponent<Rigidbody2D>().AddForce(speed * GetComponent<Rigidbody2D>().velocity);(transform.position.y/transform.position.y)
			}
		}else if (col.name == "tourbillon") {
			
			if (!col.GetComponent<AudioSource> ().isPlaying) {
				col.GetComponent<AudioSource> ().Play ();
			}
			Invoke ("redirectionBalle2",0.5f);
			Invoke ("redirectionBalle2",1.5f);
			Invoke ("redirectionBalle2",2.5f);
			Invoke ("redirectionBalle2",3.5f);
			Invoke ("redirectionBalle2",4.0f);
			Invoke ("redirectionBalle2",4.5f);
			Invoke ("redirectionBalle2",5.5f);
			Invoke ("redirectionBalle2",6.0f);
			Invoke ("redirectionBalle2",6.5f);
		}else if (col.name == "4_directions") {
			if (!col.GetComponent<AudioSource> ().isPlaying) {
				col.GetComponent<AudioSource> ().Play ();
			}
			Invoke ("redirectionBalle",0.5f);
		}else if (col.name == "4x2_directions") {
			if (!col.GetComponent<AudioSource> ().isPlaying) {
				col.GetComponent<AudioSource> ().Play ();
			}
			Invoke ("redirectionBalle",0.5f);
			Invoke ("redirectionBalle",2.0f);
		}

		col.GetComponent<FadeOutAndDestroy> ().enabled = true;

		/*try {
			col.GetComponent<FadeOutAndDestroy> ().enabled = true;
		} catch (System.Exception ex) {
			Debug.Log (ex.Message);
			foreach (var item in col.GetComponentsInChildren<FadeOutAndDestroy> ()) {
				item.enabled = true;
			}
		}*/

		GameObject.FindGameObjectWithTag("Compteur").GetComponent<Text>().enabled = false;
	}

	public void redirectionBalle () {
		GetComponent<Rigidbody2D> ().velocity = randomDirection (MySingleton.Instance.getSpeedBalle());
	}

	public void redirectionBalle2 () {
		GetComponent<Rigidbody2D> ().velocity = randomDirection2 (MySingleton.Instance.getSpeedBalle());

	}

	public Vector2 randomDirection(float speed){
		float sx, sy;
		sx = Random.Range (0, 2) == 0 ? -1 : 1;
		sy = Random.Range (0, 2) == 0 ? -1 : 1;

		return new Vector2(speed * sx, speed * sy);
	}

	public Vector2 randomDirection2(float speed){
		float sx = 0, sy = 0;
		while (!(Mathf.Abs(sx - sy) > 0 && sx != 0 && sy != 0)) {
			sx = Random.Range (-3, 3);
			sy = Random.Range (-3, 3);
		}

		return new Vector2(speed * sx, speed * sy);
	}

}