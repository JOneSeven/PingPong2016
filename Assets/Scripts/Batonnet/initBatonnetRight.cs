using UnityEngine;

public class initBatonnetRight : MonoBehaviour {

	void Start () {
		try {
			transform.position = MySingleton.Instance.getBr_position ();
			transform.localScale = MySingleton.Instance.getBr_scale ();
		} catch (System.Exception ex) {Debug.Log (ex);}
	}
}
