using UnityEngine;
using System.Collections;

namespace Soldier
{
    public class Attacking : MonoBehaviour 
    {
        private Soldier.Info obj_soldier;

        private int current_ammo;
        private bool can_attack;

        void Awake()
        {
            obj_soldier = gameObject.GetComponent<Soldier.Info>();
        }

        void Start () 
        {
            can_attack = true;
            current_ammo = 6;
        }
        
        void Update () 
        {
        
        }

        public bool Attack(Vector3 enemy_position)
        {
            float distance = Vector3.Distance(gameObject.transform.position, enemy_position);
            return Try_To_Shoot();
    //		if(distance < 150)
    //		{
    //			Start_To_Attack_With_Melee();
    //			return true;
    //		}
    //		else
    //		{
    //			return Try_To_Shoot();
    //		}
        }

        private void Start_To_Attack_With_Melee()
        {
            can_attack = false;
            obj_soldier.Get_Rendering().Change_To_Attack_With_Knife();
        }

        private void Attack_With_Melee()
        {
            obj_soldier.Get_Sound_Player().Play_Knife_Sound();
        }

        private void Finish_To_Attack_With_Melee()
        {
            can_attack = true;
        }

        private bool Try_To_Shoot()
        {
            bool success = can_attack;

            if(can_attack)
            {
                Start_To_Fire_Weapon();
            }

            return success;
        }
            
        private void Start_To_Fire_Weapon()
        {
            can_attack = false;
            Fire_Weapon();
            obj_soldier.Set_State(SoldierState.Shooting);
            obj_soldier.Get_Rendering().Change_To_Shooting();
            obj_soldier.Get_Sound_Player().Play_Shot_Sound();
        }

        private void Fire_Weapon()
        {
            Decrease_Ammo();
        }

        private void Finish_Firing_Weapon()
        {
            if(Is_Out_Of_Ammo())
            {
                Reload_Weapon();
            }
            else
            {
                obj_soldier.Get_Rendering().Change_To_Idle();
                can_attack = true;
                obj_soldier.Set_State(SoldierState.Idle);
            }
        }

        private void Reload_Weapon()
        {
            obj_soldier.Get_Rendering().Change_To_Reloading();
            obj_soldier.Set_State(SoldierState.Reloading);
            obj_soldier.Get_Sound_Player().Play_Reload_Sound();
        }

        private void Finish_Reloading_Weapon()
        {
            current_ammo = 6;
            obj_soldier.Get_Rendering().Change_To_Idle();
            obj_soldier.Set_State(SoldierState.Idle);
            can_attack = true;
        }

        private void Decrease_Ammo()
        {
            current_ammo = (current_ammo > 0) ? current_ammo - 1 : 0;
        }

        private bool Is_Out_Of_Ammo()
        {
            return (current_ammo == 0);
        }
    }
}
