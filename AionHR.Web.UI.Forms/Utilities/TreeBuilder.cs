using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AionHR.Web.UI.Forms.Utilities
{
    public class TreeBuilder
    {
        private static TreeBuilder instance;
        public static TreeBuilder Instance
        {
            get
            {
                if (instance == null)
                    instance = new TreeBuilder();
                return instance;
            }
        }

        public NodeCollection BuildCaseManagementTree(NodeCollection nodes)
        {
            if (nodes == null)
                nodes = new Ext.Net.NodeCollection();



            Ext.Net.Node rootParent = BuildRootParentNode("rootParent", Resources.Common.CaseManagement, true);
            Ext.Net.Node Cases = BuildParentNode("rootParent_cases", Resources.Common.Cases, true, rootParent);
            Ext.Net.Node CaseLeaf = BuildLeafNode("rootParent_casesLeaf", Resources.Common.CasesLeaf,"User", true, Cases);
            FillConfigItem(CaseLeaf, "manageCaseManagement", "CM.aspx", Resources.Common.CasesLeaf, "icon-CaseManagement", "1");



            nodes.Add(rootParent);
            return nodes;
        }


        public NodeCollection BuildEmployeeFilesTree(NodeCollection nodes)
        {
            if (nodes == null)
                nodes = new Ext.Net.NodeCollection();



            Ext.Net.Node rootParent = BuildRootParentNode("rootParent", Resources.Common.EmployeeFiles, true);
            Ext.Net.Node employees = BuildParentNode("rootParent_Employee", Resources.Common.Employee, true, rootParent);
            Ext.Net.Node employeesLeaf = BuildLeafNode("rootParent_Employee_Leaf", Resources.Common.EmployeeLeaf, "Group", true, employees);
            FillConfigItem(employeesLeaf, "manageemployees", "Employees.aspx", Resources.Common.EmployeeLeaf, "icon-Employees", "1");



            nodes.Add(rootParent);
            return nodes;
        }



        private Node BuildLeafNode(string ID, string Label,string icon, bool isExpanded, Ext.Net.Node parentNode)
        {
            Ext.Net.Node node = new Ext.Net.Node();
            node.Text = Label;
            node.NodeID = ID;
            node.Icon = (Icon)Enum.Parse(typeof(Icon), icon);
            node.Expandable = isExpanded;
            node.Leaf = true;
            parentNode.Children.Add(node);
            return node;
        }

        private Node BuildParentNode(string ID, string Label, bool isExpanded, Ext.Net.Node parentNode)
        {
            Ext.Net.Node node = new Ext.Net.Node();
            node.Text = Label;
            node.NodeID = ID;
            node.Expanded = isExpanded;
            parentNode.Children.Add(node);
            return node;
        }

        private Node BuildRootParentNode(string ID, string Label, bool isExpanded)
        {
            Ext.Net.Node rootParent = new Ext.Net.Node();
            rootParent.Text = Label;
            rootParent.NodeID = ID;
            rootParent.Expanded = isExpanded;
            return rootParent;
        }

        private void FillConfigItem(Node node, string id, string url, string title, string css, string ifClick)
        {
            node.CustomAttributes.Add(new ConfigItem("idTab", id, ParameterMode.Value));
            node.CustomAttributes.Add(new ConfigItem("url", url, ParameterMode.Value));
            node.CustomAttributes.Add(new ConfigItem("title", title, ParameterMode.Value));
            node.CustomAttributes.Add(new ConfigItem("css", css, ParameterMode.Value));
            node.CustomAttributes.Add(new ConfigItem("click", ifClick, ParameterMode.Value));
        }
    }
}