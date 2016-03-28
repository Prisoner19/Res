using UnityEngine;
using System.Collections;

namespace Soldier
{
    public class Rendering : MonoBehaviour 
    {
        private Soldier.Info obj_soldier;

        private Animator comp_animator;

        private SpriteRenderer sprRnd_marker;

        // Use this for references
        void Awake()
        {
            obj_soldier = gameObject.GetComponent<Soldier.Info>();
            comp_animator = gameObject.GetComponent<Animator>();
            sprRnd_marker = gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        }

        // Use this for initialization
        void Start () 
        {
            Change_To_Idle();
        }
        
        // Update is called once per frame
        void Update () 
        {
        
        }

        public void Change_To_Shooting()
        {
            comp_animator.SetTrigger("is_shooting");
        }

        public void Change_To_Idle()
        {
            
        }

        public void Change_To_Reloading()
        {
            comp_animator.SetTrigger("is_reloading");
        }

        public void Change_To_Attack_With_Knife()
        {
            comp_animator.SetTrigger("is_knifing");
        }

        public void Change_To_Selected()
        {
            sprRnd_marker.enabled = true;
        }

        public void Change_To_Unselected()
        {
            sprRnd_marker.enabled = false;
        }
    }
}