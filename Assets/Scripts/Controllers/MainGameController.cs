using UnityEngine;


namespace Vagonetka
{
    public class MainGameController : MonoBehaviour
    {
        [SerializeField] private float _gravity;

        private PlayerModel _player;
        private LevelController _levelController;

        private void Start()
        {
            Physics.gravity = new Vector3(0, _gravity, 0);

            _player = FindObjectOfType<PlayerModel>();
            _levelController = FindObjectOfType<LevelController>();
        }

        public void StartGame()
        {
            //TODO load data
            _levelController.StartLevel();
        }
        public void NextLevel()
        {
            //TODO save data (may be level number)
            _levelController.NextLevel();
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
