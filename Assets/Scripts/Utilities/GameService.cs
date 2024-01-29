using ServiceLocator.Player;
using ServiceLocator.Sound;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameService : GenericMonoSingleton<GameService>
{
    [SerializeField] private PlayerScriptableObject playerScriptableObject;
    [SerializeField] private SoundScriptableObject soundScriptableObject;
    [SerializeField] private AudioSource audioEffects;
    [SerializeField] private AudioSource backgroundMusic;
    public PlayerService playerService { get; private set; }
    public SoundService soundService { get; private set; }
    private void Start()
    {
        playerService = new PlayerService(playerScriptableObject);
        soundService = new SoundService(soundScriptableObject, audioEffects, backgroundMusic);
    }
    private void Update()
    {
        playerService.Update();
    }
}
