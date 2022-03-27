using UnityEngine;
using Zenject;
using RoomEscape.UI;

public class ZenjectScript : MonoInstaller
{

    [SerializeField] PanelsManager panelsManager;
    public override void InstallBindings()
    {
        Container.Bind<PanelsManager>().FromInstance(panelsManager);
    }
}