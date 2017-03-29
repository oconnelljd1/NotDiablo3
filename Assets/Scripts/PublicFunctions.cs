using UnityEngine;
using System.Collections;

public class PublicFunctions : MonoBehaviour {

	public WeaponController AttackFuntcion(WeaponController[] _weapons, HealthController _health, float _distance){
		WeaponController selectedAttack = null;
		float highestCooldown = 0;
		bool canAttack = false;
		for (int i = 0; i < _weapons.Length; i++) {
			if(_weapons[i].GetReach() < _distance){
				canAttack = true;
				break;
			}
		}
		if (!canAttack) {
			return selectedAttack;
		}
		canAttack = false;
		for(int i = 0; i < _weapons.Length; i++){
			if(_weapons[i].GetManaCost() < _health.GetCurrentMana()){
				selectedAttack = _weapons [i];
				highestCooldown = _weapons [0].GetAttackCoolDown ();
				canAttack = true;
				break;
			}
		}
		if (!canAttack) {
			return selectedAttack;
		}
		for(int i = 0; i < _weapons.Length; i++){
			if(_weapons[i].GetAttackCoolDown() > highestCooldown && _weapons[i].GetManaCost() < _health.GetCurrentMana() && _weapons[i].GetReach() > _distance){
				selectedAttack = _weapons [i];
				highestCooldown = _weapons [0].GetAttackCoolDown ();
			}
		}
		return selectedAttack;
		//selectedAttack.Attack();
	}

	public void MoveTowards(GameObject _victim, Vector3 _target, float _moveSpeed){
		_victim.transform.position = Vector3.MoveTowards (_victim.transform.position, _target, _moveSpeed *Time.deltaTime);
	}

	public bool ExitTrigger(Collider trigger, SphereCollider _radius){
		if(trigger.CompareTag("Player")){
			Vector3 Vdistance = transform.position - trigger.gameObject.transform.position;
			float distance = Vdistance.sqrMagnitude;
			if (distance > 5) {
				return true;
			}
		}
		return false;
	}
}


