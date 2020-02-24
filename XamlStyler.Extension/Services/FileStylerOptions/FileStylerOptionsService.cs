using System;
using System.IO;
using System.Linq.Expressions;
using Xavalon.XamlStyler.Extension.Common;
using Xavalon.XamlStyler.Extension.Services.Platform;
using Xavalon.XamlStyler.Options;

namespace Xavalon.XamlStyler.Extension.Services
{
    public class FileStylerOptionsService : IFileStylerOptionsService
    {
        private readonly IGlobalStylerOptionsService _globalStylerOptionsService;

        public FileStylerOptionsService(IGlobalStylerOptionsService globalStylerOptionsService)
        {
            _globalStylerOptionsService = globalStylerOptionsService;
        }

        public IStylerOptions GetStylerOptions(string xamlFilePath, string solutionFilePath)
        {
            if (xamlFilePath is null)
            {
                throw new ArgumentException(nameof(xamlFilePath));
            }

            if (Path.GetExtension(xamlFilePath) != Constants.XamlFileExtension)
            {
                throw new ArgumentException($"File other than {Constants.XamlFileExtension} extension", nameof(xamlFilePath));
            }

            if (solutionFilePath is null)
            {
                throw new ArgumentNullException(nameof(solutionFilePath));
            }

            var globalOptions = _globalStylerOptionsService.GetGlobalOptions();
            var solutionFolderPath = Path.GetDirectoryName(solutionFilePath);
            var isFileInSolutionFolder = xamlFilePath.StartsWith(solutionFolderPath, StringComparison.OrdinalIgnoreCase);
            if (!isFileInSolutionFolder)
            {
                return globalOptions;
            }

            

            var optionsRootFolder = solution.FileName.ParentDirectory;
            if (globalOptions.SearchToDriveRoot)
            {
                optionsRootFolder = optionsRootFolder.ParentDirectory;
            }

            var optionsRootFolderPath = optionsRootFolder.ToString();

            var firstOptionsFilePath = GetFirstOptionsFilePathOrDefault(xamlFilePath, optionsRootFolderPath);
            if (!string.IsNullOrEmpty(firstOptionsFilePath))
            {
                var firstOptions = ParseOptionsOrDefault(firstOptionsFilePath, globalOptions);
                return firstOptions;
            }

            var externalOptionsFilePath = globalOptions.ConfigPath;
            if (!string.IsNullOrEmpty(externalOptionsFilePath))
            {
                var externalOptions = ParseOptionsOrDefault(externalOptionsFilePath, globalOptions);
                return externalOptions;
            }

            return globalOptions;
        }

        private IStylerOptions ParseOptionsOrDefault(string optionsFilePath, IStylerOptions defaultOptions, JsonConverter deserializeConverter = null)
        {
            try
            {
                optionsFilePath = PathUtils.ToAbsolutePath(optionsFilePath);
                if (string.IsNullOrEmpty(optionsFilePath) || !File.Exists(optionsFilePath))
                {
                    return defaultOptions;
                }

                var optionsString = File.ReadAllText(optionsFilePath);
                var converters = deserializeConverter is null ? new JsonConverter[0] : new[] { deserializeConverter };
                var options = JsonConvert.DeserializeObject<StylerOptions>(optionsString, converters);
                if (options.IndentSize == -1)
                {
                    // TODO Check info about IndentSize, is it necessary
                    options.IndentSize = 4;
                }

                // TODO Remove it when we will handle Indent from Visual Studio preferences
                options.IndentWithTabs |= defaultOptions.IndentWithTabs;

                return options;
            }
            catch (Exception ex)
            {
                LoggingService.LogError("Failed to get Global XamlStyler options", ex);
                File.Delete(GlobalOptionsFilePath);
                return defaultOptions;
            }
        }

        private string GetFirstOptionsFilePathOrDefault(string documentFilePath, string rootPath)
        {
            var configPath = default(string);

            var currentFolder = Path.GetDirectoryName(documentFilePath);
            var currentConfigPath = Path.Combine(currentFolder, Constants.OptionsFileName);
            
            while (!)
            {

            }


            goto start;


            var currentDirectory = Path.GetDirectoryName(documentFilePath);
            var currentParentDirectory = Path.GetDirectoryName(currentDirectory);
            var currentConfigPath = Path.Combine(currentDirectory, OptionsFileName);
            while (!File.Exists(currentConfigPath) && currentParentDirectory.StartsWith(rootPath, StringComparison.InvariantCultureIgnoreCase))
            {
                currentDirectory = Path.GetDirectoryName(currentDirectory);
                currentParentDirectory = Path.GetDirectoryName(currentDirectory);
                currentConfigPath = Path.Combine(currentDirectory, OptionsFileName);
            }

            if (!File.Exists(currentConfigPath))
            {
                return null;
            }

            return currentConfigPath;
        }
    }
}
