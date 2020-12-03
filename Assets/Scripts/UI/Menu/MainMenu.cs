using UnityEngine;

namespace Vagonetka
{
    public class MainMenu : BaseMenu
    {
        [Header("Panel of mail menu")]
        [SerializeField] private GameObject _mainPanel;

        [Header("Start game button")]
        [SerializeField] private ButtonUI _startGameButton;

        private UIController _uiController;

        private void Start()
        {
            _uiController = GetComponentInParent<UIController>();

            _startGameButton.GetControl.onClick.AddListener(delegate
            {
                _uiController.StartGame();
            });
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
