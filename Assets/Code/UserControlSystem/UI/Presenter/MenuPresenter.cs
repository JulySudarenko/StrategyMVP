using Interfaces;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MenuPresenter : MonoBehaviour
{
    [SerializeField] private Button _backButton;
    [SerializeField] private Button _exitButton;

    private ITimeModel _timeModel;
    
    [Inject] 
    private void Init(ITimeModel timeModel)
    {
        _timeModel = timeModel;

        _backButton.OnClickAsObservable().Subscribe(_ => BackToGame());
        _exitButton.OnClickAsObservable().Subscribe(_ => Application.Quit());
    }

    private void BackToGame()
    {
        gameObject.SetActive(false);
        _timeModel.ReturnToGame();
    }
}