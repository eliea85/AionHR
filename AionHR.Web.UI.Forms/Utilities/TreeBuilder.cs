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

        internal NodeCollection BuildCompanyStructureTree(NodeCollection nodes)
        {
            if (nodes == null)
                nodes = new Ext.Net.NodeCollection();



            Ext.Net.Node rootParent = BuildRootParentNode("rootParent", Resources.Common.Company, true);
            Ext.Net.Node companyStructure = BuildParentNode("rootParent_CS", Resources.Common.CompanyStructure, true, rootParent);
            Ext.Net.Node departments = BuildLeafNode("rootParent_CS_DE", Resources.Common.Departments, "Group", true, companyStructure);
            Ext.Net.Node branches = BuildLeafNode("rootParent_CS_BR", Resources.Common.Branches, "Group", true, companyStructure);
            Ext.Net.Node positions = BuildLeafNode("rootParent_CS_PO", Resources.Common.Positions, "Group", true, companyStructure);
            Ext.Net.Node activities = BuildParentNode("rootParent_AC", Resources.Common.Activities, true, rootParent);
            Ext.Net.Node transfers = BuildLeafNode("rootParent_AC_TR", Resources.Common.Transfers, "Group", true, activities);
            Ext.Net.Node systemSettings = BuildParentNode("rootParent_SY", Resources.Common.SystemSettings, true, rootParent);
            Ext.Net.Node nationalities = BuildLeafNode("rootParent_SY_NA", Resources.Common.Nationalities, "Group", true, systemSettings);
            Ext.Net.Node currencies = BuildLeafNode("rootParent_CS_CU", Resources.Common.Currencies, "Group", true, systemSettings);
            Ext.Net.Node users = BuildLeafNode("rootParent_CS_US", Resources.Common.Users, "Group", true, systemSettings);
            FillConfigItem(branches, "branches", "Branches.aspx", Resources.Common.Branches, "icon-Employees", "1");
            FillConfigItem(departments, "departments", "Departments.aspx", Resources.Common.Departments, "icon-Employees", "1");
            FillConfigItem(positions, "positions", "Positions.aspx", Resources.Common.Positions, "icon-Employees", "1");
            FillConfigItem(currencies, "currencies", "Currencies.aspx", Resources.Common.Currencies, "icon-Employees", "1");
            FillConfigItem(nationalities, "nationalities", "Nationalities.aspx", Resources.Common.Nationalities, "icon-Employees", "1");
            FillConfigItem(users, "users", "Users.aspx", Resources.Common.Users, "icon-Employees", "1");



            nodes.Add(rootParent);
            return nodes;
        }
    }
}