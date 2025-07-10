using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Script.AbilityComponent
{
    public class Ability
    {
        private int id;
        private string key;
        private string description;
        private float cooldownTime;
        private Sprite sprite;
        private EAbilitType abilitType;

        public int Id => id;
        public string Key => key;
        public string Description => description;
        public float CooldownTime => cooldownTime;
        public Sprite Sprite => sprite;
        public EAbilitType AbilitType => abilitType;

        public Ability(AbilityData data)
        {
            id = data.Id;
            key = data.Key;
            description = data.Description;
            cooldownTime = data.CooldownTime;
            sprite = data.Sprite;
            abilitType = data.AbilitType;
        }
    }
}

