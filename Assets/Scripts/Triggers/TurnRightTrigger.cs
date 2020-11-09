using UnityEngine;


namespace Vagonetka
{
    public class TurnRightTrigger : MonoBehaviour
    {
        private PlayerModel _player;

        private void OnTriggerEnter(Collider other)
        {
            _player = other.gameObject.GetComponent<PlayerModel>();

            if (_player != null)
            {
                if (_player.IsRotateRight)
                {
                    _player.IsRotateRight = false;
                }
                else if (!_player.IsRotateRight)
                {
                    _player.IsRotateRight = true;
                }
            }
        }
    }

}