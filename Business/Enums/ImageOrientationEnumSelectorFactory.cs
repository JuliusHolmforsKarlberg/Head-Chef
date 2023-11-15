using EPiServer.Cms.Shell.UI.ObjectEditing.EditorDescriptors.SelectionFactories;
using EPiServer.Framework.Localization;

namespace Head_Chef.Business.Enums
{
    public class ImageOrientationEnumSelectorFactory : EnumSelectionFactory
    {

        public ImageOrientationEnumSelectorFactory(LocalizationService localizationService) : base(localizationService)
        {
            
        }
        protected override Type EnumType => typeof(Orientation);

        protected override string GetStringForEnumValue(int value)
        {
            var v = Enum.GetName(typeof(Orientation), value);
            var s = LocalizationService.GetString("/property/enum/orientation/" + v);

            return s;
        }
    }
}
