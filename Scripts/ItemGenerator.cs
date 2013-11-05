using UnityEngine;
using System.Collections;

public static class ItemGenerator {
	public const float FAST_WEAPON_RANGE = 1f;
	public const float AVERAGE_WEAPON_RANGE = 1.25f;
	public const float SLOW_WEAPON_RANGE = 1.5f;
	
	public const float FAST_WEAPON_ATTACK_SPEED = 0.25f;
	public const float AVERAGE_WEAPON_ATTACK_SPEED = 0.375f;
	public const float SLOW_WEAPON_ATTACK_SPEED = 0.5f;
	
	public const float FAST_WEAPON_RESET_SPEED = 0.5f;
	public const float AVERAGE_WEAPON_RESET_SPEED = 0.75f;
	public const float SLOW_WEAPON_RESET_SPEED = 1f;
	
	public const float FAST_WEAPON_TOTAL_DAMAGE = 50f;
	public const float AVERAGE_WEAPON_TOTAL_DAMAGE = 75f;
	public const float SLOW_WEAPON_TOTAL_DAMAGE = 100f;
	
	public const float LIGHT_HEAD_TOTAL_DEFENSE = 25f;
	public const float MEDIUM_HEAD_TOTAL_DEFENSE = 50f;
	public const float HEAVY_HEAD_TOTAL_DEFENSE = 100f;
	
	public const float LIGHT_LEGS_TOTAL_DEFENSE = 50f;
	public const float MEDIUM_LEGS_TOTAL_DEFENSE = 100f;
	public const float HEAVY_LEGS_TOTAL_DEFENSE = 200f;
	
	public const float LIGHT_TORSO_TOTAL_DEFENSE = 100f;
	public const float MEDIUM_TORSO_TOTAL_DEFENSE = 200f;
	public const float HEAVY_TORSO_TOTAL_DEFENSE = 400f;
	
	public static Item RandomItem(){
		//randomly choose weapon or armor. 1:3 weapon:armor
		if((Random.Range(0,4) > 0)){//random [0-4)
			//HEAD TORSO LEGS
			return RandomArmor();
		}else{
			// WEAPON
			return RandomWeapon();
		}
		/************************/
		//shield to be a 3rd item type for the right hand slot
		/************************/
	}
	public static Item RandomWeapon(){
		Weapon randomWeapon = new Weapon("Random Weapon", ITEMTYPE.WEAPON);
		//random between weapon speeds
		float min, max;
		switch(Random.Range(0,3)){ //[0-3)
		case 0://FAST
			min = (int)FAST_WEAPON_TOTAL_DAMAGE / 5;
			max = FAST_WEAPON_TOTAL_DAMAGE - min;
			randomWeapon.PhysicalDamage = Random.Range((int)min, (int)max);
			randomWeapon.EnergyDamage = max - randomWeapon.PhysicalDamage;
			randomWeapon.Range = FAST_WEAPON_RANGE;
			randomWeapon.AttackSpeed = FAST_WEAPON_ATTACK_SPEED;
			randomWeapon.ResetSpeed = FAST_WEAPON_RESET_SPEED;
			randomWeapon.WeaponType = WEAPONTYPE.FAST;
			break;
		case 1://AVERAGE
			min = (int)AVERAGE_WEAPON_TOTAL_DAMAGE / 5;
			max = AVERAGE_WEAPON_TOTAL_DAMAGE - min;
			randomWeapon.PhysicalDamage = Random.Range((int)min, (int)max);
			randomWeapon.EnergyDamage = max - randomWeapon.PhysicalDamage;
			randomWeapon.Range = AVERAGE_WEAPON_RANGE;
			randomWeapon.AttackSpeed = AVERAGE_WEAPON_ATTACK_SPEED;
			randomWeapon.ResetSpeed = AVERAGE_WEAPON_RESET_SPEED;
			randomWeapon.WeaponType = WEAPONTYPE.AVERAGE;
			break;
		case 2://SLOW
			min = (int)SLOW_WEAPON_TOTAL_DAMAGE / 5;
			max = SLOW_WEAPON_TOTAL_DAMAGE - min;
			randomWeapon.PhysicalDamage = Random.Range((int)min, (int)max);
			randomWeapon.EnergyDamage = max - randomWeapon.PhysicalDamage;
			randomWeapon.Range = SLOW_WEAPON_RANGE;
			randomWeapon.AttackSpeed = SLOW_WEAPON_ATTACK_SPEED;
			randomWeapon.ResetSpeed = SLOW_WEAPON_RESET_SPEED;
			randomWeapon.WeaponType = WEAPONTYPE.SLOW;
			break;
		}
		return randomWeapon;
	}
	public static Item RandomArmor(){
		Armor randomArmor = new Armor("Random Weapon", ITEMTYPE.ARMOR);
		Debug.Log("" + randomArmor.Name + " : " + randomArmor.Hull);
		//random between armor types
		switch(Random.Range(0,3)){
		case 0://HEAD
			randomArmor = RandomHeadArmor(randomArmor);
			break;
		case 1://TORSO
			randomArmor = RandomTorsoArmor(randomArmor);
			break;
		case 2://LEGS
			randomArmor = RandomLegsArmor(randomArmor);
			break;
		}
		Debug.Log("" + randomArmor.Name + " : " + randomArmor.Hull);
		return randomArmor as Item;
	}
	public static Armor RandomHeadArmor(Armor _armor){
		switch(Random.Range(0,3)){
		case 0://LIGHT
			_armor.Hull = Random.Range((int)LIGHT_HEAD_TOTAL_DEFENSE/5, LIGHT_HEAD_TOTAL_DEFENSE - (int)(LIGHT_HEAD_TOTAL_DEFENSE/5));
			_armor.HullRegen = 0f; 
			_armor.Shield = LIGHT_HEAD_TOTAL_DEFENSE - _armor.Hull; 
			_armor.ShieldRegen = 0f; 
			_armor.ShieldRegenTimer = 0f;
			_armor.Energy = 10f;
			_armor.EnergyRegen = 0f; 
			_armor.HeatRating = 10f;
			_armor.HeatDispersion = 0f;
			_armor.ArmorType = ARMORTYPE.HEAD;
			break;
		case 1://MEDIUM
			_armor.Hull = Random.Range((int)MEDIUM_HEAD_TOTAL_DEFENSE/5, MEDIUM_HEAD_TOTAL_DEFENSE - (int)(MEDIUM_HEAD_TOTAL_DEFENSE/5));
			_armor.HullRegen = 0f; 
			_armor.Shield = MEDIUM_HEAD_TOTAL_DEFENSE - _armor.Hull; 
			_armor.ShieldRegen = 0f; 
			_armor.ShieldRegenTimer = 0f;
			_armor.Energy = 20f;
			_armor.EnergyRegen = 0f; 
			_armor.HeatRating = 20f;
			_armor.HeatDispersion = 0f;
			_armor.ArmorType = ARMORTYPE.HEAD;
			break;
		case 2:// HEAVY
			_armor.Hull = Random.Range((int)HEAVY_HEAD_TOTAL_DEFENSE/5, HEAVY_HEAD_TOTAL_DEFENSE - (int)(HEAVY_HEAD_TOTAL_DEFENSE/5));
			_armor.HullRegen = 0f; 
			_armor.Shield = HEAVY_HEAD_TOTAL_DEFENSE - _armor.Hull;
			_armor.ShieldRegen = 0f; 
			_armor.ShieldRegenTimer = 0f;
			_armor.Energy = 30f;
			_armor.EnergyRegen = 0f; 
			_armor.HeatRating = 30f;
			_armor.HeatDispersion = 0f;
			_armor.ArmorType = ARMORTYPE.HEAD;
			break;
		}
		return _armor;
	}
	public static Armor RandomTorsoArmor(Armor _armor){
		switch(Random.Range(0,3)){
		case 0://LIGHT
			_armor.Hull = 0f;
			_armor.HullRegen = 0f; 
			_armor.Shield = 0f; 
			_armor.ShieldRegen = 0f; 
			_armor.ShieldRegenTimer = 0f;
			_armor.Energy = 0f;
			_armor.EnergyRegen = 0f; 
			_armor.HeatRating = 0f;
			_armor.HeatDispersion = 0f;
			_armor.ArmorType = ARMORTYPE.TORSO;
			break;
		case 1://MEDIUM
			_armor.Hull = 0f;
			_armor.HullRegen = 0f; 
			_armor.Shield = 0f; 
			_armor.ShieldRegen = 0f; 
			_armor.ShieldRegenTimer = 0f;
			_armor.Energy = 0f;
			_armor.EnergyRegen = 0f; 
			_armor.HeatRating = 0f;
			_armor.HeatDispersion = 0f;
			_armor.ArmorType = ARMORTYPE.TORSO;
			break;
		case 2://HEAVY
			_armor.Hull = 0f;
			_armor.HullRegen = 0f; 
			_armor.Shield = 0f; 
			_armor.ShieldRegen = 0f; 
			_armor.ShieldRegenTimer = 0f;
			_armor.Energy = 0f;
			_armor.EnergyRegen = 0f; 
			_armor.HeatRating = 0f;
			_armor.HeatDispersion = 0f;
			_armor.ArmorType = ARMORTYPE.TORSO;
			break;
		}
		return _armor;
	}
	public static Armor RandomLegsArmor(Armor _armor){
		switch(Random.Range(0,3)){
		case 0://LIGHT
			_armor.Hull = 0f;
			_armor.HullRegen = 0f; 
			_armor.Shield = 0f; 
			_armor.ShieldRegen = 0f; 
			_armor.ShieldRegenTimer = 0f;
			_armor.Energy = 0f;
			_armor.EnergyRegen = 0f; 
			_armor.HeatRating = 0f;
			_armor.HeatDispersion = 0f;
			_armor.ArmorType = ARMORTYPE.LEGS;
			break;
		case 1://MEDIUM
			_armor.Hull = 0f;
			_armor.HullRegen = 0f; 
			_armor.Shield = 0f; 
			_armor.ShieldRegen = 0f; 
			_armor.ShieldRegenTimer = 0f;
			_armor.Energy = 0f;
			_armor.EnergyRegen = 0f; 
			_armor.HeatRating = 0f;
			_armor.HeatDispersion = 0f;
			_armor.ArmorType = ARMORTYPE.LEGS;
			break;
		case 2://HEAVY
			_armor.Hull = 0f;
			_armor.HullRegen = 0f; 
			_armor.Shield = 0f; 
			_armor.ShieldRegen = 0f; 
			_armor.ShieldRegenTimer = 0f;
			_armor.Energy = 0f;
			_armor.EnergyRegen = 0f; 
			_armor.HeatRating = 0f;
			_armor.HeatDispersion = 0f;
			_armor.ArmorType = ARMORTYPE.LEGS;
			break;
		}
		return _armor;
	}
}
