using UnityEngine;
using UnityEngine.UI;


namespace Vagonetka
{
    public class TextUI : MonoBehaviour
    {
        private Text _text;

        public Text GetControl
        {
            get
            {
                if (!_text)
                {
                    _text = transform.GetComponent<Text>();
                }
                return _text;
            }
        }
    }
}
