using UnityEngine;
using System.Collections;

/// <summary>
/// Kelas FlyingObstacle merepresentasikan obstacle yang dapat terbang.
/// </summary>
public class FlyingObstacle : Obstacle {

	/// <summary>
	/// Membuat Obstacle.
	/// </summary>
	public override void ObstacleMaker(){
		GameObject clone;
		obs = Random.Range (0, ob.Length);
		clone = (GameObject)Instantiate (ob[Random.Range(0,ob.Length)],new Vector3(transform.position.x+gap+4,0.49f,transform.position.z),Quaternion.identity);
		clone.name = "Quad1";
		float xx = Random.Range (1,7);
		Invoke ("ObstacleMaker", xx);
	}
}
