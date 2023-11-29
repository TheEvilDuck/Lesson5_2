using UnityEngine.InputSystem;

public class WalkingState : RunningState
{
    public WalkingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Data.Speed = config.Speed*config.WalkSpeedMultiplier;
    }

    protected override void AddInputActionsCallbacks()
    {
        base.AddInputActionsCallbacks();

        Input.Movement.Sprint.canceled+=OnSprintButtonHeld;
        Input.Movement.Walk.canceled+=OnWalkButtonUp;
    }

    protected override void RemoveInputActionsCallback()
    {
        base.RemoveInputActionsCallback();

        Input.Movement.Sprint.canceled-=OnSprintButtonHeld;
        Input.Movement.Walk.canceled-=OnWalkButtonUp;
    }

    private void OnSprintButtonHeld(InputAction.CallbackContext obj) => StateSwitcher.SwitchState<FastRunningState>();
    private void OnWalkButtonUp(InputAction.CallbackContext obj) => StateSwitcher.SwitchState<RunningState>();
}
