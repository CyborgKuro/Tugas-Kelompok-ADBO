using UnityEngine;
using System.Collections;

/// <summary>
/// Kelas GameController mengatur score game.
/// </summary>
public class GameController : MonoBehaviour {

	/// <summary>
	/// Atribut score 1.
	/// </summary>
	private int sc;

	/// <summary>
	/// Atribut score 2.
	/// </summary>
	private float sco;

	/// <summary>
	/// High Score.
	/// </summary>
	private int high;

	/// <summary>
	/// Style GUI.
	/// </summary>
	public GUIStyle style1;
	// Use this for initialization
	void Start () {
		high = HighScoreScript.highScores;
		sco = 0;
	}
	
	/// <summary>
	/// Update score.
	/// </summary>
	void Update () {
		if (!HighScoreScript.gameOver) {	
			transform.Translate (Vector3.right * PlayerPrefs.GetInt ("speed") * Time.deltaTime);
			sco += Time.deltaTime * 10;
			sc = (int)sco;
			if (high < sc) {
				HighScoreScript.highScores = sc;
			}
		}
	}

	/// <summary>
	/// Menampilkan score dilayar.
	/// </summary>
	void OnGUI(){
		string score = sc.ToString();
		GUI.Label(new Rect (Screen.width * 0.8f, Screen.height * 0.07f, Screen.width * 0.2f, Screen.height * 0.05f), score, style1);
		GUI.Label (new Rect (Screen.width * 0.65f, Screen.height * 0.07f, Screen.width * 0.2f, Screen.height * 0.05f), "HI"+high, style1);
	}
}
