using UnityEngine;
using Zenject;

public class GameplayMediator : MonoBehaviour
{
    private DefeatPanel _defeatPanel;
    private Level _level;

    private void OnDisable()
    {
        _level.Defeat -= OnLevelDefeat;
    }

    [Inject]
    public void Construct(Level level,DefeatPanel defeatPanel)
    {
        _defeatPanel = defeatPanel;
        _level = level;
        _level.Defeat += OnLevelDefeat;
    }

    private void OnLevelDefeat() => _defeatPanel.Show();

    public void RestartLevel()
    {
        _defeatPanel.Hide();
        _level.Restart();
    }
}
