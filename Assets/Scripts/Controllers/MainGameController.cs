using UnityEngine;


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
        }

        public void StartGame()
        {
            
        }

        public void StartLevel()
        {
            //TODO:
            //UI set to in game
            //Player start moving
        }

        public void IsLevelPassed(bool isPassed)
        {
            if (isPassed)
            {
                //TODO
            }
            else
            {
                //TODO
            }
        }
    }
}
