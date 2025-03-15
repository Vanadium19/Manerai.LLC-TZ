using Game.GameObjects.Content.Handle;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Gameplay
{
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField] private Transform _handle;

        public override void InstallBindings()
        {
            HandleInstaller.Install(Container, _handle);
        }
    }
}