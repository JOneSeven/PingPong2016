using System;
using System.Collections;
using UnityEngine;

public class DataScore {
	private ArrayList data = new ArrayList();

	public int add (Score sc){
		int indexFBS = getIndexFBS ();

		if (indexFBS > -1 && ((Score)data[indexFBS]).score < sc.score) {
			if (((Score)data[indexFBS]).playerName == sc.playerName) {
				//Nouveau record personnel
				((Score)data[indexFBS]).score = sc.score;
				return 0;
			} else {
				//Nouveau challeger
				((Score)data[indexFBS]).fbs = false;
				sc.fbs = true;
				data.Add (sc);
				return 1;
			}
		} else {
			data.Add (sc);
			return -1;
		}
	}

	public void sortByScore(){
		int i = 0;
		Score tmp1;
		while (i < data.Count - 1) {
			tmp1 = (Score)data [i];

			if (tmp1.score < ((Score)data [i + 1]).score) {
				data [i] = (Score)data [i + 1];
				data [i + 1] = tmp1;
				i = 0;
			} else if (tmp1.score == ((Score)data [i + 1]).score) {
				if (((Score)data [i + 1]).fbs) {
					data [i] = (Score)data [i + 1];
					data [i + 1] = tmp1;
					i = 0;
				}
				i++;
			} else {
				i++;
			}
		}
	}

	public void reduce(int i){
		while (data.Count > i && i > 0) {
			data.RemoveAt(data.Count - 1);
		}
	}

	public String toJson (){
		String res = "";
		// pour éviter les doublons, je recherche si le joueur a déja eu un score
		foreach (Score item in data) {
			res += JsonUtility.ToJson(item) + '\n';
		}
		return res;
	}

	public int getIndexFBS(){
		// Parcourir les scores à la recherche de celui dont fbs == '*'
		foreach (Score item in data) {
			if (item.fbs) {
				return data.IndexOf(item);
			}
		}
		return -1;
	}

	public Score getFBS(){
		 //Parcourir les scores à la recherche de celui dont fbs == '*'
		foreach (Score item in data) {
			if (item.fbs) {
				return item;
			}
		}
		return (Score)data[0];
	}
}