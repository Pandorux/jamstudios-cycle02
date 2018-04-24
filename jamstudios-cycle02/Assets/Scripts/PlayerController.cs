using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public static PlayerController instance = null;

    #region Subclasses

    [System.Serializable]
    public class CombatController
    {
        #region Variables

        public float attackDamage;
        public float attackSpeed;
        public float attackCooldown;
        public Animator weaponAnimator;

        private float nextAttackTime = 0.0f;

        #endregion

        #region Methods

        public void Attack() 
        {
            weaponAnimator.Play("playerAttack");
            nextAttackTime = Time.time + attackCooldown;
        }

        public bool CanAttack()
        {
            if (nextAttackTime <= Time.time)
                return true;
            else
                return false;
        }

        #endregion
    }

    #endregion

    public CombatController combat;

	void Awake () 
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(combat.CanAttack() && Time.timeScale != 0) 
            {
                combat.Attack();
            }
        }
    }
}
