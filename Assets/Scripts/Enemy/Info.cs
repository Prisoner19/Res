using UnityEngine;
using System.Collections;

namespace Enemy
{
    public class Info : MonoBehaviour 
    {
        private Movement obj_movement;

        // Use this for references
        void Awake()
        {
            obj_movement = gameObject.GetComponent<Movement>();
        }

        // Use this for initialization
        void Start () 
        {
        
        }
        
        // Update is called once per frame
        void Update () 
        {
        
        }

        public void Get_Killed()
        {
            Destroy(this.gameObject);
        }
    }
}
