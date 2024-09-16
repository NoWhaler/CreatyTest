using Game.Dropdown.Model;

namespace Game.Dropdown.Presenter
{
    public class DropdownPresenter
    {
        private DropdownModel _dropdownModel;

        public DropdownPresenter(DropdownModel dropdownModel)
        {
            _dropdownModel = dropdownModel;
        }

        public void SetCurrentScrollBarValue()
        {
            _dropdownModel.SetValue();
        }

        public void MoveScrollbarUp()
        {
            _dropdownModel.MoveUp();
        }

        public void MoveScrollbarDown()
        {
            _dropdownModel.MoveDown();
        }
    }
}