using UnityEngine;


namespace Vagonetka
{
    public class InGameUI : BaseMenu
    {
        [Header("Main panel of In Game UI")]
        [SerializeField] private GameObject _mainPanel;

        [Header("Button pause")]
        [SerializeField] private ButtonUI _buttonPause;

        [Header("Slider")]
        [SerializeField] private SliderUI _slider;

        private UIController _uiController;
        private GoldCollector _goldCollector;

        private void Start()
        {
            _uiController = GetComponentInParent<UIController>();

            _buttonPause.GetControl.onClick.AddListener(() => _uiController.PauseGame());

            _goldCollector = FindObjectOfType<GoldCollector>();
        }

        private void Update()
        {
            _slider.GetControl.maxValue = _goldCollector.GetMaxAmountOfGold();
            _slider.GetControl.value = _goldCollector.GetGoldCollected();
        }

        public override void Hide()
        {
            if (!IsShow) return;
            _mainPanel.gameObject.SetActive(false);
            IsShow = false;
        }

        public override void Show()
        {
            if (IsShow) return;
            _mainPanel.gameObject.SetActive(true);
            IsShow = true;
        }
    }
}
