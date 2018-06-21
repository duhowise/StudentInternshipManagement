﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Models
{
    public class Group
    {
        [DisplayName("Mã nhóm")]
        public int GroupId { get; set; }

        [DisplayName("Tên nhóm")]
        public string GroupName { get; set; }

        [DisplayName("Công ty thực tập")]
        public int CompanyId { get; set; }

        [DisplayName("Định hướng")]
        public int TrainingMajorId { get; set; }

        [ScriptIgnore(ApplyToOverrides = true)]
        public virtual CompanyTrainingMajor Major { get; set; }

        [DisplayName("Lớp học")]
        public int ClassId { get; set; }

        [ScriptIgnore(ApplyToOverrides = true)]
        public virtual LearningClass Class { get; set; }

        [ScriptIgnore(ApplyToOverrides = true)]
        public virtual ICollection<Student> Members { get; set; }

        [DisplayName("Nhóm trưởng")]
        [ForeignKey("Leader")]
        public string LeaderId { get; set; }

        [ScriptIgnore(ApplyToOverrides = true)]
        public virtual Student Leader { get; set; }

        [DisplayName("Giảng viên hướng dẫn")]
        public string TeacherId { get; set; }

        [ScriptIgnore(ApplyToOverrides = true)]
        public virtual Teacher Teacher { get; set; }
    }
}
