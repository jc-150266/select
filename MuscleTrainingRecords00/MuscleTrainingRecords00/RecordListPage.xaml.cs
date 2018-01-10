using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MuscleTrainingRecords00
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecordListPage : ContentPage
    {
        public RecordListPage()
        {
            InitializeComponent();

            //Userテーブルの行データを取得
            var query = RecordsModel.SelectRecords(); //中身はSELECT * FROM [Records]
            var layout = new StackLayout { HorizontalOptions = LayoutOptions.Center, Margin = new Thickness { Top = 100 } };
            foreach (var records in query)
            {
                //Userテーブルの名前列をLabelに書き出す
                layout.Children.Add(new Label { Text = records.M_weight });
            }
        }
        private void RecordListButton(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MenuPage());
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RecordPage());

        }
    }
}