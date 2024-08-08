using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeDomain
{
    public interface IEventHandler<TEvent>
    {
        void Handle(TEvent e);
    }
}
