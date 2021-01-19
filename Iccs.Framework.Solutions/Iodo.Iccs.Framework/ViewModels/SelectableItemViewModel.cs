using Caliburn.Micro;
using Iodo.Iccs.Framework.Models;

/******************************************************************************
 * Class SelectableItemViewModel
 * 
 *                                                   author: Jinwoo Choi, PhD.
 *                                                 organization: Kookmin Univ.
 *                                                           date: 2020.10.28
 *                                                           
 *****************************************************************************/
namespace Iodo.Iccs.Framework.ViewModels
{
    public class SelectableItemViewModel : PropertyChangedBase
    {
        #region - Ctors -
        public SelectableItemViewModel(
            SelectableItemModel selectableItemModel)
        {
            SelectableItemModel = selectableItemModel;
        }
        #endregion

        #region - Properties -
        public string Name
        {
            get => SelectableItemModel.Name;
            set
            {
                SelectableItemModel.Name = value;
                NotifyOfPropertyChange(() => Name);
            }
        }

        public bool IsSelected
        {
            get => SelectableItemModel.IsSelected;
            set
            {
                SelectableItemModel.IsSelected = value;
                NotifyOfPropertyChange(() => IsSelected);
            }
        }
        private SelectableItemModel SelectableItemModel { get; }
        #endregion

        #region - Attriibtes -
        #endregion
    }
}
