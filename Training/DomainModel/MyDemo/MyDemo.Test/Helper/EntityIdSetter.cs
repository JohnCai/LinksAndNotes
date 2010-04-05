using Mavis.Core;
using System.Reflection;

namespace MyDemo.Test.Helper
{
    public static class EntityIdSetter
    {
        public static void SetIdOf<TId>(IEntity<TId> entity, TId id)
        {
            PropertyInfo propertyInfo = entity.GetType().GetProperty("ID", BindingFlags.Public | BindingFlags.Instance);
            propertyInfo.SetValue(entity, id, null);
        }
    }
}