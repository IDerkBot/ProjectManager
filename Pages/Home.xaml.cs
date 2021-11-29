using ProjectManager.Classes;
using ProjectManager.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ProjectManager.Pages
{
	/// <summary>
	/// Interaction logic for Home.xaml
	/// </summary>
	public partial class Home : Page
	{
		public Home()
		{
			InitializeComponent();
			LoadProjects();
		}
		void LoadProjects()
		{
			List<Project> allProjects = ProjectManagerEntities.GetContext().Projects.ToList();
			List<ProjectUser> projectUser = ProjectManagerEntities.GetContext().ProjectUsers.Where(pu => pu.UserID == Data.User.ID).ToList();
			var useProjects = (from pu in projectUser
												 join project in ProjectManagerEntities.GetContext().Projects on pu.ProjectID equals project.ID
												 select project).ToList();
			LViewProjects.ItemsSource = useProjects;
		}
		void Button_Click(object sender, RoutedEventArgs e)
		{
			PageManager.Page.Navigate(new AddProject());
		}
		void LViewProjects_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			PageManager.Page.Navigate(new ProjectPage(LViewProjects.SelectedItem as Project));
		}
	}
}
