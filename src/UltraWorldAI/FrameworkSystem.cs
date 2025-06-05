namespace UltraWorldAI
{
    public interface IFrameworkModule
    {
        string Name { get; }
        void Initialize(Person person);
        void Update(Person person);
    }

    public class FrameworkSystem
    {
        private readonly List<IFrameworkModule> _modules = new();
        private readonly Person _person;

        public FrameworkSystem(Person person)
        {
            _person = person;
        }

        public void AddModule(IFrameworkModule module)
        {
            module.Initialize(_person);
            _modules.Add(module);
        }

        public T? GetModule<T>() where T : class, IFrameworkModule
        {
            return _modules.OfType<T>().FirstOrDefault();
        }

        public void Update()
        {
            foreach (var module in _modules)
            {
                module.Update(_person);
            }
        }
    }
}
