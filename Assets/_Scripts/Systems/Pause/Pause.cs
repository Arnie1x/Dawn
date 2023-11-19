using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    // Input
    private InputSystem controls;
    private GameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        controls = InputSystem.Instance;
        manager = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if(controls.pauseAction.ReadValue<float>() > 0) {
            if(manager.State == GameState.Playing){
                manager.UpdateGameState(GameState.Paused);
                return;
            }
            else{
                manager.UpdateGameState(GameState.Playing);
                return;
            }
        }
    }
}
