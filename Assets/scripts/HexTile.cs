using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class HexTile : MonoBehaviour {

	public float hexHeightMultiplier;
	public float animateSeconds;
	public float baseHeight;
	float animateFPS = 12f;
	float animateFrame = -1;


	SpriteRenderer rnderer;
	Color color;
	public Color hoverColor = new Color(0.5f, 0.5f, 0.5f, 1f); 

	// Use this for initialization
	void Start () {
		// get the renderer component and save the color
		AnimateHexHeight ();
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


	public void AnimateHexHeight (){

		// If the multiplier height is less than the minimum, remove it.

		if (hexHeightMultiplier < 1){
			Destroy(this.gameObject);
		}

		//if the initial -1 value is set, set the starting number of frames

		if (animateFrame == -1)
			animateFrame = animateSeconds * animateFPS;

		//Make the tile rise or fall to the hexHeight which is a multiple of the baseheight.

		Rect imageRect = this.GetComponent<RectTransform>().rect;
		float currentHeight = imageRect.height;
		float finalHeight = baseHeight * hexHeightMultiplier;
		float heightChange = finalHeight - currentHeight;
		float heightChangePerFrame = heightChange / animateFrame;
		float invokeDelay = animateSeconds / animateFPS;
	
		if (animateFrame > 0) {

			// change the height of the hex tile
			Vector2 sizeVector = new Vector2 (imageRect.width, currentHeight + heightChangePerFrame);
			this.GetComponent<RectTransform> ().sizeDelta = sizeVector;

			//Reduce the remaining frame count
			animateFrame--;

			//call this funciton again after a delay
			Invoke ("AnimateHexHeight", invokeDelay);
		} else {
			// Set the height to its exact final value
			Vector2 sizeVector = new Vector2 (imageRect.width, finalHeight);
			this.GetComponent<RectTransform>().sizeDelta = sizeVector;
			animateFrame = -1; //reset the number of frames
		}
	}
}