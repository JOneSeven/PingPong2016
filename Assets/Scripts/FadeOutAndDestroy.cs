using UnityEngine;
using System.Collections;

public class FadeOutAndDestroy : MonoBehaviour {
	void Start(){
		if (GetComponent<Animator> () != null) {
			GetComponent<Animator> ().enabled = false;
		}
	}

	void Update(){
		try {
			Color cl = GetComponent<SpriteRenderer>().color;
			cl.a -= 0.1f;
			GetComponent<SpriteRenderer>().color = cl;
			if(cl.a<0){
				Destroy(gameObject, 2f);
			}
		} catch(System.Exception ex) {
			Debug.Log ("Normal erreur:: " + ex.Message);
			Color cl;
			foreach (SpriteRenderer item in GetComponentsInChildren<SpriteRenderer>()) {
				cl = item.color;
				cl.a -= 0.1f;
				item.color = cl;
				if(cl.a<0){
					Destroy(gameObject, 2f);
				}
			}
		}
	}
}
