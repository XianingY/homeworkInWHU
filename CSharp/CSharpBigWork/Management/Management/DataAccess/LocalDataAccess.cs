using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Management.Common;
using Management.DataAccess.DataEntity;
using Management.Model;

namespace Management.DataAccess
{
    public class LocalDataAccess
    {
        private static LocalDataAccess instance;
        private LocalDataAccess() { }
        public static LocalDataAccess GetInstance()
        {
            return instance ?? (instance = new LocalDataAccess());
        }

        SqlConnection conn;
        SqlCommand comm;
        SqlDataAdapter adapter;

        private void Dispose()
        {
            if (adapter != null)
            {
                adapter.Dispose();
                adapter = null;
            }
            if (comm != null)
            {
                comm.Dispose();
                comm = null;
            }
            if (conn != null)
            {
                conn.Close();
                conn.Dispose();
                conn = null;
            }
        }

        private bool DBConnection()
        {
            string connStr = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            if (conn == null)
                conn = new SqlConnection(connStr);
            try
            {
                conn.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public UserEntity CheckUserInfo(string userName, string pwd)
        {
            try
            {
                if (DBConnection())
                {
                    string userSql = "select * from users where user_name=@user_name and password=@pwd and is_validation=1";
                    adapter = new SqlDataAdapter(userSql, conn);
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@user_name", SqlDbType.VarChar) { Value = userName });
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@pwd", SqlDbType.VarChar) { Value = MD5Provider.GetMD5String(pwd + "@" + userName) });

                    DataTable table = new DataTable();
                    int count = adapter.Fill(table);

                    if (count <= 0)
                        throw new Exception("用户名或密码不正确！");

                    DataRow dr = table.Rows[0];
                    if (dr.Field<Int32>("is_can_login") == 0)
                        throw new Exception("当前用户没有权限使用此平台！");

                    UserEntity userInfo = new UserEntity();
                    userInfo.UserName = dr.Field<string>("user_name");
                    userInfo.RealName = dr.Field<string>("real_name");
                    userInfo.Password = dr.Field<string>("password");
                    userInfo.Avatar = dr.Field<string>("avatar");
                    userInfo.Gender = dr.Field<Int32>("gender");
                    return userInfo;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.Dispose();
            }

            return null;
        }


        public List<CourseSeriesModel> GetCoursePlayRecord()
        {
            try
            {
                List<CourseSeriesModel> cModelList = new List<CourseSeriesModel>();
                if (DBConnection())
                {
                    string userSql = @"select a.video_name,a.video_id,b.play_count,b.is_growing,b.growing_rate ,
c.platform_name
from video a
left join play_record b
on a.video_id = b.video_id
left join platforms c
on b.platform_id = c.platform_id
order by a.video_id,c.platform_id";
                    adapter = new SqlDataAdapter(userSql, conn);

                    DataTable table = new DataTable();
                    int count = adapter.Fill(table);

                    string courseId = "";
                    CourseSeriesModel cModel = null;

                    foreach (DataRow dr in table.AsEnumerable())
                    {
                        string tempId = dr.Field<string>("video_id");
                        if (courseId != tempId)
                        {
                            courseId = tempId;
                            cModel = new CourseSeriesModel();
                            cModelList.Add(cModel);

                            cModel.CourseName = dr.Field<string>("video_name");
                            cModel.SeriesColection = new LiveCharts.SeriesCollection();
                            cModel.SeriesList = new System.Collections.ObjectModel.ObservableCollection<SeriesModel>();
                        }
                        if (cModel != null)
                        {
                            cModel.SeriesColection.Add(new PieSeries
                            {
                                Title = dr.Field<string>("platform_name"),
                                Values = new ChartValues<ObservableValue> { new ObservableValue((double)dr.Field<decimal>("play_count")) },
                                DataLabels = false
                            });

                            cModel.SeriesList.Add(new SeriesModel
                            {
                                SeriesName = dr.Field<string>("platform_name"),
                                CurrentValue = dr.Field<decimal>("play_count"),
                                IsGrowing = dr.Field<Int32>("is_growing") == 1,
                                ChangeRate = (int)dr.Field<decimal>("growing_rate")
                            });
                        }
                    }
                }
                return cModelList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.Dispose();
            }
        }

        public List<string> GetTeachers()
        {
            try
            {
                List<string> result = new List<string>();
                if (this.DBConnection())
                {

                    string sql = "select uploader_name from uploader where is_uploader=1";
                    adapter = new SqlDataAdapter(sql, conn);

                    DataTable table = new DataTable();
                    int count = adapter.Fill(table);
                    if (count > 0)
                    {
                        result = table.AsEnumerable().Select(c => c.Field<string>("uploader_name")).ToList();
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.Dispose();
            }
        }

        public List<CourseModel> GetCourses()
        {
            try
            {
                List<CourseModel> result = new List<CourseModel>();
                if (this.DBConnection())
                {
                    string sql = @"select a.video_id,a.video_name,a.video_url,a.video_cover,c.uploader_name from video a
left join video_uploader_relation b
on a.video_id=b.video_id
left join uploader c
on b.uploader_id=c.uploader_id
order by a.video_id";
                    adapter = new SqlDataAdapter(sql, conn);

                    DataTable table = new DataTable();
                    int count = adapter.Fill(table);
                    if (count > 0)
                    {
                        string courseId = "";
                        CourseModel model = null;

                        foreach (DataRow dr in table.AsEnumerable())
                        {
                            string tempId = dr.Field<string>("video_id");
                            if (courseId != tempId)
                            {
                                courseId = tempId;

                                model = new CourseModel();
                                model.CourseName = dr.Field<string>("video_name");
                                model.Cover = dr.Field<string>("video_cover");
                                model.Url = dr.Field<string>("video_url");

                                model.Teachers = new List<string>();

                                result.Add(model);
                            }
                            if (model != null)
                            {
                                model.Teachers.Add(dr.Field<string>("uploader_name"));
                            }
                        }
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.Dispose();
            }
        }
    }
}
