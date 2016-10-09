using UnityEngine;
using System.Collections;

public class GenerateMap : MonoBehaviour {

	public GameObject tile;
	public float sizeX = 1.8f;
	public float sizeY = 2.2f;
	public float offsetX = 0;
	public float offsetY = 0;
	public int rows = 10;
	public int col = 5;


	// Use this for initialization
	void Start () {

		for (int i = 0; i < rows; i++) {
			float x = (i % 2 == 0) ? offsetX + (i * sizeX) : offsetX + sizeX/2 + (i * sizeX);
			Debug.Log("generating x");
			Debug.Log ("x is " + i);
			Debug.Log ("divisable by 2 : " + (i % 2) );

			Instantiate (tile, new Vector3 (x, 0, 0), Quaternion.identity);
			for (int z = 0; z < col; z++) {
				float y = offsetY + (z * sizeY);
				Instantiate (tile, new Vector3 (x, y, 0), Quaternion.identity);
			}
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
