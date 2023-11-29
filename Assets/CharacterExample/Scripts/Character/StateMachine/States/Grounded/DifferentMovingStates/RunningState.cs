using UnityEngine.InputSystem;

public class RunningState : GroundedState
{
    protected readonly RunningStateConfig config;

    private bool _sprint;
    private bool _walk;

    public RunningState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => config = character.Config.RunningStateConfig;

    public override void Enter()
    {
        base.Enter();

        View.StartRunning();
        Data.Speed = config.Speed;
    }

    public override void Exit()
    {
        base.Exit();

        View.StopRunning();
    }

    public override void Update()
    {
        base.Update();

        if (IsHorizontalInputZero())
            StateSwitcher.SwitchState<IdlingState>();

        if (_sprint)
            StateSwitcher.SwitchState<FastRunningState>();
        else if (_walk)
            StateSwitcher.SwitchState<WalkingState>();

    }

    public override void HandleInput()
    {
        base.HandleInput();

        _sprint = Input.Movement.Sprint.IsPressed();
        _walk = Input.Movement.Walk.IsPressed();
    }

    /*protected override void AddInputActionsCallbacks()
    {
        base.AddInputActionsCallbacks();

        Input.Movement.Sprint.triggered+=OnSprintButtonHeld;
        Input.Movement.Walk.triggered+=OnWalkButtonHeld;
    }

    protected override void RemoveInputActionsCallback()
    {
        base.RemoveInputActionsCallback();

        Input.Movement.Sprint.triggered-=OnSprintButtonHeld;
        Input.Movement.Walk.triggered-=OnWalkButtonHeld;
    }

    private void OnSprintButtonHeld() => StateSwitcher.SwitchState<FastRunningState>();
    private void OnWalkButtonHeld() => StateSwitcher.SwitchState<WalkingState>(); */
}
