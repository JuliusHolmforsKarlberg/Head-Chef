using EPiServer.Cms.Shell.UI.ObjectEditing.EditorDescriptors.SelectionFactories;
using EPiServer.Framework.Localization;

namespace Head_Chef.Business.Enums
{
    public class RegionEnumSelectorFactory : EnumSelectionFactory
{
    public RegionEnumSelectorFactory(LocalizationService localizationService) : base(localizationService)
    {
    }

    protected override Type EnumType => typeof(Region);

    protected override string GetStringForEnumValue(int value)
    {
        var v = Enum.GetName(typeof(Region), value);
        var s = LocalizationService.GetString("/property/enum/region/" + v);

        return s;
    }
}
}
