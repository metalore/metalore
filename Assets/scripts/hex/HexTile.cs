using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class HexTile : MonoBehaviour {

	public float hexHeightMultiplier;
	public float animateSeconds;
	public float baseHeight;
	float animateFPS = 12f;
	float animateFrame = -1;

	void Start () {
		UpdateHexHeight ();
	}
	
	void Update () {
		
	}

	public void UpdateHexHeight (){

		//if the initial -1 value is set, set the starting number of frames

		if (animateFrame == -1){
			animateFrame = animateSeconds * animateFPS;
		}

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
			Invoke ("UpdateHexHeight", invokeDelay);
		} else {
			// Set the height to its exact final value
			Vector2 sizeVector = new Vector2 (imageRect.width, finalHeight);
			this.GetComponent<RectTransform>().sizeDelta = sizeVector;
			animateFrame = -1; //reset the number of frames
		}
	}
}