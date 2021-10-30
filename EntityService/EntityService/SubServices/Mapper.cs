using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace EntityService.SubServices
{
    public static class Mapper
    {
        public static T ToAssign<S, T>(S source, T target)
        {
            foreach (PropertyInfo prop in typeof(T).GetProperties())
            {
                ToAssign<S, T>(prop, source, target);
            }

            return target;
        }

        public static object Update(object source, object target, Type type)
        {
            var result = SoftCopy(target, type);

            if (source.GetType() != type)
            {
                throw new Exception("Input type of parameter 'source' is invalid.");
            }

            if (target.GetType() != type)
            {
                throw new Exception("Input type of parameter 'target' is invalid.");
            }

            foreach (PropertyInfo prop in type.GetProperties())
            {
                if ("Id".Equals(prop.Name.ToLower()))
                {
                    continue;
                }

                if ("OwnerId".Equals(prop.Name.ToLower()))
                {
                    continue;
                }

                if ("PublisherId".Equals(prop.Name.ToLower()))
                {
                    continue;
                }

                if ("Insertion".Equals(prop.Name.ToLower()))
                {
                    continue;
                }

                if ("Change".Equals(prop.Name.ToLower()))
                {
                    continue;
                }

                if (prop.GetMethod == null || prop.GetMethod == default)
                {
                    continue;
                }

                if (prop.SetMethod == null || prop.SetMethod == default)
                {
                    continue;
                }

                prop.SetValue(result, prop.GetValue(source));
            }

            return result;
        }

        public static T Update<T>(T source, T target)
        {
            var type = typeof(T);
            var properties = type.GetRuntimeProperties();
            if (properties == null || properties == default || properties.Count() < 1)
            {
                throw new Exception("The update operation was unable to identify the properties of the type entered.");
            }

            foreach (PropertyInfo prop in typeof(T).GetRuntimeProperties())
            {
                if ("Id".Equals(prop.Name.ToLower()))
                {
                    continue;
                }

                if ("OwnerId".Equals(prop.Name.ToLower()))
                {
                    continue;
                }

                if ("PublisherId".Equals(prop.Name.ToLower()))
                {
                    continue;
                }

                if ("Insertion".Equals(prop.Name.ToLower()))
                {
                    continue;
                }

                if ("Change".Equals(prop.Name.ToLower()))
                {
                    continue;
                }

                Update<T>(prop, source, target);
            }

            return target;
        }

        private static void ToAssign<S, T>(PropertyInfo prop, S source, T target)
        {
            if (prop.GetMethod == null || prop.GetMethod == default)
            {
                return;
            }

            if (prop.SetMethod == null || prop.SetMethod == default)
            {
                return;
            }

            typeof(S).GetProperties().Any(p =>
            {
                if (p.Name != prop.Name || p.PropertyType != prop.PropertyType)
                {
                    return false;
                }

                prop.SetValue(target, p.GetValue(source));

                return true;
            });
        }

        private static void Update<T>(PropertyInfo prop, T source, T target)
        {
            if (prop.GetMethod == null || prop.GetMethod == default)
            {
                return;
            }

            if (prop.SetMethod == null || prop.SetMethod == default)
            {
                return;
            }

            prop.SetValue(target, prop.GetValue(source));
        }

        public static T SoftCopy<T>(T source)
        {
            var result = Activator.CreateInstance<T>();

            foreach (PropertyInfo prop in typeof(T).GetProperties())
            {
                if (prop.GetMethod == null || prop.GetMethod == default)
                {
                    continue;
                }

                if (prop.SetMethod == null || prop.SetMethod == default)
                {
                    continue;
                }

                prop.SetValue(result, prop.GetValue(source));
            }

            return result;
        }

        public static object SoftCopy(object source, Type type)
        {
            var result = Activator.CreateInstance(type);

            foreach (PropertyInfo prop in type.GetProperties())
            {
                if (prop.GetMethod == null || prop.GetMethod == default)
                {
                    continue;
                }

                if (prop.SetMethod == null || prop.SetMethod == default)
                {
                    continue;
                }

                prop.SetValue(result, prop.GetValue(source));
            }

            return result;
        }
    }
}
