using UnityEngine;
using System.Collections;

public class GenerateMap : MonoBehaviour {

	public GameObject tile;
	public float sizeX = 1.9f;
	public float sizeY = 2.1f;
	public float offsetX = 0;
	public float offsetY = 0;
	public int rows = 11;
	public int col = 6;


	// Use this for initialization
	void Start () {

		for (int i = 0; i < rows; i++) {
			float x = (offsetX + (i * sizeX));
			Instantiate (tile, new Vector3 (x, 0, 0), Quaternion.identity);
			for (int z = 0; z < col; z++) {
				float y = offsetY + (z * sizeY);
				x = (z % 2 == 0) ? offsetX + (i * sizeX) : offsetX + sizeX/2 + (i * sizeX);
				Instantiate (tile, new Vector3 (x, y, 0), Quaternion.identity);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
