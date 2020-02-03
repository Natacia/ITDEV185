using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MyResume.Models
{
    public enum SkillEnum
    {
        Beginner,
        Intermediate,
        Advanced
    }
    public class MyProfile
    {
        [Required, Key, StringLength(50)]
        [Description("Company Applying To")]
        public string Id { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        [Required, StringLength(50)]
        public string StreetAddress { get; set; }
        [Required, StringLength(50)]
        public string City { get; set; }
        [Required, StringLength(50)]
        public string State { get; set; }
        [Required, StringLength(50)]
        public string ZipCode { get; set; }
        [Required, StringLength(50)]
        public string Phone { get; set; }
        [Required, StringLength(50)]
        public string Email { get; set; }
        [Required, StringLength(50)]
        public string SchoolName { get; set; }
        [Required, StringLength(50)]
        public string Degree { get; set; }
        [Required, StringLength(50)]
        public string StartDate { get; set; }
        [Required, StringLength(50)]
        public string EndDate { get; set; }
        [Required, StringLength(50)]
        public string JobTitle { get; set; }
        [Required, StringLength(50)]
        public string EnumSkillId
        {
            get
            {
                return this.EnumSkill.ToString();
            }
            set
            {
                EnumSkill = (SkillEnum)Enum.Parse(typeof(SkillEnum), value, true);
            }
        }
        public SkillEnum EnumSkill { get; set; }

        [Required, StringLength(50)]
        public string CompanyName { get; set; }

        public static MyProfile GetProfileSingle(SqlConnection dbcon, string id)
        {
            MyProfile obj = new MyProfile();
            string strsql = "select * from Profile where Id = '" + id + "'";
            SqlCommand cmd = new SqlCommand(strsql, dbcon);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                if (rdr["Id"] != DBNull.Value) obj.Id = rdr["Id"].ToString();
                if (rdr["Name"] != DBNull.Value) obj.Name= rdr["Name"].ToString();
                if (rdr["StreetAddress"] != DBNull.Value) obj.StreetAddress = rdr["StreetAddress"].ToString();
                if (rdr["City"] != DBNull.Value) obj.City = rdr["City"].ToString();
                if (rdr["State"] != DBNull.Value) obj.State = rdr["State"].ToString();
                if (rdr["ZipCode"] != DBNull.Value) obj.ZipCode = rdr["ZipCode"].ToString();
                if (rdr["Phone"] != DBNull.Value) obj.Phone = rdr["Phone"].ToString();
                if (rdr["Email"] != DBNull.Value) obj.Email = rdr["Email"].ToString();
                if (rdr["SchoolName"] != DBNull.Value) obj.SchoolName = rdr["SchoolName"].ToString();
                if (rdr["Degree"] != DBNull.Value) obj.Degree = rdr["Degree"].ToString();
                if(rdr["StartDate"] != DBNull.Value) obj.StartDate = rdr["StartDate"].ToString();
                if (rdr["EndDate"] != DBNull.Value) obj.EndDate = rdr["EndDate"].ToString();
                if (rdr["JobTitle"] != DBNull.Value) obj.JobTitle = rdr["JobTitle"].ToString();
                if (rdr["EnumSkill"] != DBNull.Value) obj.EnumSkillId = rdr["EnumSkill"].ToString();
                if (rdr["CompanyName"] != DBNull.Value) obj.CompanyName = rdr["CompanyName"].ToString();
            }
            rdr.Close();
            return obj;
        }
        public static List<MyProfile> GetProfileList(SqlConnection dbcon, string SqlClause)
        {
            List<MyProfile> itemList = new List<MyProfile>();
            string strsql = "select * from Profile " + SqlClause;
            SqlCommand cmd = new SqlCommand(strsql, dbcon);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                MyProfile obj = new MyProfile();
                if (rdr["Id"] != DBNull.Value) obj.Id = rdr["Id"].ToString();
                itemList.Add(obj);
            }
            rdr.Close();
            return itemList;
        }
        public static int CUDProfile(SqlConnection dbcon, string CUDAction, MyProfile obj)
        {
            SqlCommand cmd = new SqlCommand();
            if (CUDAction == "create")
            {

                cmd.CommandText = "insert into Profile " +
                 "Values (@Id,@Name,@StreetAddress,@City,@State,@ZipCode,@Phone,@Email,@SchoolName,@Degree,@StartDate,@EndDate," +
                 "@JobTitle,@EnumSkill,@CompanyName)";
                //copy parameter assignment statements here
                cmd.Parameters.AddWithValue("@Id", SqlDbType.VarChar).Value = obj.Id;
                cmd.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = obj.Name;
                cmd.Parameters.AddWithValue("@StreetAddress", SqlDbType.VarChar).Value = obj.StreetAddress;
                cmd.Parameters.AddWithValue("@City", SqlDbType.VarChar).Value = obj.City;
                cmd.Parameters.AddWithValue("@State", SqlDbType.VarChar).Value = obj.State;
                cmd.Parameters.AddWithValue("@ZipCode", SqlDbType.VarChar).Value = obj.ZipCode;
                cmd.Parameters.AddWithValue("@Phone", SqlDbType.Decimal).Value = obj.Phone;
                cmd.Parameters.AddWithValue("@Email", SqlDbType.Int).Value = obj.Email;
                cmd.Parameters.AddWithValue("@SchoolName", SqlDbType.Int).Value = obj.SchoolName;
                cmd.Parameters.AddWithValue("@Degree", SqlDbType.Int).Value = obj.Degree;
                cmd.Parameters.AddWithValue("@StartDate", SqlDbType.Int).Value = obj.StartDate;
                cmd.Parameters.AddWithValue("@EndDate", SqlDbType.Int).Value = obj.EndDate;
                cmd.Parameters.AddWithValue("@JobTitle", SqlDbType.Int).Value = obj.JobTitle;
                cmd.Parameters.AddWithValue("@EnumSkill", SqlDbType.Int).Value = obj.EnumSkillId;
                cmd.Parameters.AddWithValue("@CompanyName", SqlDbType.Int).Value = obj.CompanyName;
               

            }
            else if (CUDAction == "update")
            {
                cmd.CommandText = "update Profile  set Name = @Name, StreetAddress = @StreetAddress," +
                    "City = @City, State = @State, ZipCode = @ZipCode, Phone = @Phone, Email = @Email," +
                    "SchoolName = @SchoolName, Degree = @Degree, StartDate = @StartDate," +
                    "EndDate = @EndDate, JobTitle = @JobTitle, EnumSkill = @EnumSkill, CompanyName = @CompanyName " +
                    "Where Id = @Id";
                //copy parameter assignment statements here
                cmd.Parameters.AddWithValue("@Id", SqlDbType.VarChar).Value = obj.Id;
                cmd.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = obj.Name;
                cmd.Parameters.AddWithValue("@StreetAddress", SqlDbType.VarChar).Value = obj.StreetAddress;
                cmd.Parameters.AddWithValue("@City", SqlDbType.VarChar).Value = obj.City;
                cmd.Parameters.AddWithValue("@State", SqlDbType.VarChar).Value = obj.State;
                cmd.Parameters.AddWithValue("@ZipCode", SqlDbType.VarChar).Value = obj.ZipCode;
                cmd.Parameters.AddWithValue("@Phone", SqlDbType.Decimal).Value = obj.Phone;
                cmd.Parameters.AddWithValue("@Email", SqlDbType.Int).Value = obj.Email;
                cmd.Parameters.AddWithValue("@SchoolName", SqlDbType.Int).Value = obj.SchoolName;
                cmd.Parameters.AddWithValue("@Degree", SqlDbType.Int).Value = obj.Degree;
                cmd.Parameters.AddWithValue("@StartDate", SqlDbType.Int).Value = obj.StartDate;
                cmd.Parameters.AddWithValue("@EndDate", SqlDbType.Int).Value = obj.EndDate;
                cmd.Parameters.AddWithValue("@JobTitle", SqlDbType.Int).Value = obj.JobTitle;
                cmd.Parameters.AddWithValue("@EnumSkill", SqlDbType.Int).Value = obj.EnumSkillId;
                cmd.Parameters.AddWithValue("@CompanyName", SqlDbType.Int).Value = obj.CompanyName;
            }
            else if (CUDAction == "delete")
            {
                cmd.CommandText = "delete Profile where Id = @Id";
                cmd.Parameters.AddWithValue("@Id", SqlDbType.VarChar).Value = obj.Id;
            }
            cmd.Connection = dbcon;
            int intResult = cmd.ExecuteNonQuery();
            cmd.Dispose();
            return intResult;
        }
    }
}