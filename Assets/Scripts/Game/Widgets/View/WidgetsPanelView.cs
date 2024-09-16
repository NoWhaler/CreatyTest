using Game.Widgets.Presenter;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Widgets.View
{
    public class WidgetsPanelView: MonoBehaviour
    {
        private WidgetsPanelPresenter _widgetsPanelPresenter;

        [SerializeField] private Button _dropDownButton;
        
        [SerializeField] private Button _changeCameraModeButton;

        [SerializeField] private Button _changeDayTime;

        [SerializeField] private TMP_Text _buttonText;

        [SerializeField] private CanvasGroup _canvasGroup;

        [field: SerializeField] public GameObject[] SceneLightsObjects { get; private set; }
        
        public Camera GameCamera { get; private set; }
        
        private void Start()
        {
            GameCamera = Camera.main;
            _dropDownButton.onClick.AddListener(() => _widgetsPanelPresenter.OpenCloseDropDown());
            _changeCameraModeButton.onClick.AddListener(() => _widgetsPanelPresenter.ChangeCameraMode());
            _changeDayTime.onClick.AddListener(() => _widgetsPanelPresenter.ChangeDaytime());
        }

        public void Init(WidgetsPanelPresenter widgetsPanelPresenter)
        {
            _widgetsPanelPresenter = widgetsPanelPresenter;
        }

        public CanvasGroup GetCanvasGroup()
        {
            return _canvasGroup;
        }

        public void SetTextValue(string textValue)
        {
            _buttonText.text = textValue;
        }

        public void SetFurnitureSelector()
        {
            _widgetsPanelPresenter.OpenDropDown();
        }
    }
}