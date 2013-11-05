using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Stat{
	private static float RegenTimeBase = 5f;
	public float Current { get; set; }
	public float Base { get; set; }
	public float Total { get; set; }
	private IDictionary<string, float> FlatMods;
	private IDictionary<string, float> PercentMods;
	
	public float Regen { get; set; }
	public float RegenTotal { get; set; }
	public float RegenTimer { get; set; }
	private IDictionary<string, float> RegenMods;
	private IDictionary<string, float> RegenTimerMods;
	
	public bool Inverted { get; set; }
	//display used for inverted stats like heat
	public float GetDisplay(){
		if(Inverted){
			return Total - Current;
		}else{
			return Current;
		}
	}
	public float GetRatio(){
		return GetDisplay() / Total;
	}
	public void AddPrecentMod(string _name, float _value){
		if(!PercentMods.ContainsKey(_name)){
			PercentMods.Add(_name, _value);
			RecalculateTotal();
		}
	}
	public void RemovePercentMod(string _name){
		if(PercentMods.ContainsKey(_name)){
			PercentMods.Remove(_name);
			RecalculateTotal();
		}
	}
	public void AddFlatMod(string _name, float _value){
		if(!FlatMods.ContainsKey(_name)){
			FlatMods.Add(_name, _value);
			RecalculateTotal();
		}
	}
	public void RemoveFlatMod(string _name){
		if(FlatMods.ContainsKey(_name)){
			FlatMods.Remove(_name);
			RecalculateTotal();
		}
	}
	public void RecalculateTotal(){
		float ratio = Current / Total;
		CalculateTotal();
		Current = ratio * Total;
	}
	public void CalculateTotal(){
		float temp = Base;
		foreach(KeyValuePair<string, float> flatPair in FlatMods){
			temp += flatPair.Value;
		}
		//other = 1;
		foreach(KeyValuePair<string, float> percentPair in PercentMods){
			temp *= percentPair.Value;
			//other *= (1 - percentPair.Value / halfValue)
		}
		//other = 1 - other;
		//temp *= other;
		Total = temp;
	}
	public void AddRegenTimerMod(string _name, float _value){
		if(!RegenTimerMods.ContainsKey(_name)){
			RegenTimerMods.Add(_name, _value);
			RecalculateRegenTimer();
		}
	}
	public void RemoveRegenTimerMod(string _name){
		if(RegenTimerMods.ContainsKey(_name)){
			RegenTimerMods.Remove(_name);
			RecalculateRegen();
		}
	}
	public void AddRegenMod(string _name, float _value){
		if(!RegenMods.ContainsKey(_name)){
			RegenMods.Add(_name, _value);
			RecalculateRegen();
		}
	}
	public void RemoveRegenMod(string _name){
		if(RegenMods.ContainsKey(_name)){
			RegenMods.Remove(_name);
			RecalculateRegen();
		}
	}
	public void RecalculateRegen(){
		float temp = Regen;
		//other = 1;
		foreach(KeyValuePair<string, float> regenPair in RegenMods){
			temp *= regenPair.Value;
			//other *= (1 - percentPair.Value / halfValue)
		}
		//other = 1 - other;
		//temp *= other;
		RegenTotal = temp;
	}
	public void RecalculateRegenTimer(){
		float temp = RegenTimer;
		//other = 1;
		foreach(KeyValuePair<string, float> regenTimerPair in RegenTimerMods){
			temp *= regenTimerPair.Value;
			//other *= (1 - percentPair.Value / halfValue)
		}
		//other = 1 - other;
		//temp *= other;
		RegenTimer = temp;
	}
	public void Full(){
		Current = Total;
	}
	public void CheckCurrent(){
		if(Current > Total){
			Current = Total;
		}
		if(Current < 0){//hard coded to 0, change to a "lowest value"
			Current = 0;
		}
	}
	public bool AlterCurrent(float _val){
		Current += _val;
		return true;
		/*
		if(current + _val > 0){//hard coded to 0, change to a "lowest value"
			current += _val;
			return true;
		}else{
			current += _val;
			CheckCurrent();
		}
		return false;
		*/
	}
	//constructors
	public Stat(){
		FlatMods = new Dictionary<string, float>();
		PercentMods = new Dictionary<string, float>();
		RegenMods = new Dictionary<string, float>();
		RegenTimerMods = new Dictionary<string, float>();
		Base = 100f;
		RegenTimer = RegenTimeBase;
		CalculateTotal();
		Full();
	}
	public Stat(float _base){
		FlatMods = new Dictionary<string, float>();
		PercentMods = new Dictionary<string, float>();
		RegenMods = new Dictionary<string, float>();
		RegenTimerMods = new Dictionary<string, float>();
		Base = _base;
		RegenTimer = RegenTimeBase;
		CalculateTotal();
		Full();
		
	}
}
