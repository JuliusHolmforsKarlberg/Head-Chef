using Business.Enums;
using EPiServer.Cms.Shell.UI.ObjectEditing.EditorDescriptors.SelectionFactories;
using EPiServer.Framework.Localization;

namespace Head_Chef.Business.Enums
{
    public class RecipeCategoryEnumSelectorFactory : EnumSelectionFactory
    {
        public RecipeCategoryEnumSelectorFactory(LocalizationService localizationService) : base(localizationService)
        {
        }

        protected override Type EnumType => typeof(RecipeCategory);

        protected override string GetStringForEnumValue(int value)
        {
            var v = Enum.GetName(typeof(RecipeCategory), value);
            var s = LocalizationService.GetString("/property/enum/recipeCategory/" + v);

            return s;
        }
    }
}
