using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeDomain.Tests.Fakes
{
    public class StubEventHandler<TEvent> : IEventHandler<TEvent>
    {
        public void Handle(TEvent e)
        {
        }
    }
}
