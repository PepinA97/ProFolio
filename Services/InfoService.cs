using Microsoft.AspNetCore.Hosting;
using PortfolioWebsite.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioWebsite.Services
{
    public class InfoService
    {
        // Constructor and file path declaration
        #region
        public InfoService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        #endregion

        // Gets the exact path to the info folder 
        private string InfoFolderPath => Path.Combine(WebHostEnvironment.WebRootPath, "info");

        public ProjectModel[] GetProjectModels()
        {
            // Get information on projects directory
            DirectoryInfo directoryInfo = new DirectoryInfo($"{InfoFolderPath}/projects");

            // Get the individual information for each project file
            FileInfo[] projectFileInfos = directoryInfo.GetFiles("*.txt");

            List<ProjectModel> projectModels = new List<ProjectModel>();

            foreach(FileInfo fileInfo in projectFileInfos)
            {
                // Add the name to list of project names, remove the .txt at the end
                projectModels.Add(FindProjectModel(fileInfo.Name));
            }

            return projectModels.ToArray();
        }

        public ProjectModel FindProjectModel(string projectFileName)
        {
            string relativePath = $"/projects/{projectFileName}";

            if (File.Exists($"{InfoFolderPath}{relativePath}"))
            {
                ProjectModel projectModel = new ProjectModel
                {
                    FileName = projectFileName,
                    Name = GetValue(relativePath, "Name"),
                    Description = GetValue(relativePath, "Description"),
                    SourceLink = GetValue(relativePath, "SourceLink"),
                    ReleaseLink = GetValue(relativePath, "ReleaseLink"),
                    Asset = GetValue(relativePath, "Asset")
                };

                string madeWithString = GetValue(relativePath, "MadeWith");
                if(madeWithString != null)
                {
                    projectModel.MadeWith = madeWithString.Split(',');
                }

                return projectModel;
            }

            return null;
        }

        public bool DoProjectsExist()
        {
            // Get information on projects directory
            DirectoryInfo directoryInfo = new DirectoryInfo($"{InfoFolderPath}/projects");

            if (directoryInfo.Exists)
            {
                // Get the individual information for each project file
                FileInfo[] projectFileInfos = directoryInfo.GetFiles("*.txt");

                if(projectFileInfos.Length > 0)
                {
                    return true;
                }
            }

            return false;
        }

        public bool DoesFileExist(string fileName)
        {
            if (System.IO.File.Exists($"{WebHostEnvironment.WebRootPath}/{fileName}"))
            {
                return true;
            }

            return false;
        }

        // Get the value of "{key}={value}\n" from the file 
        public string GetValue(string fileName, string key)
        {
            string value = null;

            using (StreamReader streamReader = File.OpenText($"{InfoFolderPath}/{fileName}"))
            {
                key += '=';

                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();

                    if (String.Compare(key, 0, line, 0, key.Length) == 0)
                    {
                        // Found key
                        value = line.Substring(key.Length);
                        break;
                    }
                }

                streamReader.Close();
            }

            return value;
        }
    }
}
