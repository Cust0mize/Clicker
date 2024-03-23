using System.Collections.Generic;
using System.Linq;
using R3;

public class LevelProgressBarObserver : IObserver {
    private readonly LevelProgressBarView _levelProgressBarView;
    private readonly LevelModel _levelModel;

    public LevelProgressBarObserver(LevelModel levelModel, List<IObservable> view) {
        _levelProgressBarView = view.OfType<LevelProgressBarView>().FirstOrDefault();
        _levelModel = levelModel;
    }

    public void StartObserv() {
        _levelModel.LevelPrecentProperty.Subscribe(_levelProgressBarView.UpdateBar);
    }
}