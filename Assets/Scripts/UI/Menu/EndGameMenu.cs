using UnityEngine;


namespace Vagonetka
{
    public class EndGameMenu : BaseMenu
    {
        [Header("Main panel of end game menu")]
        [SerializeField] private GameObject _mainPanel;
        
        [Header("Objects for all cases")]
        [SerializeField] private TextUI _catchedGoldText;

        [Header("Objects in case of WIN")]
        [SerializeField] private ButtonUI _buttonNext;
        [SerializeField] private ImageUI _imageWin;

        [Header("Objects in case of LOSE")]
        [SerializeField] private ButtonUI _buttonRestart;
        [SerializeField] private ImageUI _imageLose;


        private UIController _uiController;

        private void Start()
        {
            _uiController = GetComponentInParent<UIController>();

            _buttonNext.GetControl.onClick.AddListener(() => _uiController.NextLevel());
            _buttonRestart.GetControl.onClick.AddListener(() => _uiController.ExitGame());
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
                    _buttonNext.gameObject.SetActive(true);
                    _imageWin.gameObject.SetActive(true);
                    
                    _buttonRestart.gameObject.SetActive(false);
                    _imageLose.gameObject.SetActive(false);
                    break;
                case EndGameUIState.Lose:
                    //TODO
                    _buttonRestart.gameObject.SetActive(true);
                    _imageLose.gameObject.SetActive(true);

                    _buttonNext.gameObject.SetActive(false);
                    _imageWin.gameObject.SetActive(false);
                    break;
            }
        }
    }
}