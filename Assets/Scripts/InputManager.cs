using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager
{
    private static Controls _ctrls;


    public static void Init(BallController b)
    {
        _ctrls = new();



     _ctrls.InGame.startGame.performed += _ =>
       {
          b.startGame();
    };
       _ctrls.InGame.SwitchAxisMovement.performed += _ =>
        {
            b.SwitchAxisMovement();
       };

    }

    public static void EnableInGame()
    {
        _ctrls.InGame.Enable();
    }

}