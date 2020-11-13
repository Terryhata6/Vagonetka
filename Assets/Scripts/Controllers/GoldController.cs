using System.Collections.Generic;
using UnityEngine;


namespace Vagonetka
{
    public class GoldController : MonoBehaviour
    {
        private List<GoldModel> _goldList;
        private GoldModel _gold;
        private PlayerModel _player;
        private int _index = 0;

        private float _playerX;
        private float _playerZ;
        private float _goldX;
        private float _goldZ;

        private void Start()
        {
            _player = FindObjectOfType<PlayerModel>();
            _gold = _goldList[_index];
        }

        private void Update()
        {
            if (ComparePosition())
            {
                SwitchNextGold();
            }
        }

        private bool ComparePosition()
        {
            _playerX = _player.gameObject.transform.position.x;
            _playerZ = _player.gameObject.transform.position.z;
            _goldX = _gold.gameObject.transform.position.x;
            _goldZ = _gold.gameObject.transform.position.z;

            if (_goldX >= _playerX - 1f && _goldX <= _playerX + 1f && _goldZ >= _playerZ + 1f && _goldX <= _playerZ - 1f)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void UpdateGoldList(List<GoldPresetModel> presetList)
        {
            _goldList.Clear();
            for (int i = 0; i < presetList.Count; i++)
            {
                _goldList.AddRange(presetList[i].GetGold());
            }
        }

        public void SwitchNextGold()
        {
            _index++;
            if (_index < _goldList.Count)
            {
                _gold = _goldList[_index];
            }
        }
    }
}
