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
            UpdateGameState(GameState.Menu);
        }
        private void HandleMenu()
        {

        }
        private void HandlePlaying()
        {

        }
        private void HandlePaused()
        {

        }
        private void HandleDead()
        {

        }
        private void HandleLose()
        {

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