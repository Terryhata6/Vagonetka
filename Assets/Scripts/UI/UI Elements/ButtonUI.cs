using UnityEngine;
using UnityEngine.UI;


namespace Vagonetka
{
    public class ButtonUI : MonoBehaviour
    {
        private Button _button;

        public Button GetControl()
        {
            if (!_button)
            {
                _button = gameObject.GetComponent<Button>();
            }
            return _button;
        }
    }
}
