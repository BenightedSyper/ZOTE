using UnityEngine;

public enum ITEMTYPE { ITEM = 0, WEAPON = 1, ARMOR = 2, SHIELD = 3, CONSUMABLE = 4 }
public class Item {	
	public string Name { get; set; } //in characters
	public int Value { get; set; } //in copper pieces
	public int Weight { get; set; } //in graves
	public ITEMTYPE ItemType { get; set; }
	public Texture2D Icon { get; set; }
	
	public Item(){
		Name = "NONAME";
		Value = 1;
		Weight = 0;
		ItemType = ITEMTYPE.ITEM;
		Icon = null;
	}
	public Item(string _name){
		Name = _name;
		Value = 1;
		Weight = 0;
		ItemType = ITEMTYPE.ITEM;
		Icon = null;
	}
	public Item(string _name, ITEMTYPE _itemType){
		Name = _name;
		Value = 1;
		Weight = 0;
		ItemType = _itemType;
		Icon = null;
	}
	public Item(string _name, int _value, int _weight, ITEMTYPE _itemType){
		Name = _name;
		Value = _value;
		Weight = _weight;
		ItemType = _itemType;
		Icon = null;
	}
	public Item(string _name, int _value, int _weight, ITEMTYPE _itemType, Texture2D _icon){
		Name = _name;
		Value = _value;
		Weight = _weight;
		ItemType = _itemType;
		Icon = _icon;
	}
	public string GetToolTip(){
		return "" + Name + "/n" + Value;
	}
}


