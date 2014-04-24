namespace CollectionChangedRepro
{
    using System.Linq;
    using System.Threading.Tasks;

    public class Vm
    {
        private History<string> _history;
        public Vm()
        {
            Task.Run(() => _history = new History<string>());
        }
        public History<string> History
        {
            get { return _history; }
        }

        public async void Add()
        {
            await Task.Run(() => History.Push(History.Count().ToString()));
        }
    }
}
