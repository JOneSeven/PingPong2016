using UnityEngine;

public class shotCannon : MonoBehaviour {

	public GameObject projectile;
	private bool Fire_isAxisInUse = false;

	void Update () {

		if(Input.GetAxisRaw("Fire") != 0){
			if(Fire_isAxisInUse == false){
				Instantiate (projectile, transform.position, transform.rotation);
				Fire_isAxisInUse = true;
			}
		}

		if(Input.GetAxisRaw("Fire") == 0){
			Fire_isAxisInUse = false;
		}   
	}
}
