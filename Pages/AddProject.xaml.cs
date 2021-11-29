using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProjectManager.Entities;
using ProjectManager.Classes;

namespace ProjectManager.Pages
{
	/// <summary>
	/// Interaction logic for AddProject.xaml
	/// </summary>
	public partial class AddProject : Page
	{
		public AddProject()
		{
			InitializeComponent();
		}
		byte[] image;
		void Border_Drop(object sender, DragEventArgs e)
		{
			string pathImage = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
			image = File.ReadAllBytes(pathImage);
			//Image.Source = new ImageSourceConverter().ConvertFromString(pathImage) as ImageSource;
		}
		void AddProjectFromDatabase_Click(object sender, RoutedEventArgs e)
		{
			Project project = new Project
			{
				Title = Title.Text,
				Image = image ?? null,
			};
			ProjectManagerEntities.GetContext().Projects.Add(project);
			ProjectManagerEntities.GetContext().SaveChanges();
			var loadProject = ProjectManagerEntities.GetContext().Projects.Where(p => p.Title == project.Title).LastOrDefault();
			ProjectUser pUser = new ProjectUser
			{
				Project = loadProject,
				User = Data.User,
				RoleID = 1
			};
			ProjectManagerEntities.GetContext().ProjectUsers.Add(pUser);
			ProjectManagerEntities.GetContext().SaveChanges();
		}
	}
}