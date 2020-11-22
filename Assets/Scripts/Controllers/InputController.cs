using UnityEngine;


namespace Vagonetka
{
    public class InputController : MonoBehaviour
    {
        [SerializeField] private KeyCode _keyForFallGold;

        private GoldController _goldController;

        private void Start()
        {
            _goldController = FindObjectOfType<GoldController>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(_keyForFallGold))
            {
                _goldController.GetCurrentGold().Fall();
            }
        }
    }
}
