using EPiServer.Shell.ObjectEditing;
using Head_Chef.Business.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

namespace Head_Chef.Business.Enums
{
    public class SelectOneEnumAttribute1 : SelectOneAttribute, IDisplayMetadataProvider
    {
        public Type EnumType { get; set; }

        public SelectOneEnumAttribute1(Type enumType)
        {
            if (!enumType.IsEnum)
            {
                throw new ArgumentException("Type must be an enum");
            }

            EnumType = enumType;
        }

        public new void CreateDisplayMetadata(DisplayMetadataProviderContext context)
        {
            SelectionFactoryType = typeof(RecipeCategoryEnumSelectorFactory);

            base.CreateDisplayMetadata(context);
        }
    }
}