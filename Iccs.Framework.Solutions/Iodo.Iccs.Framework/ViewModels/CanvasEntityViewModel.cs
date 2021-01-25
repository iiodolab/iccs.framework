using Caliburn.Micro;

/******************************************************************************
 * Abstract Class CanvasEntityViewModel
 * 
 *                                                   author: Jinwoo Choi, PhD.
 *                                                 organization: Kookmin Univ.
 *                                                           date: 2020.10.28
 *                                                           
 *****************************************************************************/

namespace Iodo.Iccs.Framework.ViewModels
{
    using ECProvider = 
        Iodo.Iccs.Framework.DataProviders
        .EntityCollectionProvider<Iodo.Iccs.Framework.ViewModels.IEntityViewModel>;

    public abstract class CanvasEntityViewModel
        : Screen
    {
        #region - Ctors
        public CanvasEntityViewModel(ECProvider entityProvider, bool visibility = true)
        {
            EntityProvider = entityProvider;
            Visibility = visibility;
        }
        #endregion

        #region - Properties -
        public ECProvider EntityProvider  { get; }

        public bool Visibility {
            get => visibility;
            set
            {
                visibility = value;
                NotifyOfPropertyChange(() => Visibility);
            }
        }
        #endregion

        #region - Attributes -
        private bool visibility;
        #endregion
    }
}
