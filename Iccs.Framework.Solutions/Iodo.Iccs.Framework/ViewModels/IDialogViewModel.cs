﻿/******************************************************************************
 * Interface IDialogViewModel
 * 
 *                                                   author: Jinwoo Choi, PhD.
 *                                                 organization: Kookmin Univ.
 *                                                           date: 2020.10.28
 *                                                           
 *****************************************************************************/
namespace Iodo.Iccs.Framework.ViewModels
{
    public interface IDialogViewModel : IDialogVisitee
    {
        bool IsVisible { get; set; }
    }
}
