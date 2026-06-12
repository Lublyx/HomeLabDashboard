using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DashboardWeb.Classes;

namespace DashboardWeb.Services
{
    public class LoadModelService
    {
        public const string MODELS_PATH = "/home/lucas/.llamacpp/scripts/";
        public IList<Model> LoadAvailableModels()
        {
            IList<Model> models = new List<Model>();
            IList<string> rawModels = Directory.GetFiles(MODELS_PATH);
            Regex regex = new Regex(@".{0,}/(.{0,}).sh");

            foreach (string model in rawModels)
            {
                Match match = regex.Match(model);

                models.Add(new Model(){ModelName = match.Groups[1].Value, ModelPath = model});              
            }
            return models;
        }
    }
}