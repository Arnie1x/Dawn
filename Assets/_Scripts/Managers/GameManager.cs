using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Application = UnityEngine.Device.Application;

public class GameManager: Singleton<GameManager>
    {
        public GameObject player;

        public GameState State { get; private set; }

        public static event Action<GameState> OnGameStateChanged;

        private void Start()
        {
            UpdateGameState(GameState.Starting);
        }

        public void UpdateGameState(GameState newState)
        {
            State = newState;

            OnGameStateChanged?.Invoke(newState);

            switch (newState)
            {
                case GameState.Starting:
                    HandleStarting();
                    break;
                case GameState.Menu:
                    HandleMenu();
                    break;
                case GameState.Playing:
                    HandlePlaying();
                    break;
                case GameState.Paused:
                    HandlePaused();
                    break;
                case GameState.Dead:
                    HandleDead();
                    break;
                case GameState.Lose:
                    HandleLose();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
            }
        }


        private void HandleStarting()
        {
            UpdateGameState(GameState.Playing);
            Time.timeScale = 1;
        }
        private void HandleMenu()
        {
            Time.timeScale = 1;
        }
        private void HandlePlaying()
        {
            Time.timeScale = 1;
        }
        private void HandlePaused()
        {
            Time.timeScale = 0;
        }
        private void HandleDead()
        {
            Time.timeScale = 1;
        }
        private void HandleLose()
        {
            Time.timeScale = 1;
        }
    }

public enum GameState
{
    Starting,
    Menu,
    Playing,
    Paused,
    Dead,
    Lose
}