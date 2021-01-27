/******************************************************************************
 * Interface IBootstrapper
 * 
 *                                                   author: Jinwoo Choi, PhD.
 *                                                 organization: Kookmin Univ.
 *                                                           date: 2020.10.28
 *                                                           
 *****************************************************************************/

namespace Iodo.Iccs.Framework
{
    public interface IBootstrapper
    {
        void StartUp();
        void Stop();
    }
}
