using UnityEngine;
namespace Game.Script.Subscripts
{
    public class SortingSprite : MonoBehaviour
    {
        [SerializeField] SpriteRenderer spriteRenderer;

        void LateUpdate()
        {
            spriteRenderer.sortingOrder = Mathf.RoundToInt(-transform.position.y * 100);
        }
    }
}

