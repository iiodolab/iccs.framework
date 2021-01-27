/******************************************************************************
 * Interface IMessageService
 * 
 *                                                   author: Jinwoo Choi, PhD.
 *                                                 organization: Kookmin Univ.
 *                                                           date: 2020.10.28
 *                                                           
 *****************************************************************************/

using StackExchange.Redis;
using System;

namespace Iodo.Iccs.Framework.Services
{
    public interface IMessageService
        : IService
    {   
        event EventHandler<ChannelMessage> Channel1EventHandler;
        event EventHandler<ChannelMessage> Channel2EventHandler;
        event EventHandler<ChannelMessage> Channel3EventHandler;
        event EventHandler<ChannelMessage> Channel4EventHandler;
        event EventHandler<ChannelMessage> Channel5EventHandler;
        event EventHandler<ChannelMessage> Channel6EventHandler;
    }
}
