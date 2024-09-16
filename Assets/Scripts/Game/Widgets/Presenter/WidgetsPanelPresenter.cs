using Game.Widgets.Model;

namespace Game.Widgets.Presenter
{
    public class WidgetsPanelPresenter
    {
        private WidgetsPanelModel _widgetsPanelModel;

        public WidgetsPanelPresenter(WidgetsPanelModel widgetsPanelModel)
        {
            _widgetsPanelModel = widgetsPanelModel;
        }
        
        public void OpenCloseDropDown()
        {
            _widgetsPanelModel.OpenCloseDropdown();
        }

        public void OpenDropDown()
        {
            _widgetsPanelModel.OpenDropDownThroughFurniture();
        }

        public void ChangeCameraMode()
        {
            _widgetsPanelModel.ChangeCameraMode();
        }

        public void ChangeDaytime()
        {
            _widgetsPanelModel.ChangeDayTime();
        }
    }
}