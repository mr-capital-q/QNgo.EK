using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QNgo.EK.Abstractions
{
    public interface IGameActionResolver
    {
        Task<IGameAction> GetGameActionAsync(IPlayerAction playerAction);
    }
}
