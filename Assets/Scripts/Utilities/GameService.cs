using ServiceLocator.Events;
using ServiceLocator.Map;
using ServiceLocator.Player;
using ServiceLocator.Sound;
using ServiceLocator.UI;
using ServiceLocator.Wave;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameService : GenericMonoSingleton<GameService>
{
    [SerializeField] private PlayerScriptableObject playerScriptableObject;
    [SerializeField] private SoundScriptableObject soundScriptableObject;
    [SerializeField] private AudioSource audioEffects;
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private UIService uIService;
    [SerializeField] private EventService eventService;
    [SerializeField] private WaveScriptableObject waveScriptableObject;
    [SerializeField] private MapService mapService;
    
    public PlayerService playerService { get; private set; }
    public SoundService soundService { get; private set; }
    public UIService UIService => uIService;
    public WaveService waveService { get; private set; }
    public EventService EventService => eventService;
    public MapService MapService => mapService;
  
    private void Start()
    {
     
        playerService = new PlayerService(playerScriptableObject);
        soundService = new SoundService(soundScriptableObject, audioEffects, backgroundMusic);
      
        waveService = new WaveService(eventService, waveScriptableObject);
    }
    private void Update()
    {
        playerService.Update();
    }
}
