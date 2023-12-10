using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class DefeatPanel : MonoBehaviour
{
    [SerializeField] private Button _restart;

    private GameplayMediator _mediator;

    private void OnEnable()
    {
        _restart.onClick.AddListener(OnRestartClick);
    }

    private void OnDisable()
    {
        _restart.onClick.RemoveListener(OnRestartClick);
    }

    [Inject]
    public void Constuct(GameplayMediator gameplayMediator)
    {
        _mediator = gameplayMediator;
    }

    public void Show() => gameObject.SetActive(true);

    public void Hide() => gameObject.SetActive(false);

    private void OnRestartClick() => _mediator.RestartLevel();
}
