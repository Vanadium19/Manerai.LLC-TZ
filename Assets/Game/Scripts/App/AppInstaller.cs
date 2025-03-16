using UnityEngine;
using Zenject;

namespace Game.Scripts.App
{
    [CreateAssetMenu(fileName = "AppInstaller",
        menuName = "Zenject/New AppInstaller")]
    public class AppInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private string _uri = "https://wadahub.manerai.com/api/inventory/status";
        [SerializeField] private string _token = "kPERnYcWAY46xaSy8CEzanosAgsWM84Nx7SKM4QBSqPq6c7StWfGxzhxPfDh8MaP";

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<BackpackClient>()
                .AsSingle()
                .WithArguments(_uri, _token);
        }
    }
}