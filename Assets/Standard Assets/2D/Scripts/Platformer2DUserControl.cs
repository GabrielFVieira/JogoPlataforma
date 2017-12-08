using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
        public bool crouch;
        public bool desactive;
        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        private void Update()
        {
            if (!m_Jump && desactive == false)
            {
                // Read the jump input in Update so button presses aren't missed.
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    m_Jump = Input.GetKeyDown(KeyCode.UpArrow);
                }
                else if (Input.GetKeyDown(KeyCode.W))
                {
                    m_Jump = Input.GetKeyDown(KeyCode.W);
                }
            }
        }


        private void FixedUpdate()
        {
            if (desactive == false)
            {
                // Read the inputs.
                crouch = Input.GetKey(KeyCode.DownArrow);

                if (Input.GetKey(KeyCode.S))
                    crouch = true;

                float h = CrossPlatformInputManager.GetAxis("Horizontal");
                // Pass all parameters to the character control script.
                m_Character.Move(h, crouch, m_Jump);
                m_Jump = false;
            }
        }

        public void OnTriggerEnter2D(Collider2D col)
        {
            if(col.gameObject.tag == "Ramp")
            {
                desactive = true;
            }
        }

        public void OnTriggerExit2D(Collider2D col)
        {
            if (col.gameObject.tag == "Ramp")
            {
                desactive = false;
            }
        }
    }
}
