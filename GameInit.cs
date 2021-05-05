using Code.Data;
using UnityEngine;

namespace Code.Controllers
{
    internal sealed class GameInit
    {
        public GameInit(Controllers controllers, GameData data)
        {
            Camera camera = Camera.main;

            var inputInit = new InputController(); 
            
            var playerInit = new PlayerInitialize();
            playerInit.PlayerInit(data.Player);

            var bonusInit = new BonusInitialize();
            bonusInit.BonusInit(data.Bonus);

            var moveController = new MoveController(inputInit, playerInit.PlayerRoot, data.Player.defaultSpeed);

            var cameraController = new CameraController(playerInit.PlayerRoot, camera.transform);

            var collectController = new CollectController(bonusInit.bonuses, data.Player.playerPrefab);
            
            controllers.Add(inputInit);
            controllers.Add(playerInit);
            controllers.Add(bonusInit);
            controllers.Add(moveController);
            controllers.Add(cameraController);
            controllers.Add(collectController);
        }
    }
}