using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class MySingleton{

	private static MySingleton instance;
	private static readonly object padlock = new object();

	private float speedBalle, timeStartGame;
	private int life, score, bestScore, timeLimAD; // timeLimAD = Time Lime Auto-Destruction

	//Batonnet_left : bl
	private Vector3 bl_position, bl_scale;

	//Batonnet_right : br
	private Vector3 br_position, br_scale;

	private string currentScene;
	private float currentForce;



	public static MySingleton Instance{
		get{
			lock (padlock) {
				if (instance == null) {
					instance = new MySingleton ();
					Caching.CleanCache ();
				}
				return instance;
			}
		}
	}

	private MySingleton(){
		init();
	}

	public void init(){
		currentScene = "";
		currentForce = 1f;

		life = 3;
		speedBalle = 4;
		score = 0;
		timeStartGame = Time.fixedTime;

		//Batonnet_left : bl
		bl_position = new Vector3 (-8.2f, 0, 0);
		bl_scale = new Vector3 (1, 0.8f, 1);

		//Batonnet_right : br
		br_position = new Vector3 (8.2f, 0, 0);
		br_scale = new Vector3 (1, 0.8f, 1);
	}

	public int getScore(){
		return score;
	}

	public void setScore(int s){
		score = s;
	}

	public int getLife(){
		return life;
	}

	public int getTimeLimAD(){
		return timeLimAD;
	}

	public void setTimeLimAD(int tlad){
		timeLimAD = tlad;
	}

	public void setLife(int l){
		life = l;
	}

	public float getTimeStartGame(){
		return timeStartGame;
	}

	public void setTimeStartGame(float tsg){
		timeStartGame = tsg;
	}

	public float getSpeedBalle(){
		return speedBalle;
	}

	public void setSpeedBalle(float s){
		speedBalle = s;
	}
		
	public string getCurrentScene(){
		return currentScene;
	}

	public void setCurrentScene(string cs){
		currentScene = cs;
	}

	public float getCurrentForce(){
		return currentForce;
	}

	public void setCurrentForce(float f){
		currentForce = f;
	}

	//Batonnet_left : bl
	public Vector3 getBl_position(){
		return bl_position;
	}

	public void setBl_position(Vector3 v){
		bl_position = v;
	}

	public Vector3 getBl_scale(){
		return bl_scale;
	}

	public void setBl_scale(Vector3 v){
		bl_scale = v;
	}

	//Batonnet_right : br
	public Vector3 getBr_position(){
		return br_position;
	}

	public void setBr_position(Vector3 v){
		br_position = v;
	}

	public Vector3 getBr_scale(){
		return br_scale;
	}

	public void setBr_scale(Vector3 v){
		br_scale = v;
	}
}