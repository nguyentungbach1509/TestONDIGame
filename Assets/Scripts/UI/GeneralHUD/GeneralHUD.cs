using Game.Script.GamePlay;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Game.Script.UI
{
    public class GeneralHUD : MonoBehaviour
    {
        [SerializeField] TimeScale timeScale;
        [SerializeField] TMP_Text waveText;

        public void Init()
        {
            GameNormalMode.OnWaveChange -= UpdateTxt;
            GameNormalMode.OnWaveChange += UpdateTxt;
            waveText.text = "Preparing Wave";
            timeScale.Init();
        }

        private void UpdateTxt(int currentWave)
        {
            if(currentWave == -1)
            {
                waveText.text = "Preparing Wave";
                return;
            }
            waveText.text = $"Wave: {currentWave}";
        }
    }
}

