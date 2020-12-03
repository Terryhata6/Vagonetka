using UnityEngine;


namespace Vagonetka
{
    public class InGameUI : BaseMenu
    {
        [Header("Main panel of In Game UI")]
        [SerializeField] private GameObject _mainPanel;

        private UIController _uiController;

        private void Start()
        {
            _uiController = GetComponentInParent<UIController>();
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
