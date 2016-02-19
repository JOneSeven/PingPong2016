using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;

public class GameController : MonoBehaviour {

	public GameObject balle, darkBalle, directions_4, directions_4x2, speeder, tourbillon, AlertSong;
	private bool pauseGame = false, showGUI = false, Pause_isAxisInUse = false;
	private Text Score, Compteur;
	private float time; 
	private int count, timeLimitOP, timeLimitOP_2;
	private Score sc = new Score();
	private GameObject ButtonReplay, ButtonStop, BestScore, TheScore, MyScore;

	void Start () {
		count = 0;
		MySingleton.Instance.setCurrentScene(SceneManager.GetActiveScene().name);
		if (MySingleton.Instance.getCurrentScene () == "GreenScene" || MySingleton.Instance.getCurrentScene () == "DarkScene") {
			Score = GameObject.FindGameObjectWithTag ("Score").GetComponent<Text> ();
		}

		if (MySingleton.Instance.getCurrentScene () == "Scene_End") {
			ButtonReplay = GameObject.FindGameObjectWithTag ("ButtonReplay");
			ButtonStop = GameObject.FindGameObjectWithTag ("ButtonStop");
			BestScore = GameObject.FindGameObjectWithTag ("BestScore");
			TheScore = GameObject.FindGameObjectWithTag ("TheScore");

			ButtonReplay.SetActive(false);
			ButtonStop.SetActive(false);
			BestScore.SetActive(false);
			TheScore.SetActive(false);
		}
	}

	public void itemLifeRender(){
		if (MySingleton.Instance.getLife() == 2) {
			try{GameObject.FindGameObjectWithTag ("itemLife1").GetComponent<FadeOutAndDestroy> ().enabled = true;}catch{}
		} else if (MySingleton.Instance.getLife () == 1) {
			try{GameObject.FindGameObjectWithTag ("itemLife1").GetComponent<FadeOutAndDestroy> ().enabled = true;}catch{}

			try{GameObject.FindGameObjectWithTag ("itemLife2").GetComponent<FadeOutAndDestroy> ().enabled = true;}catch{}
		}
	}

	public void lanceurBalle () {
		Instantiate (balle);
	}

	public void lanceurDarkBalle () {
		Instantiate (darkBalle);
	}

	private void defTimeLimitOP(){
		// Définir le temps limite pour les objects pertubateurs
		timeLimitOP = Random.Range (3, 6);
		MySingleton.Instance.setTimeLimAD (timeLimitOP);

		timeLimitOP_2 = timeLimitOP;
	}

	public void lanceurObjetPertubateur () {
		
		if (GameObject.FindGameObjectsWithTag ("objetsPertubateurs").Length < 1) {

			GameObject.FindGameObjectWithTag("Compteur").GetComponent<Text>().enabled = true;
			int rand = Random.Range (0, 12);
			Vector3 randPosition = new Vector3((Random.Range (0, 100))/100f*7, (Random.Range (0, 100))/100f*3, 0);

			// Définir quel object qui sera appliqué
			if (rand == 0) {
				defTimeLimitOP ();
				Instantiate (speeder, randPosition, Quaternion.identity);
			} else if (rand == 3) {
				defTimeLimitOP ();
				Instantiate (tourbillon, randPosition, Quaternion.identity);
			} else if (rand == 6) {
				defTimeLimitOP ();
				Instantiate (directions_4, randPosition, Quaternion.identity);
			} else if (rand == 9) {
				defTimeLimitOP ();
				Instantiate (directions_4x2, randPosition, Quaternion.identity);
			}
		}
	}

	public void goToScene_Menu(){
		SceneManager.LoadScene("Scene_Menu");﻿
	}

	public void goToGreenScene(){
		GameObject GOtmpL = GameObject.FindGameObjectWithTag ("batonnet_left"); 
		GameObject GOtmpR = GameObject.FindGameObjectWithTag ("batonnet_right"); 

		try {
			MySingleton.Instance.setBl_position (GOtmpL.transform.position);
			MySingleton.Instance.setBl_scale (GOtmpL.transform.localScale);

			MySingleton.Instance.setBr_position (GOtmpR.transform.position);
			MySingleton.Instance.setBr_scale (GOtmpR.transform.localScale);
		} catch (System.Exception ex) {Debug.Log(ex.Message);}


		SceneManager.LoadScene("GreenScene");﻿
		itemLifeRender ();
		Invoke ("lanceurBalle", 0.5f);
	}

	public void goToDarkScene(){
		GameObject GOtmpL = GameObject.FindGameObjectWithTag ("batonnet_left"); 
		GameObject GOtmpR = GameObject.FindGameObjectWithTag ("batonnet_right"); 
		MySingleton.Instance.setBl_position (GOtmpL.transform.position);
		MySingleton.Instance.setBl_scale (GOtmpL.transform.localScale);

		MySingleton.Instance.setBr_position (GOtmpR.transform.position);
		MySingleton.Instance.setBr_scale (GOtmpR.transform.localScale);

		SceneManager.LoadScene("DarkScene");﻿
		itemLifeRender ();

		Invoke ("lanceurDarkBalle", 0.5f);
	}

	public void goToScene_End(){
		SceneManager.LoadScene("Scene_End");﻿
	}

	public void gameOver(){
		string fileName = "pond.sav";
		string resultat = "";

		DataScore dsc = new DataScore();
		sc.score = MySingleton.Instance.getScore();

		try {
			if (!System.IO.File.Exists (fileName)) {
				TextWriter writer = new StreamWriter (fileName);
				sc.fbs = true;
				resultat = JsonUtility.ToJson(sc);
				writer.Write (resultat);
				writer.Close ();
				BestScore.SetActive(true);
				BestScore.GetComponent<Text>().text = "Nouveau Score: " + MySingleton.Instance.getScore() + " (" +  sc.playerName + ")";

			} else {
				// Lire le fichier avec les éventuels résultats existants
				TextReader reader = new StreamReader (fileName);
				string line;
				while (true){
					
					// lecture de la ligne
					line = reader.ReadLine();

					// si la ligne est vide on arrête
					if (line == null)
						break;

					// on transforme en object Score pour l'inserer dans la liste dsc
					dsc.add(JsonUtility.FromJson<Score>(line));
				}
				reader.Close();

				//Rajouter le dernier score
				dsc.add(sc);

				// trier l'arraylist
				dsc.sortByScore();

				//Garder les 10 permiers résultats
				dsc.reduce(10);

				// Rendre les résultats en Json
				resultat = dsc.toJson();

				// Recupérer l'ancien meilleur score
				Score old = dsc.getFBS();

				TextWriter writer = new StreamWriter (fileName);
				writer.Write (resultat);
				writer.Close ();
				BestScore.SetActive(true);
				BestScore.GetComponent<Text>().text = "Meilleur Score: " + old.score + " (" +  old.playerName + ")";
				TheScore.SetActive(true);
				TheScore.GetComponent<Text>().text = "Score: " + MySingleton.Instance.getScore() + " (" +  sc.playerName + ")";
			}

		} catch (System.Exception ex) {Debug.Log (ex.Message);}
	}

	public void endEdit(string e){
		if(e.Trim().Length>0){

			sc.playerName = e;
			GameObject.FindGameObjectWithTag ("MyInputField").SetActive (false);

			ButtonReplay.SetActive(true);
			ButtonStop.SetActive(true);

			gameOver ();
		}
	}

	void Update () {
		
		// Pause game
		if (MySingleton.Instance.getCurrentScene() == "GreenScene" || MySingleton.Instance.getCurrentScene() == "DarkScene") {
			if (Input.GetAxisRaw("Pause") != 0 ){
				if (Pause_isAxisInUse == false) {
					pauseGame = !pauseGame;

					if (pauseGame) {
						Time.timeScale = 0;
						pauseGame = true;
						showGUI = true;
					} else {
						Time.timeScale = 1;
						pauseGame = false;
						showGUI = false;
					}
					Pause_isAxisInUse = true;

				}
			}

			if( Input.GetAxisRaw("Pause") == 0){
				Pause_isAxisInUse = false;
			}

			if (showGUI) {
				GameObject.FindGameObjectWithTag ("PauseText").GetComponent<Text> ().enabled = true;
			} else {
				GameObject.FindGameObjectWithTag ("PauseText").GetComponent<Text> ().enabled = false;
			}

			// Aller à la scene finale si je n'ai plus de vie
			if (MySingleton.Instance.getLife() == 0) {
				goToScene_End ();﻿
			}
			
			if (MySingleton.Instance.getCurrentScene() == "GreenScene") {
				
				if (Compteur == null && GameObject.FindGameObjectWithTag("Compteur") != null)
					Compteur = GameObject.FindGameObjectWithTag("Compteur").GetComponent<Text>();

				// Tant que je suis a la scène verte, compte mon score
				Score.text = "Score: " + MySingleton.Instance.getScore();
			}

			if (MySingleton.Instance.getCurrentScene() == "DarkScene") {

				if (GameObject.FindGameObjectsWithTag ("balle").Length == 0) {
					lanceurDarkBalle ();
				}

				// Si l'une des batonnets est détruit alors le jeu est terminé
				if ((System.Math.Round(MySingleton.Instance.getBl_scale().y, 2) <= 0.0) || (System.Math.Round(MySingleton.Instance.getBr_scale().y, 2) <= 0.0)) {
					goToScene_End ();
				}
			}
		}
	}

	void FixedUpdate(){

		if (MySingleton.Instance.getCurrentScene()  == "GreenScene") {
			itemLifeRender ();
			time = Time.fixedTime - MySingleton.Instance.getTimeStartGame();

			if (time.ToString ().IndexOf (".") == -1) {
				
				if (GameObject.FindGameObjectsWithTag ("balle").Length > 0) {

					count = (int)time;

					// Chaque 15 seconde du jeu, je lance un élément pertubateur sur la scène
					if (count != 0 && (count % 5 == 0)) {
						lanceurObjetPertubateur();
					}

					if (timeLimitOP_2 > 0) {
						Compteur.text = timeLimitOP_2 + "s";
						timeLimitOP_2--;
					} else {
						if(Compteur != null)
							Compteur.text = "";
					}

					// Chaque 50 seconde du jeu, s'il n'y a pas d'éléments pertubateurs, je lance la scène sombre 
					if (count != 0 && (count % 50 == 0) && GameObject.FindGameObjectsWithTag ("objetsPertubateurs").Length < 1) {
						Instantiate (AlertSong);

						Invoke ("goToDarkScene", 4f);
						count -= 3;
					}

				} else {
					Invoke ("lanceurBalle", 0.3f);
				}
			}
		}
	}
}