﻿/******************************************************************************
 * Interface ISymbolModel
 * 
 *                                                   author: Jinwoo Choi, PhD.
 *                                                 organization: Kookmin Univ.
 *                                                           date: 2020.10.28
 *                                                           
 *****************************************************************************/

namespace Iodo.Iccs.Framework.Models
{
    public interface ISymbolModel
    {
        #region - Properties -
        int Id { get; set; }
        string NameArea { get; set; }
        int TypeDevice { get; set; }
        string NameDevice { get; set; }
        int IdController { get; set; }
        int IdSensor { get; set; }
        int TypeShape { get; set; }
        double X1 { get; set; }
        double Y1 { get; set; }
        double X2 { get; set; }
        double Y2 { get; set; }
        double Width { get; set; }
        double Height { get; set; }
        double Angle { get; set; }
        public bool Used { get; set; }
        public bool Visibility { get; set; }
        #endregion
    }
}
