﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiSinhVien.Model
{
    public class StudentListClassModel
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("Tên sinh viên")]
        public string Name { get; set; }
    }
}
