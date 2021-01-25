/******************************************************************************
 * Class SelectableItemModel
 * 
 *                                                   author: Jinwoo Choi, PhD.
 *                                                 organization: Kookmin Univ.
 *                                                           date: 2020.10.28
 *                                                           
 *****************************************************************************/

namespace Iodo.Iccs.Framework.Models
{
    public sealed class SelectableItemModel
    {
        #region - Properties -
        public string Name
        {
            get => name;
            set => name = value;
        }

        public bool IsSelected
        {
            get => isSelected;
            set => isSelected = value;
        }
        #endregion

        #region - Attributes -
        private string name;
        private bool isSelected;
        #endregion
    }
}
