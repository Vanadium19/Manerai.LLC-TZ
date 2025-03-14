using Game.GameSystems.Inputs;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Gameplay
{
    [CreateAssetMenu(fileName = "GameSceneInstaller",
        menuName = "Zenject/New GameSceneInstaller")]
    public class GameSceneInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            InputInstaller.Install(Container);
        }
    }
}