using System.Collections.Generic;
using System.Linq;
using R3;

public class ScoreObserver : IObserver {
    private readonly ScoreModel _scoreModel;
    private readonly ScoreView _scoreView;

    public ScoreObserver(ScoreModel scoreModel, List<IObservable> view) {
        _scoreModel = scoreModel;
        _scoreView = view.OfType<ScoreView>().FirstOrDefault();
    }

    public void StartObserv() {
        _scoreModel.ScoreValueProperty.Subscribe(_scoreView.UpdateTextValue);
    }
}
