using UnityEngine;

public class limitZoneBatonnet : MonoBehaviour {

	private SpriteRenderer sp_batonnet;
	private float HauteurBatonnet;
	private Vector3 positionbordure_haut, positionbordure_bas;

	void Start(){
		//Prends l'objet pointé
		sp_batonnet = GetComponent<SpriteRenderer> ();
		HauteurBatonnet = sp_batonnet.bounds.size.y;
		positionbordure_haut = GameObject.FindGameObjectWithTag("bordure_haut").transform.position;
		positionbordure_bas = GameObject.FindGameObjectWithTag("bordure_bas").transform.position;
	}

	// Update is called once per frame
	void Update () {

		// Calculer à chaque frame la taille du batonnet
		HauteurBatonnet = sp_batonnet.bounds.size.y;

		//Bloque vers cote haut de l'écran
		if (transform.position.y + HauteurBatonnet / 2 > positionbordure_haut.y) { //leftTopCorner
			transform.position = new Vector3 (transform.position.x, positionbordure_haut.y - HauteurBatonnet/2, 0);		
		}

		//Bloque vers cote bas de l'écran
		if (transform.position.y - HauteurBatonnet / 2 < positionbordure_bas.y) {
			transform.position = new Vector3 (transform.position.x, positionbordure_bas.y + HauteurBatonnet/2, 0);		
		}
	}
}
