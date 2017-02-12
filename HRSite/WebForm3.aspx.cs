using Ext.Net;
using HRSite.Classes;
using HRSite.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRSite
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ComboBox b = new ComboBox();
            b.FieldLabel = "nothing ";

            formPanel1.Items.Add(new BoundedComboBox("depts", "BindDepts"));
            string label = "ddd";
            b.FieldLabel = label;
            Store store = new Ext.Net.Store();
            store.ID = label + "Store";
            b.ID = label + "combo";
           store.Proxy.Add(new PageProxy() { DirectFn = "App.direct.BindDepts", DirectionParam = "" });
            store.IsPagingStore = true;
            store.PageSize = 10;

            b.MatchFieldWidth = true;

            b.Editable = false;

            store.AutoSync = true;
            b.DisplayField = "name";
            b.ValueField = "recordId";
           // b.ListConfig.Tpl.Html = @"<tpl for='.'><tpl if='[xindex] == 1'><h3>" + label + "</h3></tpl><h4 class='x-boundlist-item'>{name}</h4><tpl if='[xcount-xindex]==0'><div><a href='#' target='_blank' >Add new one</a><br /></div></tpl></tpl>";
            store.Model.Add(StoreFactory.GetNameValueModel());


            b.Listeners.Expand.Handler = "#{" + store.ID + "}.reload();";
            b.Store.Add(store);
            formPanel1.Items.Add(b);
            ComboBox s = cbStates;
        }
        [DirectMethod]
        public object BindDepts(string action, Dictionary<string, object> extraParams)
        {
            StoreRequestParameters prms = new StoreRequestParameters(extraParams);
            


            List<Department> data = CS.GetDepartments();

            return new
            {
                data
            };

        }
    }
}