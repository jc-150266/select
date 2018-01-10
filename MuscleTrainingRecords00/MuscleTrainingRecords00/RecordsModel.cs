using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace MuscleTrainingRecords00
{
    [Table("Records")]//テーブル名を指定
    class RecordsModel
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int M_no { get; set; } //筋トレNo 主キー

        public string M_weight { get; set; } //重量

        public string M_leg { get; set; } //回数

        public string M_set { get; set; } //セット数

        public DateTime M_date { get; set; } //日付

        //[ForeignKey(typeof(SettingModel))]
        // public int Set_no { get; set; } //Setting表の外部キー

        /********************インサートメソッド**********************/
        public static void InsertRecords(string m_weight, string m_leg, string m_set, DateTime m_date)
        {
            //データベースに接続する
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {
                try
                {
                    //データベースにFoodテーブルを作成する
                    db.CreateTable<RecordsModel>();

                    db.Insert(new RecordsModel() { M_weight = m_weight, M_leg = m_leg, M_set = m_set, M_date = m_date });
                    db.Commit();
                }
                catch (Exception e)
                {
                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);
                }
            }
        }

        /*******************セレクトメソッド**************************************/
        public static List<RecordsModel> SelectRecords()
        {
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {
                try
                {
                    //データベースに指定したSQLを発行
                    return db.Query<RecordsModel>("SELECT * FROM [Records] ORDER BY [M_date]");

                }
                catch (Exception e)
                {

                    System.Diagnostics.Debug.WriteLine(e);
                    return null;
                }
            }
        }

        /********************デリートメソッド*************************************/
        public static void DeleteRecords(int m_no)
        {
            //データベースに接続する
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {
                try
                {
                    //データベースにFoodテーブルを作成する
                    db.CreateTable<RecordsModel>();

                    db.Delete<RecordsModel>(m_no);//デリートで渡す値は主キーじゃないといけない説
                    db.Commit();
                }
                catch (Exception e)
                {
                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);
                }
            }
        }

        /********************オールデリートメソッド*************************************/
        public static void DeleteAllRecordsd()
        {
            //データベースに接続する
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {
                try
                {
                    //データベースにFoodテーブルを作成する
                    db.CreateTable<RecordsModel>();

                    db.DeleteAll<RecordsModel>();//デリートで渡す値は主キーじゃないといけない説
                    db.Commit();
                }
                catch (Exception e)
                {
                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);
                }
            }
        }

        /********************アップデートメソッド（日付）*************************************/
        public static void UpdateF_date(int m_no, string m_weight, string m_leg, string m_set, DateTime m_date)
        {
            //データベースに接続する
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {
                try
                {
                    //データベースにFoodテーブルを作成する
                    db.CreateTable<RecordsModel>();

                    //TimeSpan t = f_date - new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day+1);//よくわからん
                    TimeSpan t = m_date - new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);//よくわからん

                    int span = t.Days;

                    db.Update(new RecordsModel() { M_no = m_no, M_weight = m_weight, M_leg = m_leg, M_set = m_set, M_date = m_date });

                    db.Commit();
                }
                catch (Exception e)
                {
                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);
                }
            }
        }


    }
}