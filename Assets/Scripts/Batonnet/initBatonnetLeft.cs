using UnityEngine;

public class initBatonnetLeft : MonoBehaviour {

	void Start () {
		try {
			transform.position = MySingleton.Instance.getBl_position ();
			transform.localScale = MySingleton.Instance.getBl_scale ();
		} catch (System.Exception ex) {Debug.Log (ex);}
	}
}
