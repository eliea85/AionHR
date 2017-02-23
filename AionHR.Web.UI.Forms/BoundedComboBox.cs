using Ext.Net;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AionHR.Web.UI.Forms
{
    public class BoundedComboBox:ComboBox

    {
        public BoundedComboBox(string Id,string label,string direct,string emptyText, string headerTitle):base()
        {
            FieldLabel = label;
            EmptyText = emptyText;
            SimpleSubmit = true;
            Store store = new Ext.Net.Store();
            store.ID = label + "Store";
            ID = Id;
            MinChars = 3;
           
            IDMode = IDMode.Static;
            store.Proxy.Add(new PageProxy() { DirectFn = "App.direct."+direct,DirectionParam="" });
            store.AutoLoad = false;
            store.IsPagingStore = true;
            store.PageSize = 10;
            TriggerAction = TriggerAction.Query;
            MatchFieldWidth = true;

            Editable = true;

            
            DisplayField = "name";
            ValueField = "recordId";
            ListConfig = new BoundList();
            ListConfig.Tpl = new XTemplate();
            
            ListConfig.Tpl.Html = @"<tpl for='.'><tpl if='[xindex] == 1'><h3>" + headerTitle + "</h3><hr/></tpl><h4 class='x-boundlist-item'>{name}</h4><tpl if='[xcount-xindex]==0'><div><a href='#' target='_blank' >Add new one</a><br /></div></tpl></tpl>";
            store.Model.Add(StoreFactory.GetNameValueModel());
            

            Listeners.Expand.Handler = "#{"+store.ID+"}.reload();";
            Store.Add(store);
            
        }

      
        
    }
}