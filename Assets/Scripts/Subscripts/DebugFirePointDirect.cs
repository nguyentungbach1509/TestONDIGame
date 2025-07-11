using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.Script.SubScripts
{
    public class DebugFirePointDirect : MonoBehaviour
    {
        void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, transform.position + transform.up * 2f);
        }
    }
}

