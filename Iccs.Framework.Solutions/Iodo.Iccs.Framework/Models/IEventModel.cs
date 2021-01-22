using System;

/******************************************************************************
 * Interface IEventModel
 * 
 *                                                   author: Jinwoo Choi, PhD.
 *                                                 organization: Kookmin Univ.
 *                                                           date: 2020.10.28
 *                                                           
 *****************************************************************************/

namespace Iodo.Iccs.Framework.Models
{
    public interface IEventModel
    {
        int Id { get; set; }
        DateTime DateTime { get; set; }
    }
}
