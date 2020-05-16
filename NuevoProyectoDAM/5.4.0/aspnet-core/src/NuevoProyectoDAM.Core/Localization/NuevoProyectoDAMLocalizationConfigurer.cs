using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace NuevoProyectoDAM.Localization
{
    public static class NuevoProyectoDAMLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(NuevoProyectoDAMConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(NuevoProyectoDAMLocalizationConfigurer).GetAssembly(),
                        "NuevoProyectoDAM.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
