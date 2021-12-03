using System;
using Common;
using MVC.Model;
using UnityEngine;
using UnityEngine.UI;

namespace MVC.View
{
    public class ItemPanelView : MonoBehaviour
    {
        [SerializeField] private Text mUiScore;
        [SerializeField] private Text mUiCoinTe;
        [SerializeField] private Button mUiReceiveBtn;

        private bool isReceive;
        private int curIndex;
        private ItemRewardModel ItemData;

        public void Init(int index, int currentNum, ItemRewardModel itemData)
        {
            gameObject.SetActive(true);
            curIndex = index;
            ItemData = itemData;
            mUiReceiveBtn.onClick.RemoveAllListeners();
            mUiReceiveBtn.onClick.AddListener(OnClickReceive);

            if (mUiScore != null)
            {
                mUiScore.text = ItemData.Score.ToString();
            }

            if (mUiReceiveBtn != null)
            {
                mUiReceiveBtn.gameObject.SetActive(ItemData.Score % 1000 != 0 && currentNum >= ItemData.Score);
            }

            if (mUiCoinTe != null)
            {
                mUiCoinTe.text = ItemData.Score % 1000 != 0
                    ? string.Format(Const.CoinTe, ItemData.RewardNum)
                    : $"{CommonTool.GetSegment(ItemData.Score)}段位";
            }

            if (mUiScore != null)
            {
                mUiScore.gameObject.SetActive(ItemData.Score % 1000 != 0);
            }

            if (ItemData.Score > 4000)
            {
                isReceive = false;
            }
        }

        public Action<int, int> EventAddCoin;

        private void OnClickReceive()
        {
            isReceive = true;
            EventAddCoin?.Invoke(curIndex, ItemData.RewardNum);

            mUiReceiveBtn.gameObject.SetActive(false);
        }

        public void AddScore(int scoreNum)
        {
            if (isReceive)
            {
                return;
            }

            if (ItemData.Score % 1000 == 0)
            {
                mUiReceiveBtn.gameObject.SetActive(false);
            }
            else
            {
                if (scoreNum >= ItemData.Score)
                {
                    mUiReceiveBtn.gameObject.SetActive(true);
                }
            }
        }
    }
}