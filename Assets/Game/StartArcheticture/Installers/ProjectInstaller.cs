using Assets.Game.StartArcheticture.Managers;
using Assets.Game.StartArcheticture.Save_System;
using Assets.Game.StartArcheticture.Services;
using Assets.Game.StartArcheticture.UI;
using UnityEngine;
using Zenject;

namespace Assets.Game.StartArcheticture.Installers {
    [RequireComponent(typeof(CheatManager), typeof(AudioMixerManager), typeof(GlobalAsyncProcessor))]
    public class ProjectInstaller : MonoInstaller {
        public override void InstallBindings() {
            Container.Bind<AudioMixerManager>().FromComponentInHierarchy().AsTransient().NonLazy();
            Container.Bind<GlobalAsyncProcessor>().FromNewComponentOnNewGameObject().AsSingle();
            Container.Bind<CheatManager>().FromComponentInHierarchy().AsTransient().NonLazy();
            Container.Bind<ParticleAnimationService>().AsSingle().NonLazy();
            Container.Bind<WindowShowHideAnimation>().AsSingle().NonLazy();
            Container.Bind<ResourceLoaderService>().AsSingle().NonLazy();
            Container.Bind<LocalizationService>().AsSingle().NonLazy();
            Container.Bind<SceneLoaderService>().AsSingle().NonLazy();
            Container.Bind<ConfigService>().AsSingle().NonLazy();
            Container.Bind<SaveSystem>().AsSingle().NonLazy();
            Container.Bind<GameData>().AsSingle().NonLazy();
        }
    }
}