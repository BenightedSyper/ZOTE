using UnityEngine;
using System.Collections.Generic;

public class Character{
	public static float HALFDAMAGESHIELD = 200;
	public static float HALFDAMAGEHULL = 200;
	//BaseStats
	public string Name { get; set; }
	public Stat Hull;
	public Stat Shield;
	public Stat Energy;
	public Stat Heat;
	//currently equipped
	private Item TempHolding;
	public Weapon LeftWeapon;
	public Armor HeadArmor;
	public Armor TorsoArmor;
	public Armor LegsArmor;
	//additional storage
	public Item[] Inventory;
	
	//Constructors
	public Character(){
		Name = "NONAME";
		Hull = new Stat();
		Shield = new Stat();
		Energy = new Stat();
		Heat = new Stat();
		Inventory = new Item[20];
	}
	public Character(float _hull, float _shield, float _energy, float _heat){
		Hull = new Stat(_hull);
		Shield = new Stat(_shield);
		Energy = new Stat(_energy);
		Heat = new Stat(_heat);
		Inventory = new Item[20];
	}
	//Damage System
	public void TakeDamage(float _physical, float _energy){
		TakeDamage(_physical, _energy, Hull.Current, Shield.Current);
		Hull.CheckCurrent();
		Shield.CheckCurrent();
	}
	private void TakeDamage(float _physical, float _energy, float _hull, float _shield){
		TakePhysicalDamage(_physical, _hull, _shield);
		TakeEnergyDamage(_energy, _hull, _shield);
	}
	private void TakePhysicalDamage(float _damage, float _hull, float _shield){
		if(_shield > 0){
			Shield.AlterCurrent(-_damage * (1 / (1 + _shield / HALFDAMAGESHIELD)));
		}else{
			Hull.AlterCurrent(-_damage);
		}
	}
	private void TakeEnergyDamage(float _damage, float _hull, float _shield){
		if(_shield > 0){
			Shield.AlterCurrent(-_damage);
		}else{
			Hull.AlterCurrent(-_damage * (1 / (1 + _hull / HALFDAMAGEHULL)));
		}
	}
	//inventory
	public void DropItem(Item _item){
		//Instantiate(ItemHolder(_item), playerPosition);
	}
	public bool PickUp(Item _item){
		//returns true if item is picked up, false other wise
		bool pickup = false;
		for(int i = 0; i < Inventory.Length; i++){
			if(Inventory[i] == null){
				Inventory[i] = _item;
				pickup = true;
				break;
			}
		}
		return pickup;
	}
	public void EquipItem(Item _item){
		switch(_item.ItemType){
			case ITEMTYPE.ARMOR:
				EquipArmor(_item);
				break;
			case ITEMTYPE.WEAPON:
				EquipWeapon(_item);
				break;
		}
	}
	public void EquipArmor(Item _item){
		Armor armor = _item as Armor;
		switch(armor.ArmorType){
		case ARMORTYPE.HEAD:
			EquipHead(armor);
			break;
		case ARMORTYPE.TORSO:
			EquipTorso(armor);
			break;
		case ARMORTYPE.LEGS:
			EquipLegs(armor);
			break;
		}
	}
	public void EquipHead(Armor _armor){
		if(HeadArmor != null){
			//unequip old head armor
			//move to TempHolding
			TempHolding = HeadArmor;
			//remove old stats
			RemoveHeadStats();
		}
		//equip new head armor
		HeadArmor = _armor;
		//add new stats
		AddHeadStats(_armor);
		if(TempHolding != null){
			//put old armor in inventory
			if(PickUp(TempHolding)){
				DropItem(TempHolding);
			}
			TempHolding = null;
		}
	}
	public void UnequipHead(){
		if(HeadArmor == null){
			return;
		}
		//unequip old head armor
		//move to TempHolding
		TempHolding = HeadArmor;
		//remove old stats
		RemoveHeadStats();
		//put old head armor in inventory
		if(PickUp(TempHolding)){
			DropItem(TempHolding);
		}
		TempHolding = null;
	}
	private void AddHeadStats(Armor _armor){
		Hull.AddFlatMod("ArmorSlot:Head", _armor.Hull);
		Hull.AddRegenMod("ArmorSlot:Head", _armor.HullRegen);
		Shield.AddFlatMod("ArmorSlot:Head", _armor.Shield);
		Shield.AddRegenMod("ArmorSlot:Head", _armor.ShieldRegen);
		Shield.AddRegenTimerMod("ArmorSlot:Head", _armor.ShieldRegenTimer);
		Energy.AddFlatMod("ArmorSlot:Head", _armor.Energy);
		Energy.AddRegenMod("ArmorSlot:Head", _armor.EnergyRegen);
		Heat.AddFlatMod("ArmorSlot:Head", _armor.HeatRating);
		Heat.AddRegenMod("ArmorSlot:Head", _armor.HeatDispersion);
	}
	private void RemoveHeadStats(){
		Hull.RemoveFlatMod("ArmorSlot:Head");
		Hull.RemoveRegenMod("ArmorSlot:Head");
		Shield.RemoveFlatMod("ArmorSlot:Head");
		Shield.RemoveRegenMod("ArmorSlot:Head");
		Energy.RemoveFlatMod("ArmorSlot:Head");
		Energy.RemoveRegenMod("ArmorSlot:Head");
		Heat.RemoveFlatMod("ArmorSlot:Head");
		Heat.RemoveRegenMod("ArmorSlot:Head");
	}
	public void EquipTorso(Armor _armor){
		if(TorsoArmor != null){
			//unequip old torso armor
			//move to TempHolding
			TempHolding = TorsoArmor;
			//remove old stats
			/******/
		}
		//equip new torso armor
		TorsoArmor = _armor;
		//add new stats
		/********/
		if(TempHolding != null){
			//put old armor in inventory
			if(PickUp(TempHolding)){
				DropItem(TempHolding);
			}
			TempHolding = null;
		}
	}
	public void UnequipTorso(){
		if(TorsoArmor == null){
			return;
		}
		//unequip old Torso armor
		//move to TempHolding
		TempHolding = TorsoArmor;
		//remove old stats
		/******/
		//put old Torso armor in inventory
		if(PickUp(TempHolding)){
			DropItem(TempHolding);
		}
		TempHolding = null;
	}
	private void AddTorsoStats(Armor _armor){
		Hull.AddFlatMod("ArmorSlot:Torso", _armor.Hull);
		Hull.AddRegenMod("ArmorSlot:Torso", _armor.HullRegen);
		Shield.AddFlatMod("ArmorSlot:Torso", _armor.Shield);
		Shield.AddRegenMod("ArmorSlot:Torso", _armor.ShieldRegen);
		Shield.AddRegenTimerMod("ArmorSlot:Torso", _armor.ShieldRegenTimer);
		Energy.AddFlatMod("ArmorSlot:Torso", _armor.Energy);
		Energy.AddRegenMod("ArmorSlot:Torso", _armor.EnergyRegen);
		Heat.AddFlatMod("ArmorSlot:Torso", _armor.HeatRating);
		Heat.AddRegenMod("ArmorSlot:Torso", _armor.HeatDispersion);
	}
	private void RemoveTorsoStats(){
		Hull.RemoveFlatMod("ArmorSlot:Torso");
		Hull.RemoveRegenMod("ArmorSlot:Torso");
		Shield.RemoveFlatMod("ArmorSlot:Torso");
		Shield.RemoveRegenMod("ArmorSlot:Torso");
		Energy.RemoveFlatMod("ArmorSlot:Torso");
		Energy.RemoveRegenMod("ArmorSlot:Torso");
		Heat.RemoveFlatMod("ArmorSlot:Torso");
		Heat.RemoveRegenMod("ArmorSlot:Torso");
	}
	public void EquipLegs(Armor _armor){
		if(LegsArmor != null){
			//unequip old legs armor
			//move to TempHolding
			TempHolding = LegsArmor;
			//remove old stats
			/******/
		}
		//equip new torso armor
		LegsArmor = _armor;
		//add new stats
		/********/
		if(TempHolding != null){
			//put old armor in inventory
			if(PickUp(TempHolding)){
				DropItem(TempHolding);
			}
			TempHolding = null;
		}
	}
	public void UnequipLegs(){
		if(LegsArmor == null){
			return;
		}
		//unequip old legs armor
		//move to TempHolding
		TempHolding = LegsArmor;
		//remove old stats
		/******/
		//put old legs armor in inventory
		if(PickUp(TempHolding)){
			DropItem(TempHolding);
		}
		TempHolding = null;
	}
	private void AddLegsStats(Armor _armor){
		Hull.AddFlatMod("ArmorSlot:Legs", _armor.Hull);
		Hull.AddRegenMod("ArmorSlot:Legs", _armor.HullRegen);
		Shield.AddFlatMod("ArmorSlot:Legs", _armor.Shield);
		Shield.AddRegenMod("ArmorSlot:Legs", _armor.ShieldRegen);
		Shield.AddRegenTimerMod("ArmorSlot:Legs", _armor.ShieldRegenTimer);
		Energy.AddFlatMod("ArmorSlot:Legs", _armor.Energy);
		Energy.AddRegenMod("ArmorSlot:Legs", _armor.EnergyRegen);
		Heat.AddFlatMod("ArmorSlot:Legs", _armor.HeatRating);
		Heat.AddRegenMod("ArmorSlot:Legs", _armor.HeatDispersion);
	}
	private void RemoveLegsStats(){
		Hull.RemoveFlatMod("ArmorSlot:Legs");
		Hull.RemoveRegenMod("ArmorSlot:Legs");
		Shield.RemoveFlatMod("ArmorSlot:Legs");
		Shield.RemoveRegenMod("ArmorSlot:Legs");
		Energy.RemoveFlatMod("ArmorSlot:Legs");
		Energy.RemoveRegenMod("ArmorSlot:Legs");
		Heat.RemoveFlatMod("ArmorSlot:Legs");
		Heat.RemoveRegenMod("ArmorSlot:Legs");
	}
	public void EquipWeapon(Item _item){
		Weapon weapon = _item as Weapon;
		if(LeftWeapon != null){
			//unequip old weapon
			//move to TempHolding
			TempHolding = LeftWeapon;
			//remove old stats
			/******/
		}
		//equip new weapon
		LeftWeapon = weapon;
		//add new stats
		/********/
		if(TempHolding != null){
			//put old weapon in inventory
			if(PickUp(TempHolding)){
				DropItem(TempHolding);
			}
			TempHolding = null;
		}
	}
	public void UnequipLeftWeapon(){
		if(LeftWeapon == null){
			return;
		}
		//unequip old weapon
		//move to TempHolding
		TempHolding = LeftWeapon;
		//remove old stats
		/******/
		//put old weapon in inventory
		if(PickUp(TempHolding)){
			DropItem(TempHolding);
		}
		TempHolding = null;
	}
}