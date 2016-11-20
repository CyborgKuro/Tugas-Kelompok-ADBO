using UnityEngine;
using System.Collections;

/// <summary>
/// Kelas SiangMalam mengatur siang malam di gamr.
/// </summary>
public class SiangMalam : MonoBehaviour {

	/// <summary>
	/// The HSV shader.
	/// </summary>
	public Shader HSVShader;

	/// <summary>
	/// true = siang, false = malam.
	/// </summary>
	public bool siang = true;

	/// <summary>
	/// Object game 1.
	/// </summary>
	public GameObject ob1;

	/// <summary>
	/// Object game 2.
	/// </summary>
	public GameObject ob2;

	/// <summary>
	/// Sprite renderer 1.
	/// </summary>
	private SpriteRenderer sr1; 

	/// <summary>
	/// Sprite renderer 2.
	/// </summary>
	private SpriteRenderer sr2;

	/// <summary>
	/// Delay.
	/// </summary>
	private int delay;

	/// <summary>
	/// Delay dalam game.
	/// </summary>
	private int delayDalamGame;

	/// <summary>
	/// Status bulan.
	/// </summary>
	private int statusBulan;

	/// <summary>
	/// Bulan.
	/// </summary>
	public GameObject bulan;

	/// <summary>
	/// Sprites bulan.
	/// </summary>
	public Sprite[] bulanSprites;

	/// <summary>
	/// Bulan purnama : true = ya, false = tidak.
	/// </summary>
	private bool bulanPurnama;

	/// <summary>
	/// Alpha bulan.
	/// </summary>
	private float alphaBulan;

	/// <summary>
	/// Menghilangkan bulan pada pertama kali dijalankan.
	/// </summary>
	void Start () {
		alphaBulan = 0;
		bulanPurnama = false;
		bulan.GetComponent<SpriteRenderer> ().enabled = false;
		statusBulan = -1;
		delay = 2000;
		delayDalamGame = delay;
		sr1 = ob1.GetComponent<SpriteRenderer> ();
		sr2 = ob2.GetComponent<SpriteRenderer> ();
		bulan.GetComponent<SpriteRenderer> ().material.color = new Color(bulan.GetComponent<SpriteRenderer> ().material.color.r,bulan.GetComponent<SpriteRenderer> ().material.color.g,bulan.GetComponent<SpriteRenderer> ().material.color.b,0);
	}

	/// <summary>
	/// Mengecek apakah game sudah selesai atau belum, bila belum maka warna background akan diubah serta apakah bulan akan ditampilkan atau tidak.
	/// </summary>
	void Update () {
		if (!HighScoreScript.gameOver) {
			delayDalamGame--;
			if (delayDalamGame <= 0) {	
				UpdateBGColor ();
			}
		}
	}
		
	/// <summary>
	/// Mengupdate warna background serta mengubah-ubah bulan.
	/// </summary>
	void UpdateBGColor(){
		if (siang == true) {
			if (sr1.material.GetFloat ("_Val") >= 0.5f) {
				sr1.material.SetFloat ("_Val", sr1.material.GetFloat ("_Val") - 0.001f);
				sr2.material.SetFloat ("_Val", sr2.material.GetFloat ("_Val") - 0.001f);


				if (statusBulan > -1 && statusBulan<6 &&sr1.material.GetFloat ("_Val") <= 0.95f) {
					bulan.GetComponent<SpriteRenderer> ().enabled = true;
					Debug.Log (statusBulan);
					bulan.GetComponent<SpriteRenderer> ().sprite = bulanSprites[statusBulan];
					bulan.GetComponent<SpriteRenderer> ().material.color =  new Color(bulan.GetComponent<SpriteRenderer> ().material.color.r,bulan.GetComponent<SpriteRenderer> ().material.color.g,bulan.GetComponent<SpriteRenderer> ().material.color.b,alphaBulan);
					alphaBulan += 0.002f;

				}

			} else {
				delayDalamGame = delay;
				siang = false;
			}
		} else {
			if (statusBulan > -1) {
				UbahXBulan();
			}
			if (sr1.material.GetFloat ("_Val") <= 1f) {
				sr1.material.SetFloat ("_Val", sr1.material.GetFloat ("_Val") + 0.001f);
				sr2.material.SetFloat ("_Val", sr2.material.GetFloat ("_Val") + 0.001f);
				if (statusBulan > -1) {
					alphaBulan -= 0.002f;
					bulan.GetComponent<SpriteRenderer> ().material.color = new Color (bulan.GetComponent<SpriteRenderer> ().material.color.r, bulan.GetComponent<SpriteRenderer> ().material.color.g, bulan.GetComponent<SpriteRenderer> ().material.color.b, alphaBulan);
				}
			}
			else {
				bulan.GetComponent<SpriteRenderer> ().enabled = false;
				if (bulanPurnama == false) {
					statusBulan++;
				} else {
					statusBulan--;
				}
				delayDalamGame = delay;
				siang = true;
			}
		}
	}

	/// <summary>
	/// Memutar posisi bulan.
	/// </summary>
	public void UbahXBulan(){
		if (statusBulan == 6) {
			bulanPurnama = true;
			bulan.GetComponent<SpriteRenderer> ().flipX = true;
		}
		if (statusBulan == -1) {
			bulanPurnama = false;
			bulan.GetComponent<SpriteRenderer> ().flipX = true;
		}




	}
}
