using System.Text;
using Interfaces;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

public class GameOverScreenPresenter : MonoBehaviour
{
    [Inject] private IGameStatus _gameStatus;

    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private GameObject _view;

    [Inject]
    private void Init()
    {
        _gameStatus.Status.ObserveOnMainThread().Subscribe(result =>
        {
            var sb = new StringBuilder($"Game Over!\n");
            if (result == 0)
            {
                sb.AppendLine("Draw!");
            }
            else
            {
                sb.AppendLine($"Faction №{result} win!");
            }

            _view.SetActive(true);
            _text.text = sb.ToString();
            Time.timeScale = 0;
        });
    }
}
