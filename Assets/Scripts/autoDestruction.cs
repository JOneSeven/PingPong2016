using UnityEngine;

public class autoDestruction : MonoBehaviour {
	void Start () {
		Destroy (gameObject, MySingleton.Instance.getTimeLimAD());
	}
}
