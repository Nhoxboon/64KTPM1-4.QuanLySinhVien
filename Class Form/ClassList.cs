﻿using QuanLiSinhVien.Class;
using QuanLiSinhVien;
using QuanLiSinhVien.Model;
using QuanLiSinhVien.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiSinhVien
{
    public partial class ClassList : Form
    {
        private ClassServices classServices;
        private List<ClassModel> classList;
        ClassModel selectedClass;
        public ClassList()
        {
            InitializeComponent();
            classServices = new ClassServices();
            classList = new List<ClassModel> { };
            classList = classServices.ClassSearch();
            this.dataGridView1.DataSource = classList;
            dataGridView1.Columns[2].Visible = false;
          
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            var onclick = dataGridView1.SelectedCells[0].Value.ToString();
            if (e.ColumnIndex == 1 && onclick != "0")
            {
                selectedClass = classList.FirstOrDefault(x => x.ClassName == onclick);
                ShowButton();
            }
            else
            {
                HideButton();
            }
        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }

        private void Add_Class_Click(object sender, EventArgs e)
        {

            AddClass addClass = new AddClass();
            addClass.ShowDialog();
            classList = classServices.ClassSearch();
            dataGridView1.DataSource = classList;
            dataGridView1.Update();
            dataGridView1.Refresh();
            
        }

        private void ClassList_MouseClick(object sender, MouseEventArgs e)
        {
            HideButton();
        }

        private void ShowSubject_Click(object sender, EventArgs e)
        {
           
            SubjectInClass subjectInClass = new SubjectInClass(selectedClass);
            this.Hide();
            subjectInClass.ShowDialog();
            this.Show();
            classList = classServices.ClassSearch();
            dataGridView1.DataSource = classList;
            dataGridView1.Update();
            dataGridView1.Refresh();
            HideButton();
        }

        private void ShowStudent_Click(object sender, EventArgs e)
        {
            var onclick = dataGridView1.SelectedCells[0].Value.ToString();
            var selectedClass = classList.FirstOrDefault(x => x.ClassName == onclick);
            StudentOfClass studentOfClass = new StudentOfClass(selectedClass);
            this.Hide();
            studentOfClass.ShowDialog();
            this.Show();
            classList = classServices.ClassSearch();
            dataGridView1.DataSource= classList;
            dataGridView1.Update();
            dataGridView1.Refresh();
            HideButton();

        }

        private void ShowButton()
        {
            ShowStudent.Show();
            ShowSubject.Show();
            DeleteClassButton.Show();
            //EditClass.Show();
        }
        private void HideButton()
        {
            ShowStudent.Hide();
            ShowSubject.Hide();
            DeleteClassButton.Hide();
            //EditClass.Hide();
            dataGridView1.DataSource = classServices.ClassSearch();
            dataGridView1.Update();
            dataGridView1.Refresh();
        }

        private void DeleteClassButton_Click(object sender, EventArgs e)
        {
            classServices.DeleteClass(selectedClass.ClassName);
            
            HideButton();
        }

        private void EditClass_Click(object sender, EventArgs e)
        {
            EditClass editClass = new EditClass(selectedClass);
            editClass.ShowDialog();
            HideButton();

        }
    }
}
