using System;

namespace DiverPelos.Views.MasterDetail
{

    public class MyMasterDetailPageMasterMenuItem
    {
        public MyMasterDetailPageMasterMenuItem()
        {
            TargetType = typeof(MyMasterDetailPageMasterMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public string Icon { get; set; }
        public Type TargetType { get; set; }
    }
}