using EPiServer.Shell.ObjectEditing;
using System.ComponentModel.DataAnnotations;

namespace Head_Chef.Business.Extenders
{
    public class MetaDataExtender : IMetadataExtender
    {
        public void ModifyMetadata(ExtendedMetadata metadata, IEnumerable<Attribute> attributes)
        {
            foreach (var property in metadata.Properties)
            {
                if (property.PropertyName == "icategorizable_category")
                {
                    property.GroupName = "EPiServerCMS_SettingsPanel";
                    property.Order = 1;
                }

                foreach (var attribute in property.Attributes)
                {
                    if (attribute is ScaffoldColumnAttribute s)
                    {
                        if (s.Scaffold == false)
                        {
                            property.ShowForEdit = false;
                        }
                    }
                }
            }
        }
    }
}