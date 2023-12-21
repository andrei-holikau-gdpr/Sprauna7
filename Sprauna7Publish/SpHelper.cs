namespace Sprauna7Publish
{
    public static class SpHelper
    {
        public static T? GetAttribute<T>(object value, string memberName) where T : Attribute
        {
            var type = value.GetType();
            var memberInfo = type.GetMember(memberName);
            var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
            if (attributes != null)
            {
                var ats = attributes.FirstOrDefault();
                if (ats != null)
                {
                    T firstAttribute = (T)ats;
                    return firstAttribute;
                }
            } 
            
            return null;           
        }

        public static string GetMessageForLogger(
            string ProjectName,
            string ClassName, string MethodName, string ParametersInString,
            string Note,
            string ExcerptionMessage)
        {
            return "\t SpLog,"
                    + $"Date: {DateTime.Now.ToLongDateString()}, "
                    + $"Time: {DateTime.Now.ToLongTimeString()}, "
                    + $"{ProjectName}, "
                    + $"{ClassName}, "
                    + $"{MethodName}, "
                    + $"{Note}, "
                    + $"Exception: {ExcerptionMessage}";
        }
    }
}
