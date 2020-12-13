using UnityEngine;
using TapticPlugin;

namespace Vagonetka
{
    public class InputController : MonoBehaviour
    {
        public bool InputStarted = false;

        [SerializeField] private KeyCode _keyForFallGold;

        private Camera _сameraForInput;
        private Touch touch;
        private bool _isActive;

        private GoldController _goldController;
        private SampleUI _sampleUI;

        private void Start()
        {
            _goldController = FindObjectOfType<GoldController>();
            _сameraForInput = FindObjectOfType<Camera>();
            _sampleUI = FindObjectOfType<SampleUI>();
        }

        private void Update()
        {
            if (!_isActive) return;

#if UNITY_EDITOR
            if (Input.GetKeyDown(_keyForFallGold))
            {
                FallGold();
                _sampleUI.OnImpactClick(2);
            }
#endif

            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    InputStarted = true;
                    _sampleUI.OnImpactClick(2);
                    FallGold();
                }
            }
            else if (InputStarted)
            {
                InputStarted = false;
            }
        }

        private void FallGold()
        {
            if (_goldController.GetCurrentGold())
            {
                _goldController.GetCurrentGold().Fall();
                _goldController.SwitchNextGold();
            }
        }

        public void ActivateController(bool state)
        {
            _isActive = state;
        }
    }
}