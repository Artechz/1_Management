using System.Collections;
using System.Collections.Generic;
using System;

public class Tile {

    public enum TileType { Empty, Floor };

	TileType type = TileType.Empty;



	public TileType Type {
		get {
			return type;
		}
		set {
			TileType oldType = type;
			type = value;
			//Call the callback (OnTileTypeChanged) and let things know it's changed.

			if (cbTileTypeChange != null && oldType != type)
				cbTileTypeChange(this);
		}
	}

    LooseObject looseObject;
    InstalledObject installObject;

    World world;
	int x;

	public int X {
		get {
			return x;
		}
	}

	int y;

	public int Y {
		get {
			return y;
		}
	}

	Action<Tile> cbTileTypeChange; //Function we call anytime our type changes.

    public Tile ( World world, int x, int y ) {
        this.world = world;
        this.x = x;
        this.y = y;
    }

	public void RegisterTileTypeChangedCallback (Action<Tile> callback){
		cbTileTypeChange += callback;
	}

	public void UnRegisterTileTypeChangedCallback (Action<Tile> callback){
		cbTileTypeChange -= callback;
	}
}
