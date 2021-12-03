using MVC.Model;
using MVC.View;
using UnityEngine;
using UnityEngine.UI;

namespace MVC.Controller
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private MainView mUiView;
        [SerializeField] private Button mUiStartBtn;

        #region Model

        private UIRewardModel rewardModel;
        private UIRewardModel RewardModel => rewardModel ?? (rewardModel = new UIRewardModel());

        #endregion

        private void Awake()
        {
            RewardModel.Init();
            mUiView.RewardModel = RewardModel;

            mUiStartBtn.onClick.AddListener(() => { SetState(RewardModel != null); });
        }

        private void Start()
        {
            SetState(false);
        }

        private void SetState(bool isShow)
        {
            mUiView.gameObject.SetActive(isShow);
            mUiStartBtn.gameObject.SetActive(!isShow);
        }
    }
}