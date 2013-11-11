using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CombatManager {
	
	private CombatManager instance;
	
	public CombatManager(){
	}
	
	public static CombatManager Instance {
		get {
			if (instance == null) {
				instance = new CombatManager();
			}
			return instance;
		}
	}
	
	public void Evaluate(Character _target, IList<Act> _acts){
		//resolve an action
		foreach(Act _act in _acts){
			EvaluateAct(_target, _act);
		}
	}
	void EvaluateAct(Charcter _target, Act _act){
		switch(_act.name){
		case "AlterHullValue":
			_target
			break;
		case "AlterShieldValue":
			break;
		default:
			break;
		}
	}
	/*
	public void EvaluateActions(IList<Act> _acts){
		foreach(Act _act in _acts){
			EvaluateAct(_act);
		}
	}
	void EvaluateAct(Act _act){
		Debug.Log("" + _act.name);
		switch(_act.name){
		default:
			break;
		}
	}
	*/
}


public class Action {
	
	public IList<Act> onHitAct;
	public IList<Act> onCastAct;
	
	public Action(){
		onHitAct = new List<Act>();
		onCastAct = new List<Act>();
	}
	
	public void OnHit(/* trarget */ Character _target){
		CombatManager.Instance.Evaluate(_target, onHitAct);
	}
	
	public void AddOnHit(Act _act){
		onHitAct.Add(_act);
	}
	public void OnCast(/* target */ Character _self){
		CombatManager.Instance.Evaluate(_self, onCastAct);
	}
	
	public void AddOnCast(Act _act){
		onCastAct.Add(_act);
	}
}

public struct Act{
	public string name;
	public ArrayList paramList;
	public ArrayList actList;
	//public Act positive;
	//public Act negative;
	public Act(string _name, ArrayList _param, ArrayList _actList){
		name = _name;
		paramList = _param;
		actList = _actList;
	}
}
public static Act TestingAct = new Act("Damage", new ArrayList(new[] {100, 333}), new ArrayList(new[] {}));

/*
player activates ability
ability evaluates OnCast actions
	target types: self, area
action types conditional and nonconditional
*/
