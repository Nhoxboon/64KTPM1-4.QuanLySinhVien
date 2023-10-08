﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLiSinhVien.Class;
using QuanLiSinhVien.Model;
using QuanLiSinhVien.Services;

namespace QuanLiSinhVien
{
    public partial class SubjectList : Form
    {
        
        List<SubjectModel> subjectList;
        SubjectServices subjectServices;
        public SubjectList()
        {
            InitializeComponent();
            subjectServices = new SubjectServices();
            subjectList = new List<SubjectModel>();
            subjectList = subjectServices.SubjectSearch();
            this.SubjectGridView.DataSource = subjectList;


        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddSubjectButton_Click(object sender, EventArgs e)
        {
            AddSubject addSubject = new AddSubject();
            addSubject.ShowDialog();
            SubjectGridView.DataSource = subjectServices.SubjectSearch();
            SubjectGridView.Update();
            SubjectGridView.Refresh();

        }

        private void SubjectGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var onclick = SubjectGridView.SelectedCells[0].Value.ToString();
            if(e.ColumnIndex == 1 && onclick != "0" )
            {
                //EditSubjectButton.Show();
                DeleteSubjectButton.Show();
            }
        }

        private void SubjectList_MouseClick(object sender, MouseEventArgs e)
        {
            //EditSubjectButton.Hide();
            DeleteSubjectButton.Hide();
        }

        private void DeleteSubjectButton_Click(object sender, EventArgs e)
        {
            subjectServices.DeleteSubject(SubjectGridView.SelectedCells[0].Value.ToString());
            SubjectGridView.DataSource = subjectServices.SubjectSearch();
            SubjectGridView.Update();
            SubjectGridView.Refresh();
        }
    }
}
