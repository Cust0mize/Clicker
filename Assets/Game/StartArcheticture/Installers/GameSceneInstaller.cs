using Assets.Game.StartArcheticture.UI;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(UIService))]
public class GameSceneInstaller : MonoInstaller {
    //[SerializeField] private ScreenBlurController _screenBlurController;
    [SerializeField] private ShopItems[] _shopItems;
    [SerializeField] private Level[] _levels;

    public override void InstallBindings() {
        Container.Bind<UIService>().FromComponentInHierarchy().AsTransient().NonLazy();     //� ���� ���� ������ �� �����, ������� ����� ������ ���������� � ������ �����, ���� ������� ������ ������ � ����� ����� � ��������� � ��������.
        //Container.Bind<ScreenBlurController>().FromInstance(_screenBlurController).AsSingle().NonLazy();
        Container.Bind<ScoreModel>().AsSingle().NonLazy();
        Container.Bind<IObserver>().To(x => x.AllNonAbstractClasses().DerivingFrom<IObserver>()).AsSingle().NonLazy();
        Container.Bind<IObservable>().FromComponentsInHierarchy().AsCached().NonLazy();
        Container.Bind<Level[]>().FromInstance(_levels).AsCached().NonLazy();
        Container.Bind<ShopItems[]>().FromInstance(_shopItems).AsCached().NonLazy();
        Container.Bind<LevelModel>().AsSingle().NonLazy();
    }
}
