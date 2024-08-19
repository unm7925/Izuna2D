using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : PlayerAirState
{
    public PlayerFallState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.player.animationData.fallParameterHash);
    }

    public override void Exit()
    {
        if (IsGround()) stateMachine.player.fallDust.Play();
        base.Exit();
        StopAnimation(stateMachine.player.animationData.fallParameterHash);
    }

    public override void Update()
    {
        base.Update();

        if (IsGround())
        {
            stateMachine.ChangeState(stateMachine.idleState);
            return;
        }
    }
}
