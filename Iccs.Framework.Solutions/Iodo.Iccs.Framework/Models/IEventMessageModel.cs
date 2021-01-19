/******************************************************************************
 * Interface IEventMessageModel
 * 
 *                                                   author: Jinwoo Choi, PhD.
 *                                                 organization: Kookmin Univ.
 *                                                           date: 2020.10.28
 *                                                           
 *****************************************************************************/

namespace Iodo.Iccs.Framework.Models
{
    public interface IEventMessageModel<T>
    {
        T Value { get; set; }
    }
}
