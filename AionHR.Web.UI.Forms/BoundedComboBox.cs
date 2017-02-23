using Ext.Net;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AionHR.Web.UI.Forms
{
    public class BoundedComboBox : ComboBox

    {
        public BoundedComboBox(string Id, string displayField, string valueField,string label, string direct, string emptyText, string headerTitle, bool isFiltered, Ext.Net.Model model = null) : base()
        {
            FieldLabel = label;
            EmptyText = emptyText;
            SimpleSubmit = true;
            Store store = new Ext.Net.Store();
            store.ID = label + "Store";
            ID = Id;


            IDMode = IDMode.Static;
            store.Proxy.Add(new PageProxy() { DirectFn = "App.direct." + direct, DirectionParam = "" });


            store.IsPagingStore = true;
            store.PageSize = 10;

            MatchFieldWidth = true;

            Editable = true;
            store.AutoLoad = true;

            DisplayField = displayField;
            ValueField = valueField;
            ListConfig = new BoundList();
            ListConfig.Tpl = new XTemplate();

            ListConfig.Tpl.Html = @"<tpl for='.'><tpl if='[xindex] == 1'><h3>" + headerTitle + "</h3><hr/></tpl><h4 class='x-boundlist-item'>{"+displayField+"}</h4></tpl>";
            if (model != null)
                store.Model.Add(model);
            else
                store.Model.Add(StoreFactory.GetNameValueModel());
            if (isFiltered)
            {

                TriggerAction = TriggerAction.Query;
                MinChars = 3;
            }

            Listeners.Expand.Handler = "#{" + store.ID + "}.reload();";
            Store.Add(store);

        }



    }
}