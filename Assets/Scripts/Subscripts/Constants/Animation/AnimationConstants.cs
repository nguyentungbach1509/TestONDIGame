using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Script.Subscript.Constants
{
    public enum AnimationKey
    {
        Atk,
        AtkRange,
        Idle,
        Move,
        Die,
        Spell,
    }

    public static class AnimationConstants
    {
        private static readonly Dictionary<AnimationKey, int> HashIds = new Dictionary<AnimationKey, int>();

        // Khởi tạo các hash ID
        static AnimationConstants()
        {
            foreach (AnimationKey key in Enum.GetValues(typeof(AnimationKey)))
            {
                HashIds[key] = Animator.StringToHash(key.ToString());
            }
        }

        // Lấy Hash ID từ AnimationKey
        public static int GetHash(AnimationKey key)
        {
            return HashIds[key];
        }

        // Extension method để dễ sử dụng
        public static int Hash(this AnimationKey key)
        {
            return GetHash(key);
        }
    }
}


