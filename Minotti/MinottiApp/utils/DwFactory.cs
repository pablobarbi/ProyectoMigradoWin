using System.Reflection;

namespace Minotti.utils
{
    public static class DwFactory
    {
        public static IDataWindow Create(string dwName)
        {
            if (string.IsNullOrWhiteSpace(dwName))
                throw new ArgumentNullException(nameof(dwName));

            Type? foundType = null;

            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                Type[] types;

                try
                {
                    types = assembly.GetTypes();
                }
                catch (ReflectionTypeLoadException ex)
                {
                    // Algunos assemblies no cargan todos los tipos (WinForms, etc.)
                    types = ex.Types.Where(t => t != null).ToArray()!;
                }

                foundType = types.FirstOrDefault(t =>
                    t != null &&
                    t.Name.Equals(dwName, StringComparison.OrdinalIgnoreCase) &&
                    typeof(IDataWindow).IsAssignableFrom(t) &&
                    !t.IsAbstract
                );

                if (foundType != null)
                    break;
            }

            if (foundType == null)
                throw new Exception($"DataWindow no encontrado: {dwName}");

            return (IDataWindow)Activator.CreateInstance(foundType)!;
        }
    }



}
