using DG.Tweening;
using Game.Widgets.View;
using UnityEngine;

namespace Game.Widgets.Model
{
    public class WidgetsPanelModel
    {
        private WidgetsPanelView _widgetsPanelView;

        private const float FADE_DURATION = 0.3f;

        private bool _isDropdownOpen;

        private bool _isDaytime = true;

        private bool _is3DCameraMode;

        private const string PERSPECTIVEMODE_TEXT = "3D";

        private const string ORTOGRAPHIC_TEXT = "2D";
        
        public WidgetsPanelModel(WidgetsPanelView widgetsPanelView)
        {
            _widgetsPanelView = widgetsPanelView;
        }
        
        public void OpenCloseDropdown()
        {
            if (_isDropdownOpen)
            {
                CloseDropdown();
            }
            else
            {
                OpenDropdown();
            }
        }

        public void OpenDropDownThroughFurniture()
        {
            OpenDropdown();
        }

        public void ChangeCameraMode()
        {
            if (_is3DCameraMode)
            {
                Set2DMode();
            }
            else
            {
                Set3DMode();
            }
        }

        public void ChangeDayTime()
        {
            if (_isDaytime)
            {
                SetNight();
            }
            else
            {
                SetDay();
            }
        }

        private void SetNight()
        {
            _isDaytime = false;
            foreach (var lightSource in _widgetsPanelView.SceneLightsObjects)
            {
                lightSource.SetActive(false);
            }
        }

        private void SetDay()
        {
            _isDaytime = true;
            foreach (var lightSource in _widgetsPanelView.SceneLightsObjects)
            {
                lightSource.SetActive(true);
            }
        }

        private void Set2DMode()
        {
            _is3DCameraMode = false;
            _widgetsPanelView.GameCamera.orthographic = true;
            _widgetsPanelView.SetTextValue(PERSPECTIVEMODE_TEXT);
        }

        private void Set3DMode()
        {
            _is3DCameraMode = true;
            _widgetsPanelView.GameCamera.orthographic = false;
            _widgetsPanelView.SetTextValue(ORTOGRAPHIC_TEXT);
        }
        
        private void OpenDropdown()
        {
            _isDropdownOpen = true;
            _widgetsPanelView.GetCanvasGroup().DOFade(1f, FADE_DURATION).OnComplete(() =>
            {
                _widgetsPanelView.GetCanvasGroup().interactable = true;
                _widgetsPanelView.GetCanvasGroup().blocksRaycasts = true;
            });
        }
    
        private void CloseDropdown()
        {
            _isDropdownOpen = false;
            _widgetsPanelView.GetCanvasGroup().DOFade(0f, FADE_DURATION).OnComplete(() =>
            {
                _widgetsPanelView.GetCanvasGroup().interactable = false;
                _widgetsPanelView.GetCanvasGroup().blocksRaycasts = false;
            });
        }
    }
}