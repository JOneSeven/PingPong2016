using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class onCollisionProjectile : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "balle") {
			col.gameObject.GetComponent<FadeOutAndDestroy> ().enabled = true;
			MySingleton.Instance.setScore(MySingleton.Instance.getScore() + 5);
			Destroy (col.gameObject);
			SceneManager.LoadScene("GreenScene");
		}
	}

	void goToGreenScene(){
		SceneManager.LoadScene("GreenScene");
	}
}