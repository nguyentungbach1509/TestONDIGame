using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.Script.AbilityComponent
{
    public enum EAbilitType
    {
        Active,
        Passive
    }

    [CreateAssetMenu(fileName = "Ability Data", menuName = "Data/Ability")]
    public class AbilityData : ScriptableObject
    {
        [SerializeField] int id;
        [SerializeField] string key;
        [SerializeField] string description;
        [SerializeField] float cooldownTime;
        [SerializeField] Sprite sprite;
        [SerializeField] EAbilitType abilitType;

        public int Id => id;
        public string Key => key;
        public string Description => description;
        public float CooldownTime => cooldownTime;
        public Sprite Sprite => sprite;
        public EAbilitType AbilitType => abilitType;
    }
}

