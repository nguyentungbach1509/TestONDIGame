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
        [SerializeField] WaveText waveText;

        public void Init()
        {
            GameNormalMode.OnWaveChange -= UpdateTxt;
            GameNormalMode.OnWaveChange += UpdateTxt;
            UpdateTxt(-1);
            timeScale.Init();
        }

        private void UpdateTxt(int currentWave)
        {
            if(currentWave == -1)
            {
                waveText.ShowStageText("Preparing Time");
                return;
            }
            waveText.ShowStageText($"Wave: {currentWave}");
        }
    }
}

