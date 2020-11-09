using UnityEngine;


namespace Vagonetka
{
    public class AlignmentTrigger : MonoBehaviour
    {
        private PlayerModel _player;

        private void OnTriggerEnter(Collider other)
        {
            _player = other.gameObject.GetComponent<PlayerModel>();

            if (_player != null)
            {
                if (transform.rotation.eulerAngles.y == 0 || transform.rotation.eulerAngles.y == 180)
                {
                    _player.AlignByX(transform.position.x);
                }
                else if (transform.rotation.eulerAngles.y == 90 || transform.rotation.eulerAngles.y == 270)
                {
                    _player.AlignByZ(transform.position.z);
                }
            }
        }
    }
}