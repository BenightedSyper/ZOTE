using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CombatManager {
	
	CharacterStatScript parent;
	
	public CombatManager(CharacterStatScript _parent){
		parent = _parent;
	}
	
	public void EvaluateActions(IList<Act> _acts){
		foreach(Act _act in _acts){
			EvaluateAct(_act);
		}
	}
	void EvaluateAct(Act _act){
		Debug.Log("" + _act.name);
		switch(_act.name){
		case "AlterFatigue":
			//fatigue damage to caster
			parent.fatigue.AlterStatCurrent((int)_act.paramList[0]);
			break;
		case "AlterFocus":
			//focus damage to caster
			parent.focus.AlterStatCurrent((int)_act.paramList[0]);
			break;
		case "AlterHealth":
			//health damage to caster
			parent.health.AlterStatCurrent((int)_act.paramList[0]);
			break;
		case "ConditionalSelfHealthGreaterThanPercent":
			if((float)parent.health.StatCurrent/(float)parent.health.StatModed > (float) _act.paramList[0]){
				EvaluateAct((Act)_act.actList[0]);
			}else{
				EvaluateAct((Act)_act.actList[1]);
			}
			break;
		default:
			break;
		}
	}
}


public class Action {
	
	public IList<Act> onHitAct;
	public IList<Act> onCastAct;
	
	public Action(){
		onHitAct = new List<Act>();
		onCastAct = new List<Act>();
	}
	
	public void OnHit(){
	}
	
	public void AddOnHit(Act _act){
		onHitAct.Add(_act);
	}
	public void OnCast(){
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
