using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeDomain.Tests.Fakes
{
    public class SpyEventHandler<TEvent> : IEventHandler<TEvent>
    {
        public List<TEvent> HandledEvents { get; private set; } = new List<TEvent>();

        public TEvent HandledEvent
        {
            get
            {
                Assert.That(this.HandledEvents, Has.Exactly(1).Items);
                return this.HandledEvents[0];
            }
        }

        public void Handle(TEvent e)
        {
            Assert.NotNull(e);

            this.HandledEvents.Add(e);
        }
    }
}
