using UnityEngine;
using System.Collections;

public enum WEAPONTYPE { FAST, AVERAGE, SLOW }
public class Weapon : Item {
	public float PhysicalDamage { get; set; }
	public float EnergyDamage { get; set; }
	public float Range { get; set; }
	public float AttackSpeed { get; set; }
	public float ResetSpeed { get; set; }
	public float EnergyCost { get; set; }
	public float HeatCost { get; set; }
	public WEAPONTYPE WeaponType { get; set; }
	public bool TwoHanded { get; set; }
	
	public Weapon (){
		PhysicalDamage = 0f;
		EnergyDamage = 0f;
		Range = 0f;
		AttackSpeed = 0f;
		ResetSpeed = 0f;
		EnergyCost = 0f;
		HeatCost = 0f;
		WeaponType = WEAPONTYPE.AVERAGE;
		TwoHanded = false;
	}
	public Weapon (string _name, ITEMTYPE _itemType) : base( _name, _itemType){
		PhysicalDamage = 0f;
		EnergyDamage = 0f;
		Range = 0f;
		AttackSpeed = 0f;
		ResetSpeed = 0f;
		EnergyCost = 0f;
		HeatCost = 0f;
		WeaponType = WEAPONTYPE.AVERAGE;
		TwoHanded = false;
	}
	public Weapon ( string _name, int _value, int _weight, ITEMTYPE _itemType,
					float _physicalDamage, float _energyDamage, float _range, float _attackSpeed, float _resetSpeed, float _energyCost, float _heatCost, WEAPONTYPE _weaponType, bool _twoHanded)
					: base( _name, _value, _weight, _itemType){
		PhysicalDamage = _physicalDamage;
		EnergyDamage = _energyDamage;
		Range = _range;
		AttackSpeed = _attackSpeed;
		ResetSpeed = _resetSpeed;
		EnergyCost = _energyCost;
		HeatCost = _heatCost;
		WeaponType = _weaponType;
		TwoHanded = _twoHanded;
	}
}
