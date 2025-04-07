using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace TaskManagementAPI.Localization;

public static class TaskManagementAPILocalizationConfigurer
{
    public static void Configure(ILocalizationConfiguration localizationConfiguration)
    {
        localizationConfiguration.Sources.Add(
            new DictionaryBasedLocalizationSource(TaskManagementAPIConsts.LocalizationSourceName,
                new XmlEmbeddedFileLocalizationDictionaryProvider(
                    typeof(TaskManagementAPILocalizationConfigurer).GetAssembly(),
                    "TaskManagementAPI.Localization.SourceFiles"
                )
            )
        );
    }
}
