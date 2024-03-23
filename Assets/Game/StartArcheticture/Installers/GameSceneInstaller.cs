using Assets.Game.StartArcheticture.UI;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(UIService))]
public class GameSceneInstaller : MonoInstaller {
    [SerializeField] private ScreenBlurController _screenBlurController;

    public override void InstallBindings() {
        Container.Bind<UIService>().FromComponentInHierarchy().AsTransient().NonLazy();     //� ���� ���� ������ �� �����, ������� ����� ������ ���������� � ������ �����, ���� ������� ������ ������ � ����� ����� � ��������� � ��������.
        //Container.Bind<ScreenBlurController>().FromInstance(_screenBlurController).AsSingle().NonLazy();
        Container.Bind<ScoreModel>().AsSingle().NonLazy();
        //Container.Bind<ScoreView>().FromComponentInHierarchy().AsSingle().NonLazy();
        Container.Bind<IObserver>().To(x => x.AllNonAbstractClasses().DerivingFrom<IObserver>()).AsSingle().NonLazy();
        Container.Bind<IObservable>().FromComponentInHierarchy().AsCached().NonLazy();
    }
}
