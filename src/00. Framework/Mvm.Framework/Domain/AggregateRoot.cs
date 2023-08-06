

namespace Mvm.Framework.Domain
{
    public class AggregateRoot: BaseEntity
    {
        public int version  { get; set; }
        private bool _versionInCremented;
        public IEnumerable<IDomainEvent> Events => _events;

        private  readonly List<IDomainEvent> _events = new ();

        protected void InCrementedVersion()
        {
            if (_versionInCremented)
            {
                return;
            }

            version++;
            _versionInCremented = true;
        }

        protected void AddEvent(IDomainEvent @eEvent)
        {
            if (!_events.Any() && !_versionInCremented)
            {
                version++;
                _versionInCremented = true;
            }
            _events.Add(@eEvent);
        }

        public void ClearEvents() => _events.Clear();

    }
}
