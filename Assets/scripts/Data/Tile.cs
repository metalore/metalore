using UnityEngine;
using System.Collections;

public enum TileSides {
	NorEast,
	East,
	SouEast,
	SouWest,
	West,
	NorWest,
}

public enum TileType {
	Void = -2,
	Ore = -1,
	Plain = 0,
	Path = 1
}

public abstract class Tile {
	public int elevation = 0;
	public TileType type;

	Tile[] neighbors = new Tile[6];

	protected int x;
	protected int y;

	public void SetX (int i) { x = i; }
	public int GetX () { return x; }

	public void SetY (int j) { y = j; }
	public int GetY () { return y; }

	public void AddNeighbor (TileSides side, Tile tile) 	{
		if (tile.GetType () != typeof(VoidTile))
			neighbors [(int)side] = tile;
	}

	public Tile GetNeighbor (TileSides side) 	{
		return neighbors [(int)side];
	}

	public int GetDeltaElevation (TileSides side) {
		return elevation - neighbors [(int)side].elevation;
	}
}
