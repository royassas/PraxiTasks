using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraxiTasks
{
    public class SqliteDataAccess
    {
        public static List<KategorieModel> LoadCategories()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<KategorieModel>("select * from categories", new DynamicParameters());
                if (output!=null) {
                    return output.ToList();
                } else
                {
                    return null;
                }
            }
        }
        public static void SaveCategorie(KategorieModel cats)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into categories (description, color, icon) values (@Description, @Color, @Icon)", cats);
            }
        }
        public static List<BenutzerModel> LoadPeople()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<BenutzerModel>("select * from users", new DynamicParameters());
                return output.ToList();
            }
        }
        public static void SavePerson(BenutzerModel person)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into users (abb, firstname, lastname, jobdescription, isAdmin) values (@Abb, @Firstname, @Lastname, @Jobdescription, @IsAdmin)", person);
            }
        }
        public static List<AufgabenModel> LoadTasks()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<AufgabenModel>("SELECT tasks.id, tasks.category as categoryid, c1.description as CategoryString, title, c1.color as CategoryColor, c1.icon as CategoryIcon, tasks.description, tasks.mainuser as mainuserid, u1.abb as mainuser, tasks.subuser as subuserid, u2.abb as subuser, tasks.subsubuser as subsubuserid, u3.abb as subsubuser, tasks.frequency, tasks.startdate, tasks.enddate, tasks.donedate, u4.abb as donebyuser FROM tasks LEFT JOIN categories as c1 ON tasks.id = c1.ID LEFT JOIN users AS u1 ON tasks.mainuser = u1.id LEFT JOIN users AS u2 ON tasks.subuser = u2.id LEFT JOIN users AS u3 ON tasks.subsubuser = u3.id LEFT JOIN users AS u4 ON tasks.donebyuser = u4.id", new DynamicParameters());
                return output.ToList();
            }
        }
        public static List<AufgabenModel> LoadTask(string Item)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<AufgabenModel>("SELECT tasks.id, tasks.category as categoryid, c1.description as CategoryString, title, c1.color as CategoryColor, c1.icon as CategoryIcon, tasks.description, tasks.mainuser as mainuserid, u1.abb as mainuser, tasks.subuser as subuserid, u2.abb as subuser, tasks.subsubuser as subsubuserid, u3.abb as subsubuser, tasks.frequency, tasks.startdate, tasks.enddate, tasks.donedate, u4.abb as donebyuser FROM tasks LEFT JOIN categories as c1 ON tasks.id = c1.ID LEFT JOIN users AS u1 ON tasks.mainuser = u1.id LEFT JOIN users AS u2 ON tasks.subuser = u2.id LEFT JOIN users AS u3 ON tasks.subsubuser = u3.id LEFT JOIN users AS u4 ON tasks.donebyuser = u4.id WHERE tasks.id='" + Item+"'", new DynamicParameters());
                return output.ToList();
            }
        }
        public static void SaveTask(AufgabenModel aufgabe)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("", aufgabe);
            }
        }
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
