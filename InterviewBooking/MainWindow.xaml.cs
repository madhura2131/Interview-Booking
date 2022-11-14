using Library;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Mail;
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
using System.Xml.Serialization;
using static Library.Candidate;

namespace InterviewBooking
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private JobGenerator jobs;
        private List<AvailableDate> availableDate = new List<AvailableDate>();
        public List<AvailableDate> AvailableDate { get => availableDate; set => availableDate = value; }
        public Candidate Candidate { get; set; } = new Candidate();

        private InterviewList interviews = new InterviewList();
        public InterviewList Interviews { get => interviews; set => interviews = value; }

        private ObservableCollection<MyInterviews> myInterview;
        public ObservableCollection<MyInterviews> MyInterview { get => myInterview; set => myInterview = value; }

        public MainWindow()
        {
            InitializeComponent();
            SetInterviewDateAndTime();
            jobs = new JobGenerator();
            DataContext = this;
            radioArchitect.IsChecked = true;
            radioMale.IsChecked = true;
            MyInterview = new ObservableCollection<MyInterviews>();
            cmbOrgranization.ItemsSource = Enum.GetValues(typeof(Organizations)).Cast<Organizations>();
        }

        void Test()
        {
            txtCandidateAge.Text = 25.ToString();
            txtCandidateEmail.Text = "test@gmail.com";
            txtCandidateMobile.Text = "2223334444";
            txtCandidateName.Text = "Test";
        }

        void SetInterviewDateAndTime()
        {
            AvailableDate = new List<AvailableDate>();
            for (int i = 0; i < 7; i++)
            {
                AvailableDate.Add(new AvailableDate(DateTime.Now.AddDays(i).ToString("MM-dd-yyyy")));
            }
        }

        bool IsEmailValid(string email)
        {
            if (email.Trim().EndsWith("."))
            {
                return false;
            }
            try
            {
                var tmp = new MailAddress(email);
                return tmp.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void btnBookInterview_Click(object sender, RoutedEventArgs e)
        {
            if (txtCandidateName.Text == "" || txtCandidateAge.Text == "" || txtCandidateEmail.Text == "" || txtCandidateMobile.Text == "" || cmbInterviewTime.Items.Count==0)
            {
                return;
            }

            int age;
            long mobile;
            string email,name,time,date;
            GenderType gender;

            if (!int.TryParse(txtCandidateAge.Text, out age) && age<=0)
            {
                return;
            }
            if (!IsEmailValid(txtCandidateEmail.Text))
            {
                return;
            }
            if ((!long.TryParse(txtCandidateMobile.Text.ToString(), out mobile)) || txtCandidateMobile.Text.ToString().Length != 10 || txtCandidateMobile.Text.StartsWith("0"))
            {
                return;
            }


            name = txtCandidateName.Text;
            email = txtCandidateEmail.Text;
            AvailableDate tmp = (AvailableDate)cmbInterviewDate.SelectedItem;
            date = tmp.Date;
            time = cmbInterviewTime.SelectedValue.ToString();


            if (radioMale.IsChecked==true)
            {
                gender = GenderType.Male;
            }
            else if (radiofemale.IsChecked == true)
            {
                gender = GenderType.Female;
            }
            else
            {
                gender = GenderType.Other;
            }

            Job currentJob = null; ;
            Candidate currentCandidate=null;
            Interviews currentInterview=null;

            var result = jobs.JobList.Find(x => x.JobTitle == lblSelectedPosition.Content.ToString());
            if (radioArchitect.IsChecked.Value)
            {
                currentJob = new Architecture(result.JobTitle,result.Location,result.Organization);
            }
            else if (radioBusiness.IsChecked.Value)
            {
                currentJob = new Business(result.JobTitle, result.Location, result.Organization);
            }
            else if (radioIT.IsChecked.Value)
            {
                currentJob = new InformationTechnology(result.JobTitle, result.Location, result.Organization);
            }

            currentCandidate = new Candidate(name,email,mobile,age,gender);
            currentInterview = new Interviews(time,date,currentCandidate,currentJob);

            Interviews.Add(currentInterview);

            MyInterviews mi = new MyInterviews();
            mi.CandidateAge = currentCandidate.Age;
            mi.CandidateEmail = currentCandidate.EmailAddress;
            mi.CandidateGender = currentCandidate.Gender;
            mi.CandidateMobile = currentCandidate.MobileNumber;
            mi.CandidateName = currentCandidate.Name;
            mi.InterviewDate = date;
            mi.InterviewTime = time;
            mi.JobField = currentJob.GetType().Name;
            mi.JobLocation = currentJob.Location;
            mi.JobPosition = currentJob.GetSelectedJob();
            mi.JobOrganizarion = currentJob.Organization;
            mi.JobSalary = currentJob.Salary;

            MyInterview.Add(mi);

            MessageBox.Show("Interview Booked Successfully!");

            AvailableDate[cmbInterviewDate.SelectedIndex].Time.RemoveAt(cmbInterviewTime.SelectedIndex);
            cmbInterviewTime.Items.Refresh();
            cmbInterviewTime.SelectedIndex = 0;


            ResetFields();

        }

        private void OnFieldChange(object sender, RoutedEventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if(rb.IsChecked==true)
            {
                switch(rb.Name)
                {
                    case "radioArchitect":
                        panelArchitect.Visibility = Visibility.Visible;
                        panelBusiness.Visibility = Visibility.Collapsed;
                        panelInformationTechnology.Visibility = Visibility.Collapsed;
                        Architect.IsChecked = false;
                        Architect.IsChecked = true;
                        break;
                    case "radioBusiness":
                        panelArchitect.Visibility = Visibility.Collapsed;
                        panelBusiness.Visibility = Visibility.Visible;
                        panelInformationTechnology.Visibility = Visibility.Collapsed;
                        HumanResourcesManager.IsChecked = false;
                        HumanResourcesManager.IsChecked = true;
                        break;
                    case "radioIT":
                        panelArchitect.Visibility = Visibility.Collapsed;
                        panelBusiness.Visibility = Visibility.Collapsed;
                        panelInformationTechnology.Visibility = Visibility.Visible;
                        ComputerProgrammer.IsChecked = false;
                        ComputerProgrammer.IsChecked = true;
                        break;
                }
            }
        }

        private void OnPositionSelected(object sender, RoutedEventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            Job result = jobs.JobList.Find(x => x.JobTitle == rb.Name);

            lblSelectedPosition.Content = result.JobTitle;
            lblLocation.Content = result.Location;
            lblOrgranization.Content = result.Organization;
            lblSalary.Content = string.Format("${0}",result.Salary);
        }

        private void btnSaveInterview_Click(object sender, RoutedEventArgs e)
        {
            if(MyInterview.Count==0)
            {
                MessageBox.Show("No Interview have been booked!");
            }
            else
            {
                XmlSerializer xmlSerializer = null;
                TextWriter textWriter = null;
                try
                {
                    xmlSerializer = new XmlSerializer(typeof(InterviewList));
                    textWriter = new StreamWriter("Interviews.xml");
                    xmlSerializer.Serialize(textWriter, Interviews);
                    textWriter.Close();
                    MessageBox.Show("Interview saved successfully!");

                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                    if (textWriter != null)
                    {
                        textWriter.Close();
                    }
                }
                finally
                {
                    if (textWriter != null)
                    {
                        textWriter.Close();
                    }
                }
            }
        }

        void ResetFields()
        {
            txtCandidateAge.Text = "";
            txtCandidateEmail.Text = "";
            txtCandidateMobile.Text = "";
            txtCandidateName.Text = "";
        }

        private void btnLoadInterview_Click(object sender, RoutedEventArgs e)
        {
            XmlSerializer xmlSerializer = null;
            TextReader textReader = null;

            try
            {
                xmlSerializer = new XmlSerializer(typeof(InterviewList));
                textReader = new StreamReader("Interviews.xml");

                Interviews= (InterviewList)xmlSerializer.Deserialize(textReader);
                textReader.Close();

                if(Interviews.Count==0)
                {
                    MessageBox.Show("No Interview to load!");
                }
                else
                {
                    MyInterview.Clear();

                    foreach (var item in Interviews)
                    {
                        MyInterviews mi = new MyInterviews();
                        mi.CandidateAge = item.Candidate.Age;
                        mi.CandidateEmail = item.Candidate.EmailAddress;
                        mi.CandidateGender = item.Candidate.Gender;
                        mi.CandidateMobile = item.Candidate.MobileNumber;
                        mi.CandidateName = item.Candidate.Name;
                        mi.InterviewDate = item.InterviewDate;
                        mi.InterviewTime = item.InterviewTime;
                        mi.JobField = item.Job.GetType().Name;
                        mi.JobLocation = item.Job.Location;
                        mi.JobPosition = item.Job.GetSelectedJob();
                        mi.JobOrganizarion = item.Job.Organization;
                        mi.JobSalary = item.Job.Salary;

                        MyInterview.Add(mi);
                    }

                    candidateDataGrid.ItemsSource = MyInterview;
                    MessageBox.Show("Loaded successfully!");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
                if (textReader != null)
                {
                    textReader.Close();
                }
            }
            finally
            {
                if (textReader != null)
                {
                    textReader.Close();
                }
            }
        }

        private void btnSearchInterview_Click(object sender, RoutedEventArgs e)
        {
            string selectedOrganization = cmbOrgranization.SelectedValue.ToString();
            var query = from record in MyInterview
                        where record.JobOrganizarion.ToString() == selectedOrganization
                        select record;

            candidateDataGrid.ItemsSource = query;

        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            candidateDataGrid.ItemsSource = MyInterview;
        }
    }
}
