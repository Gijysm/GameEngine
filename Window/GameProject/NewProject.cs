using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowEngine.Untilites;
using System.Collections.ObjectModel;

namespace WindowEngine.GameProject
{
    [DataContract]
    public class ProjectTemplate
    {
        [DataMember]
        public string ProjectType { get; set; }
        [DataMember]
        public string ProjectFile { get; set; }
        [DataMember]
        public List<string> Folder { get; set; }
    }
    public class NewProject : ViewModelBase
    {
        private readonly string _projectPath = $@"..\\GameEngine\\Window\\GamesFolder";
   
        private string _name = "New project";

        public string Name
        {
            get => _name;
            set
            {
                if (_name != value) _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        private string _path = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\PrimalProject\";

        public string Path
        {
            get => _path;
            set
            {
                if (_path != value) _path = value;
                OnPropertyChanged(nameof(Path));
            }
        }
        private ObservableCollection<ProjectTemplate> _projectTemplates = new ObservableCollection<ProjectTemplate>();
        public ReadOnlyObservableCollection<ProjectTemplate> projectTemplates
        {
            get;
        }
        public NewProject()
        {
            projectTemplates = new ReadOnlyObservableCollection<ProjectTemplate>(_projectTemplates);
            //try
            //{
            if (_projectPath != null)
                {
                    var templatesFiles = Directory.GetFiles(_projectPath, "template.xml", SearchOption.AllDirectories);
                    Debug.Assert(templatesFiles.Any());
                    foreach (var file in templatesFiles)
                    {
                        var template = Serializer.FromFile<ProjectTemplate>(file);
                    _projectTemplates.Add(template);
                }
                }
            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine(ex.Message);
            //}
        }

    }
}
