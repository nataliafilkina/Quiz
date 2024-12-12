using Gameplay;
using Gameplay.Card;
using UI;
using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    [SerializeField]
    private GameSettings _gameSettings;

    [SerializeField]
    private GameObject _cardPrefab;

    public override void InstallBindings()
    {
        Container.Bind<GameSettings>().FromInstance(_gameSettings).AsSingle();
        Container.Bind<GameState>().FromNew().AsSingle().NonLazy();

        Container.BindFactory<CardData, Transform, UICard, UICard.Factory>().FromComponentInNewPrefab(_cardPrefab);
    }
}
