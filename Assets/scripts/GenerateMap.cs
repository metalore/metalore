using UnityEngine;
using System.Collections;

public class GenerateMap : MonoBehaviour {

	public GameObject tile;
	GameObject canvas;

	[Header("Map size")]
	public int radius = 6;
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
		//float elevationStep = elevationScale * deltaY;

		//Add a Canvas
		canvas = new GameObject ("HexCanvas");
		canvas.AddComponent<Canvas> ();
		Canvas canvasComponent = canvas.GetComponent<Canvas> ();
		canvasComponent.renderMode = RenderMode.ScreenSpaceCamera;
		canvasComponent.worldCamera = Camera.main;

		for (int i = 0; i < dia; ++i) {
			for (int j = dia - 1; j >= 0; --j) {
				if (i + j >= radius && i + j <= 3 * radius) {
					//var elevation = Mathf.Floor (Random.Range (0, elevationRange)) * elevationStep;
					var elevation = Mathf.Min (Mathf.Min (i, dia - i), Mathf.Min (j, dia - j));

					float x = offsetX + i * deltaX + j * (deltaX / 2);
					float y = offsetY + (dia - j - 1) * deltaY + elevation * elevationScale;
					GameObject hex = (GameObject) Instantiate (tile, new Vector3 (x, y, 0), Quaternion.identity);
					hex.transform.SetParent (canvas.transform);
					hex.transform.localScale = new Vector3(0.32f, 0.32f, 0.32f);
					
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
