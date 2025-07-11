using DG.Tweening;
using Game.Script.CharacterComponent;
using Game.Script.PlayerComponent;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Script.SpawnMechanic
{
    public class PlayerSpawner : Spawner
    {
        private Player player;
        private Tween rebornTween;

        public PlayerSpawner(GamePrefabs gamePrefabs) : base(gamePrefabs)
        {
        }

        public void SetPlayer(Player player)
        {
            this.player = player;
        }

        public void RebornPlayer(CharacterBase character)
        {
            rebornTween?.Kill();

            player.gameObject.SetActive(false);

            rebornTween = DOVirtual.DelayedCall(0.75f, () =>
            {
                player.ReTransform();
                player.Init();
                player.gameObject.SetActive(true);

                player.transform.localScale = Vector3.zero;
                player.transform.DOScale(Vector3.one, 0.3f)
                    .SetEase(Ease.OutBack);
            });
        }
    }
}

