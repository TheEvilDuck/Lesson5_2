using UnityEngine.InputSystem;

public class FastRunningState : RunningState
{
    public FastRunningState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Data.Speed = config.Speed*config.FastRunSpeedMultiplier;
    }

    protected override void AddInputActionsCallbacks()
    {
        base.AddInputActionsCallbacks();

        Input.Movement.Sprint.canceled+=OnSprintButtonUp;
        Input.Movement.Walk.canceled+=OnWalkButtonHeld;
    }

    protected override void RemoveInputActionsCallback()
    {
        base.RemoveInputActionsCallback();

        Input.Movement.Sprint.canceled-=OnSprintButtonUp;
        Input.Movement.Walk.canceled-=OnWalkButtonHeld;
    }

    private void OnSprintButtonUp(InputAction.CallbackContext obj) => StateSwitcher.SwitchState<RunningState>();
    private void OnWalkButtonHeld(InputAction.CallbackContext obj) => StateSwitcher.SwitchState<WalkingState>();
}
