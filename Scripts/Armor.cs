using UnityEngine;
using System.Collections;

public enum ARMORTYPE { HEAD, TORSO, LEGS }
public class Armor : Item {
	public static Armor testArmor = new Armor("TESTARMOR", ITEMTYPE.ARMOR);

	public float Hull { get; set; }
	public float HullRegen { get; set; } //from 0-1 representing percentage of max over 5 seconds
	public float Shield { get; set; }
	public float ShieldRegen { get; set; }//from 0-1 representing percentage of max over 5 seconds
	public float ShieldRegenTimer { get; set; } //time out of combat till sheild starts to recharge
	public float Energy { get; set; }
	public float EnergyRegen { get; set; }//from 0-1 representing percentage of max over 5 seconds
	public float HeatRating { get; set; }
	public float HeatDispersion { get; set; }//from 0-1 representing percentage of max over 5 seconds
	public ARMORTYPE ArmorType { get; set; }
	
	public Armor(){
		Hull = 0f;
		HullRegen = 0f; 
		Shield = 0f; 
        ShieldRegen = 0f; 
		ShieldRegenTimer = 0f;
        Energy = 0f;
        EnergyRegen = 0f; 
        HeatRating = 0f;
        HeatDispersion = 0f;
		ArmorType = ARMORTYPE.HEAD;
	}
	public Armor(string _name, ITEMTYPE _itemType) : base( _name, _itemType){
		Hull = 0f;
		HullRegen = 0f; 
		Shield = 0f; 
        ShieldRegen = 0f; 
		ShieldRegenTimer = 0f;
        Energy = 0f;
        EnergyRegen = 0f; 
        HeatRating = 0f;
        HeatDispersion = 0f;
		ArmorType = ARMORTYPE.HEAD;
	}
	public Armor(string _name, int _value, int _weight, ITEMTYPE _itemType,
				 float _hull, float _hullRegen, 
				 float _shield, float _shieldRegen, float _shieldRegenTimer, 
				 float _energy, float _energyRegen, 
				 float _heatRating, float _heatDispersion, 
				 ARMORTYPE _armorType)
				 : base ( _name, _value, _weight, _itemType){
		Hull = 0f;
		HullRegen = 0f; 
		Shield = 0f; 
        ShieldRegen = 0f; 
		ShieldRegenTimer = 0f;
        Energy = 0f;
        EnergyRegen = 0f; 
        HeatRating = 0f;
        HeatDispersion = 0f;
		ArmorType = _armorType;
	}
}
