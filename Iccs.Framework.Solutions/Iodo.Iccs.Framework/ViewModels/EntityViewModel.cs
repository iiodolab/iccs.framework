using Caliburn.Micro;
using Iodo.Iccs.Framework.Models;
using System;

/******************************************************************************
 * Abstract Class EntityViewModel
 * 
 *                                                   author: Jinwoo Choi, PhD.
 *                                                 organization: Kookmin Univ.
 *                                                           date: 2020.10.28
 *                                                           
 *****************************************************************************/

namespace Iodo.Iccs.Framework.ViewModels
{
    public abstract class EntityViewModel : Screen, IEntityViewModel, IDisposable
    {
        #region - Ctors -
        public EntityViewModel()
        {
        }

        public EntityViewModel(IEntityModel entityModel)
        {
            EntityModel = entityModel;
        }
        #endregion

        public abstract void Dispose();

        #region - Properties -
        public abstract int Id { get; set; }
        public abstract string NameArea { get; set; }
        public abstract int TypeDevice { get; set; }
        public abstract string NameDevice { get; set; }
        public abstract int IdController { get; set; }
        public abstract int IdSensor { get; set; }
        public abstract int TypeShape { get; set; }
        public abstract double X1 { get; set; }
        public abstract double Y1 { get; set; }
        public abstract double X2 { get; set; }
        public abstract double Y2 { get; set; }
        public abstract double Width { get; set; }
        public abstract double Height { get; set; }
        public abstract double Angle { get; set; }
        public abstract bool Used { get; set; }
        public abstract bool Visibility { get; set; }
        #endregion

        #region - Attributes -
        protected IEntityModel EntityModel;
        #endregion
    }
}
