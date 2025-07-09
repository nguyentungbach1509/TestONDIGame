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
        [SerializeField] Rigidbody2D rb;

        [Header("Settings")]
        [SerializeField] float atkMeleeRange;
        [SerializeField] float atkRange;

        public bool IsMove()
        {
            player.Flip(joyStick.Horizontal > 0);
            return joyStick.Direction.magnitude > 0.01f;
        }

        public void Move()
        {
            Vector2 direct = joyStick.Direction.normalized;
            Vector2 newPosition = rb.position + direct * Time.fixedDeltaTime * player.Stats.Speed;
            Vector3 viewPort = Camera.main.WorldToViewportPoint(newPosition);
            viewPort.x = Mathf.Clamp(viewPort.x, 0.05f, 0.95f); //chừa chút lề
            viewPort.y = Mathf.Clamp(viewPort.y, 0.05f, 0.95f);
            newPosition = Camera.main.ViewportToWorldPoint(viewPort);

            rb.MovePosition(newPosition);
        }


    }
}


