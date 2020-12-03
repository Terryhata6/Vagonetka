using UnityEngine;


namespace Vagonetka
{
    public class InputController : MonoBehaviour
    {
        [SerializeField] private KeyCode _keyForFallGold;
        private Camera _сameraForInput;
        private Touch touch;
        public bool InputStarted = false;

        private GoldController _goldController;

        private void Start()
        {
            _goldController = FindObjectOfType<GoldController>();
            _сameraForInput = FindObjectOfType<Camera>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(_keyForFallGold))
            {
                _goldController.GetCurrentGold().Fall();
            }
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    InputStarted = true; 
                    _goldController.GetCurrentGold().Fall();
                }
            }
            else if (InputStarted)
            {
                InputStarted = false;
            }
        }
    }
}
