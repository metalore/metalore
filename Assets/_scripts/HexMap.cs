using UnityEngine;
using System.Collections;

public class HexMap {
	//	Fields
	protected HexTile[] tiles;
	protected int radius;
	/*	Middle tile = 0, otherwise concentric rings
	/*	Number of active tiles equals 3 * n * (n + 1) + 1
	/*	Number including void tiles = (2n + 1)^2
	/*	*/
	protected int size;

	//	Constructor
	public HexMap (int radius) {
		this.radius = radius;
		var root = 2 * radius + 1;
		size = root * root;
		tiles = new HexTile[size];
	}
}
