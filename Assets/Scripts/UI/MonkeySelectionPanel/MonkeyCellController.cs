using UnityEngine;
using ServiceLocator.Player;

namespace ServiceLocator.UI
{
    public class MonkeyCellController
    {
        private PlayerService playerService;
        private MonkeyCellView monkeyCellView;
        private MonkeyCellScriptableObject monkeyCellSO;

        public MonkeyCellController(PlayerService playerService, Transform cellContainer, MonkeyCellView monkeyCellPrefab, MonkeyCellScriptableObject monkeyCellScriptableObject)
        {
            this.playerService = playerService;
            this.monkeyCellSO = monkeyCellScriptableObject;
            monkeyCellView = Object.Instantiate(monkeyCellPrefab, cellContainer);
            monkeyCellView.SetController(this);
            monkeyCellView.ConfigureCellUI(monkeyCellSO.Sprite, monkeyCellSO.Name, monkeyCellSO.Cost);
        }

        public void MonkeyDraggedAt(Vector3 dragPosition)
        {
            playerService.ValidateSpawnPosition(monkeyCellSO.Cost, dragPosition);
        }

        public void MonkeyDroppedAt(Vector3 dropPosition)
        {
            Debug.Log("MonkeyDroppedAt");
            playerService.TrySpawningMonkey(monkeyCellSO.Type, monkeyCellSO.Cost, dropPosition);
        }
    }
}