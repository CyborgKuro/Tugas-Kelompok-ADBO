using UnityEngine;
using System.Collections;

/// <summary>
/// Kelas Runner merepresentasikan runner.
/// </summary>
public class Runner : MonoBehaviour,CanMove {

	/// <summary>
	/// true = sedang melompat, false = tidak sedang melompat.
	/// </summary>
	private bool falling= false;

	/// <summary>
	/// Tinggi lompatan.
	/// </summary>
	private int jumpHeight =1;

	/// <summary>
	/// Atribut yang akan diisikan audio source dari unity.
	/// </summary>
	public AudioSource soundFXJump;

	/// <summary>
	/// Atribut yang akan mendapatkan audio source dari atribut soundFXJump.
	/// </summary>
	private AudioSource sfxJump;

	/// <summary>
	/// Ukuran collider x dan y.
	/// </summary>
	private float ukuranColliderX, ukuranColliderY;

	/// <summary>
	/// Status apakah suara sedang jalan.
	/// </summary>
	private bool suaraSedangJalan=false;

	/// <summary>
	/// Method ini berfungsi untuk inisialisasi.
	/// </summary>
	void Start () {
		sfxJump = soundFXJump.GetComponent<AudioSource> ();
		PlayerPrefs.SetInt ("speed", 7);
		falling = false;
		ukuranColliderX = GetComponent<BoxCollider2D> ().size.x;
		ukuranColliderY = GetComponent<BoxCollider2D> ().size.y;
	}
		
	/// <summary>
	/// Mengecek apakah game sudah selesai atau belum, bila belum maka character akan digerakan.
	/// </summary>
	void Update () {
		if (!HighScoreScript.gameOver) {
			Move ();
		}
		
	}

	/// <summary>
	/// menggerakan character sesuai input pemain.
	/// </summary>
	public void Move(){
		transform.Translate (Vector3.right * PlayerPrefs.GetInt ("speed") * Time.deltaTime);
		if (Input.GetKey (KeyCode.Space)||Input.GetKey (KeyCode.UpArrow)||Input.GetKey(KeyCode.Mouse0)) {
			if(suaraSedangJalan==false){
				sfxJump.Play ();
				suaraSedangJalan = true;
			}
			if ((GetComponent<Rigidbody2D> ().position.y < jumpHeight) && falling == false) {
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, 12);
			}
			else {
				falling = true;
			}
		}
		else {
			falling = true;

		}
		if (Input.GetKey(KeyCode.DownArrow)) {
			GetComponent<BoxCollider2D>().size= new Vector3(ukuranColliderX*1.2f,0.1f+ukuranColliderY/2.2f,0);
			Debug.Log(GetComponent<BoxCollider2D> ().size.x);
			GetComponent<Animator> ().Play ("Megaman_Slide");
		}
		if(Input.GetKeyUp(KeyCode.DownArrow)){
			GetComponent<BoxCollider2D> ().size = new Vector3 (ukuranColliderX, ukuranColliderY, 0);
			Debug.Log(GetComponent<BoxCollider2D> ().size.x);
			GetComponent<Animator> ().Play ("Megaman_Run");
		}
	}

	/// <summary>
	/// Membolehkan character untuk melompat serta suara agar bisa diplay ulang.
	/// </summary>
	void OnCollisionStay2D(){
		falling = false;
		suaraSedangJalan = false;
	}
}