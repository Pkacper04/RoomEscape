using UnityEngine;
namespace RoomEscape.Player
{
    public class PlayerData : MonoBehaviour
    {
        static public bool key { get; set; }

        private void Awake()
        {
            key = false;
        }

    }
}
