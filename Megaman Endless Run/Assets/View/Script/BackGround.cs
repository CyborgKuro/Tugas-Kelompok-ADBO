using UnityEngine;
using System.Collections;

/// <summary>
/// Kelas BackGround mengatur background pada GameScene.
/// </summary>
public class BackGround : MonoBehaviour {

	/// <summary>
	/// Mengatur gerak background.
	/// </summary>
	/// <param name="coll">Collider pembatas background.</param>
	void OnTriggerExit2D(Collider2D coll){
		float width = ((BoxCollider2D)coll).size.x;
		Vector3 pos = coll.transform.position;
		pos.x += width + 49.01f;
		if (coll.gameObject.tag == "BG1") {
			coll.transform.position = pos;
		}
		if (coll.gameObject.tag == "BG2") {
			coll.transform.position = pos;
		}
	}
}
