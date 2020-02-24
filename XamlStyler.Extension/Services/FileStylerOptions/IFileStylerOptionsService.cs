using System;
using Xavalon.XamlStyler.Options;

namespace Xavalon.XamlStyler.Extension.Services
{
    public interface IFileStylerOptionsService
    {
        IStylerOptions GetStylerOptions(string filePath, string solutionFilePath);
    }
}