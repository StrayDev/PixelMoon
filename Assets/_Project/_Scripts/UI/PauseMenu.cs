﻿using PixelMoon.Core;
using UnityEngine;

namespace PixelMoon.UI
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject pauseMenu;

        void Start()
        {
            pauseMenu.SetActive(false);    
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GameState.IsPaused)
                {
                    ResumeGame();
                }
                else
                {
                    PauseGame();
                }
            }
        }

        public void PauseGame()
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            GameState.Set(GameStates.IsPaused);
        }

        public void ResumeGame()
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            GameState.ReturnToPreviousState();
        }
    }
}
