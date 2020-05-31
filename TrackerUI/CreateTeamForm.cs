using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.Models;
using TrackerUI.Helper;

namespace TrackerUI
{
    public partial class CreateTeamForm : Form
    {
        ITeamRequester callingForm;
        private List<PersonModel> availableTeamMembers = GlobalConfig.Connection.GetPerson_All();
        private List<PersonModel> selectedteamMembers = new List<PersonModel>();

        public CreateTeamForm(ITeamRequester caller)
        {
            InitializeComponent();
            //CreateSampleData();
            callingForm = caller;
            WireUpLists();
        }

        private void CreateSampleData()
        {
            availableTeamMembers.Add(new PersonModel { FirstName = "tim", LastName = "corey" });
            availableTeamMembers.Add(new PersonModel { FirstName = "sue", LastName = "storm" });

            selectedteamMembers.Add(new PersonModel { FirstName = "jack", LastName = "harry" });
            selectedteamMembers.Add(new PersonModel { FirstName = "peter", LastName = "schnaider" });
        }

        private void WireUpLists()
        {
            selectTeamMemberDropDown.DataSource = null;
            selectTeamMemberDropDown.DataSource = availableTeamMembers;
            selectTeamMemberDropDown.DisplayMember = "FullName";

            teamMembersListBox.DataSource = null;
            teamMembersListBox.DataSource = selectedteamMembers;
            teamMembersListBox.DisplayMember = "FullName";
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void CreateTeamForm_Load(object sender, EventArgs e)
        {

        }

        private void teamValue_TextChanged(object sender, EventArgs e)
        {

        }

        private void selectTeamMemberDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void createMemberButton_Click(object sender, EventArgs e)
        {
            if (!Validation())
            {
                MessageBox.Show("invalid input");
                return;
            }
            PersonModel model = new PersonModel(
                firstNameValue.Text,
                lastNameValue.Text,
                emailValue.Text,
                cellPhoneValue.Text);

            model = GlobalConfig.Connection.CreatePerson(model);
            selectedteamMembers.Add(model);
            WireUpLists();
            ClearInput();
        }
        private void ClearInput()
        {
            firstNameValue.Text = "";
            lastNameValue.Text = "";
            emailValue.Text = "0";
            cellPhoneValue.Text = "0";

        }
        private bool Validation()
        {
            bool output = true;

            if (firstNameValue.Text.Length == 0)
            {
                output = false;
            }
            if (lastNameValue.Text.Length == 0)
            {
                output = false;
            }
            if (emailValue.Text.Length == 0)
            {
                output = false;
            }
            if (cellPhoneValue.Text.Length == 0)
            {
                output = false;
            }
            return output;
        }

        private void addMemberButton_Click(object sender, EventArgs e)
        {
            PersonModel p = (PersonModel)selectTeamMemberDropDown.SelectedItem;
            if (p != null)
            {
                availableTeamMembers.Remove(p);
                selectedteamMembers.Add(p);
                WireUpLists();
            }

        }

        private void removeSelectedMemberButon_Click(object sender, EventArgs e)
        {

            PersonModel p = (PersonModel)teamMembersListBox.SelectedItem;
            if (p != null)
            {
                selectedteamMembers.Remove(p);
                availableTeamMembers.Add(p);
                WireUpLists();
            }

        }

        private void createTeamButton_Click(object sender, EventArgs e)
        {
            TeamModel t = new TeamModel();
            t.TeamName = teamValue.Text;
            t.TeamMembers = selectedteamMembers;
            GlobalConfig.Connection.CreateTeam(t);
            callingForm.TeamComplete(t);
            this.Close();
        }

        private void teamMembersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
