/******************************************************************************
 * Interface IDialogVisitor
 * 
 *                                                   author: Jinwoo Choi, PhD.
 *                                                 organization: Kookmin Univ.
 *                                                           date: 2020.10.28
 *                                                           
 *****************************************************************************/

namespace Iodo.Iccs.Framework.ViewModels
{
    public interface IDialogVisitor
    {   
        public abstract void Visit(IDialogVisitee visitee);
    }
}
