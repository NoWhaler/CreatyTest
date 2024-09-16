using Game.DropdownFurniture.Model;

namespace Game.DropdownFurniture.Presenter
{
    public class DropdownFurniturePresenter
    {
        private DropdownFurnitureModel _dropdownFurnitureModel;

        public DropdownFurniturePresenter(DropdownFurnitureModel dropdownFurnitureModel)
        {
            _dropdownFurnitureModel = dropdownFurnitureModel;
        }

        public void OpenFurnitureSelector()
        {
            _dropdownFurnitureModel.RefreshFurnitureSelector();
        }
    }
}