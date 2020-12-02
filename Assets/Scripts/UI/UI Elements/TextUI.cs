using UnityEngine;
using UnityEngine.UI;


namespace Vagonetka
{
    public class TextUI : MonoBehaviour
    {
        private Text _text;

        public Text GetControl()
        {
            if (!_text)
            {
                _text = gameObject.GetComponent<Text>();
            }
            return _text;
        }
    }
}
