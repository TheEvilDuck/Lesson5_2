using Zenject;

public class LevelInstaller: MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<Level>().AsSingle();
    }
}
