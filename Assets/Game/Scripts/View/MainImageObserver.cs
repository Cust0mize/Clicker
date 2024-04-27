using System.Collections.Generic;
using System.Linq;
using R3;

public class MainImageObserver : IObserver {
    private readonly LevelModel _levelModel;
    private MainImageView _mainImageView;

    public MainImageObserver(LevelModel levelModel, List<IObservable> view) {
        _mainImageView = view.OfType<MainImageView>().FirstOrDefault();
        _levelModel = levelModel;
    }

    public void StartObserv() {
        _levelModel.CurrentLevelProperty.Subscribe(_mainImageView.UpdateImage);
        _levelModel.LevelUpdate += _mainImageView.SoundPlay;
    }
}