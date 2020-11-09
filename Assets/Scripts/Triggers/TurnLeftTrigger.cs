using UnityEngine;


namespace Vagonetka
{
    public class TurnLeftTrigger : MonoBehaviour
    {
        private PlayerModel _player;

        private void OnTriggerEnter(Collider other)
        {
            _player = other.gameObject.GetComponent<PlayerModel>();

            if (_player != null)
            {
                if (_player.IsRotateLeft)
                {
                    _player.IsRotateLeft = false;
                }
                else if (!_player.IsRotateLeft)
                {
                    _player.IsRotateLeft = true;
                }
            }
        }
    }
}
