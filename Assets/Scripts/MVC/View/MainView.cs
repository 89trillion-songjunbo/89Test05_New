using System;
using System.Collections.Generic;
using Common;
using MVC.Model;
using UnityEngine;
using UnityEngine.UI;

namespace MVC.View
{
    public class MainView : MonoBehaviour
    {
        [SerializeField] private Text mUiScoreTe;
        [SerializeField] private Button mUiAddScoreBtn;
        [SerializeField] private Button muiRefreshSeasonBtn;
        [SerializeField] private Transform mUiItemParentTrans;
        [SerializeField] private Transform mUiCycleTrans;
        [SerializeField] private Text mUiCoinTe;
        [SerializeField] private Text mUiSegmentTe;
        [SerializeField] private Text mUiSeasonTe;

        private int currentScore = 3900;
        private int seasonId = 1;
        public List<ItemPanelView> itemPanels;
        public UIRewardModel RewardModel;

        private void Start()
        {
            mUiCoinTe.text = currentCoinNum.ToString();
            mUiScoreTe.text = string.Format(Const.ContentScoreInfo, currentScore);
            mUiAddScoreBtn.onClick.AddListener(AddScore);
            muiRefreshSeasonBtn.onClick.AddListener(OnClickSeason);

            InitItem(15);

            SetData();
        }

        private void InitItem(int count)
        {
            for (var i = 0; i < Mathf.Min(count, itemPanels.Count); i++)
            {
                itemPanels[i].gameObject.SetActive(false);
                itemPanels[i].transform.SetParent(mUiCycleTrans);
            }
        }

        private void SetSegmentInfo()
        {
            mUiSegmentTe.text = CommonTool.GetSegment(currentScore);
        }

        private Action<int> EventAddScore;
        public int addNum = 100;

        private void AddScore()
        {
            currentScore += addNum;
            mUiScoreTe.text = string.Format(Const.ContentScoreInfo, currentScore);
            EventAddScore?.Invoke(currentScore);

            SetSegmentInfo();
        }

        private void OnClickSeason()
        {
            currentScore = currentScore > Const.FirstScore
                ? Const.FirstScore + (currentScore - Const.FirstScore) / 2
                : currentScore;
            SetData(true);
            mUiScoreTe.text = string.Format(Const.ContentScoreInfo, currentScore);
            seasonId++;
            mUiSeasonTe.text = string.Format(Const.ContentSeasonInfo, seasonId);
        }

        private void SetData(bool isNewSeason = false)
        {
            var itemRewardModels = RewardModel.ItemRewardModels;
            for (var i = 0; i < itemRewardModels.Count; i++)
            {
                itemRewardModels[i].SetSeason(isNewSeason);
                var tmpItem = itemPanels[i];
                tmpItem.transform.SetParent(mUiItemParentTrans);
                tmpItem.EventAddCoin = AddCoin;
                EventAddScore += tmpItem.AddScore;
                tmpItem.Init(i, currentScore, itemRewardModels[i]);
            }

            SetSegmentInfo();
            mUiSeasonTe.text = string.Format(Const.ContentSeasonInfo, seasonId);
        }

        private int currentCoinNum;

        private void AddCoin(int index, int addCount)
        {
            currentCoinNum += addCount;
            mUiCoinTe.text = string.Format(Const.ContentCoinInfo, currentCoinNum.ToString());
        }
    }
}