using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Script.PlayerComponent
{
    [RequireComponent(typeof(Player))]
    public class PlayerController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] Player player;
        [SerializeField] Joystick joyStick;

        public bool IsMove()
        {
            player.Flip(joyStick.Horizontal > 0);
            return joyStick.Direction.magnitude > 0.01f;
        }

        public void Move()
        {
            Vector3 direct = joyStick.Direction.normalized;
            transform.position += direct * player.Stats.Speed * Time.deltaTime;
        }

    }
}


