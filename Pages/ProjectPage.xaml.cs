using System;
using System.Collections.Generic;
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

namespace ProjectManager.Pages
{
	/// <summary>
	/// Interaction logic for ProjectPage.xaml
	/// </summary>
	public partial class ProjectPage : Page
	{
		public ProjectPage()
		{
			InitializeComponent();
		}
		public ProjectPage(Project selectedProject)
		{
			InitializeComponent();
			DataContext = selectedProject;
		}
	}
}
