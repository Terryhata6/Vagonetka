using UnityEngine;
using NaughtyAttributes;


namespace Vagonetka
{
    public class MainGameController : MonoBehaviour
    {
        [SerializeField] private float _gravity;

        private PlayerModel _player;

        private void Start()
        {
            Physics.gravity = new Vector3(0, _gravity, 0);
            _player = FindObjectOfType<PlayerModel>();

            StartGame();
        }

        public void StartGame()
        {
            _player.IsMoving = true;
        }

        public void StartLevel()
        {
            //TODO:
            //UI set to in game
            //Player start moving
        }
    }
}
