using UnityEngine;
using System.Collections;

public class GenerateMap : MonoBehaviour {

	public GameObject tile;

	[Header("Map size")]
	public int radius = 5;
	//public float sizeX = 1.93f;
	//public float sizeY = 1.349f;

	[Header("Initial tile location")]
	public float offsetX = 0;
	public float offsetY = 0;

	[Header("Tile spacing")]
	public float deltaX = 1.93f;
	public float deltaY = 1.349f;
	public float elevationScale = .05f;
	public int elevationRange = 10;

	// Use this for initialization
	void Start () {
		int dia = 2 * radius + 1;
		float elevationStep = elevationScale * deltaY;

		for (int i = 0; i < dia; ++i) {
			for (int j = dia - 1; j >= 0; --j) {
				if (i + j >= radius && i + j <= 3 * radius) {
					//var elevation = Mathf.Floor (Random.Range (0, elevationRange)) * elevationStep;
					var elevation = Mathf.Min (Mathf.Min (i, dia - i - 1), Mathf.Min (j, dia - j - 1));

					float x = offsetX + i * deltaX + j * (deltaX / 2);
					float y = offsetY + (dia - j - 1) * deltaY + elevation * elevationScale;
					Instantiate (tile, new Vector3 (x, y, 0), Quaternion.identity);					
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
