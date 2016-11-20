using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

/// <summary>
/// Kelas PreferenceController mengontrol PreferenceScene.
/// </summary>
public class PreferenceController : MonoBehaviour {
	
	/// <summary>
	/// Button - button yang ada di PreferenceScene.
	/// </summary>
	public Button returnButton;

	/// <summary>
	/// Atribut yang menyimpan nama scene sebelumnya.
	/// </summary>
	private string previousLevel;

	/// <summary>
	/// Mengatur volume suara dengan VolumeSlider.
	/// </summary>
	/// <param name="newValue">New value.</param>
	public void VolumeSliderChanged(float newValue){
		AudioListener.volume = newValue;
	}

	/// <summary>
	/// Method ini berfungsi untuk inisialisasi.
	/// </summary>
	void Start(){
		previousLevel = PlayerPrefs.GetString ("previousScene");
		Button returnBtn = returnButton.GetComponent<Button> ();
		returnBtn.onClick.AddListener (returnBtnOnClick);
	}

	/// <summary>
	/// Mengatur tindakan yang dilakukan saat button ReturnButton diklik.
	/// Tindakan : Kembali ke layar sebelumnya.
	/// </summary>
	public void returnBtnOnClick(){
		PlayerPrefs.SetString ("previousScene", "PreferenceScene");
		SceneManager.LoadSceneAsync(previousLevel);
	}
}
