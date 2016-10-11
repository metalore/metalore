using UnityEngine;
using System.Collections;

public class TileEvents : MonoBehaviour {
	SpriteRenderer rnderer;
	Color color;
	public Color hoverColor = new Color(0.5f, 0.5f, 0.5f, 1f); 

	// Use this for initialization
	void Start () {
		// get the renderer component and save the color
		rnderer  = GetComponent<SpriteRenderer>();
		color = rnderer.color;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	// Sprite click event
	void OnMouseDown() {
		Debug.Log ("sprite click");
		//renderer.color = new Color(0.5f, 0.5f, 0.5f, 1f); 
	}

	void OnMouseEnter() {
		//rend.material.color = Color.red;
		//Debug.Log("Mouse enter");
		rnderer.color = hoverColor; 
	}

	void OnMouseExit() {
		//Debug.Log("Mouse Exit");
		rnderer.color = color;
	}
}
	