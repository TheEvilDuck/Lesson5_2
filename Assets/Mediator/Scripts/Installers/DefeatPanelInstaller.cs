using UnityEngine;
using Zenject;

public class DefeatPanelInstaller : MonoInstaller
{
    [SerializeField]private DefeatPanel _defeatPanel;
    public override void InstallBindings()
    {
        Container.Bind<DefeatPanel>().FromInstance(_defeatPanel);
    }
}
