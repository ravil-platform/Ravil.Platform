namespace Common.Utilities.Extensions
{
    public static class Enums
    {
        public static string? GetEnumDisplayName(this Enum myEnum)
        {
            var enumDisplayName = myEnum.GetType().GetMember(myEnum.ToString()).FirstOrDefault();
            return enumDisplayName != null ? enumDisplayName.GetCustomAttribute<DisplayAttribute>()?.GetName() : string.Empty;
        }

        public static string GetEnumDescription(this Enum value)
        {
            var enumMember = value.GetType().GetMember(value.ToString()).FirstOrDefault();
            var descriptionAttribute =
                enumMember == null
                    ? default(DescriptionAttribute)
                    : enumMember.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute;
            return
                descriptionAttribute == null
                    ? value.ToString()
                    : descriptionAttribute.Description;
        }
    }
}