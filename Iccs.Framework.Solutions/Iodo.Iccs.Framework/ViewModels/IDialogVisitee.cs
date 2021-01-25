/******************************************************************************
 * Interface IDialogVisitee
 * 
 *                                                   author: Jinwoo Choi, PhD.
 *                                                 organization: Kookmin Univ.
 *                                                           date: 2020.10.28
 *                                                           
 *****************************************************************************/

namespace Iodo.Iccs.Framework.ViewModels
{
    public interface IDialogVisitee
    {
        void Accept(IDialogVisitor visitor);
    }
}
