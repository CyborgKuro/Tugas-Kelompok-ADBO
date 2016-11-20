using UnityEngine;
using System.Collections;

/// <summary>
/// Kelas abstract Obstacle merepresentasikan obstacle.
/// </summary>
public abstract class Obstacle : MonoBehaviour {

	/// <summary>
	/// Array of obstacle.
	/// </summary>
	public GameObject[] ob;

	/// <summary>
	/// Camera Position.
	/// </summary>
	public Transform campos;

	/// <summary>
	/// Gap antar obstacle.
	/// </summary>
	public float gap =1.5f;

	/// <summary>
	/// Obstacle.
	/// </summary>
	public int obs;

	/// <summary>
	/// Method ini berfungsi untuk inisialisasi.
	/// </summary>
	void Start () {
		ObstacleMaker ();
	}

	/// <summary>
	/// Mengatur kemunculan obstacle.
	/// </summary>
	void Update () {
		if (!HighScoreScript.gameOver) {
			transform.Translate (Vector3.right * PlayerPrefs.GetInt ("speed") * Time.deltaTime);
			GameObject go = GameObject.Find ("Quad1");
			if (campos.position.x - go.transform.position.x > 25) {
				Destroy (go);
			}
		}
	}

	/// <summary>
	/// Method abstract pembuat obstacle.
	/// </summary>
	public abstract void ObstacleMaker ();

}
