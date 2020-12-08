using UnityEngine;


namespace Vagonetka
{
    public class EndGameMenu : BaseMenu
    {
        [Header("Main panel of end game menu")]
        [SerializeField] private GameObject _mainPanel;

        //[Header("Objects in case of WIN")]

        //[Header("Objects in case of LOSE")]

        [Header("Objects for all cases")]
        [SerializeField] private TextUI _header;
        [SerializeField] private ButtonUI _buttonExit;

        private UIController _uiController;

        private void Start()
        {
            _uiController = GetComponentInParent<UIController>();

            _buttonExit.GetControl.onClick.AddListener(() => _uiController.ExitGame());
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

        public void ActivateMenu(EndGameUIState state)
        {
            switch(state)
            {
                case EndGameUIState.Win:
                    //TODO
                    _header.GetControl.text = "You WIN!";
                    break;
                case EndGameUIState.Lose:
                    //TODO
                    _header.GetControl.text = "Loser";
                    break;
            }
        }
    }
}
